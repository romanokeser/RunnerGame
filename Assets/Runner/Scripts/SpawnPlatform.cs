using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnPlatform : MonoBehaviour
{
    [SerializeField] private GameObject _platformPrefab;
    [SerializeField] private Transform _platformParent;
    [SerializeField] private Transform _player;
    [SerializeField] private float _spawnDistance = 20f;
    [SerializeField] private float _platformLength = 10f;

    [SerializeField] private List<GameObject> _platformGOList = new List<GameObject>();

    private Vector3 lastPlatformEndPosition = new Vector3(0,0,0);

    private void Awake()
    {
        PlayerTriggerSpawnPoint.OnPlayerEnterEndPoint += SpawnRandomPlatform;
    }

    private void Start()
    {
        SpawnInitialPlatforms();
    }

    private void SpawnInitialPlatforms()
    {
        // Spawn the first platform at (0,0,0)
        GameObject firstPlatform = Instantiate(_platformPrefab, _platformParent);
        firstPlatform.transform.position = new Vector3(0, 0, 0);

        // Add the first platform to the list of spawned platforms
        _platformGOList.Add(firstPlatform);

        // Spawn two additional platforms
        for (int i = 0; i < 2; i++)
        {
            SpawnRandomPlatform();
        }
    }

    private void SpawnRandomPlatform()
    {
        Direction randomDirection = (Direction)Random.Range(0, 3);
        SpawnNewPlatform(randomDirection, lastPlatformEndPosition);
    }

    private void SpawnNewPlatform(Direction direction, Vector3? pivotPoint = null)
    {
        GameObject newPlatform = Instantiate(_platformPrefab, _platformParent);
        Vector3 newPlatformEndPosition = newPlatform.transform.Find("EndPoint").position;

        newPlatformEndPosition = newPlatform.transform.TransformPoint(newPlatformEndPosition);

        Vector3 spawnPosition = pivotPoint ?? lastPlatformEndPosition;

        Vector3 platformOffset = newPlatformEndPosition - spawnPosition;

        switch (direction)
        {
            case Direction.Left:
                newPlatform.transform.Rotate(Vector3.up, -90f);
                newPlatform.transform.position = spawnPosition + new Vector3(-platformOffset.z, 0f, platformOffset.x);
                break;
            case Direction.Right:
                newPlatform.transform.Rotate(Vector3.up, 90f);
                newPlatform.transform.position = spawnPosition + new Vector3(platformOffset.z, 0f, -platformOffset.x);
                break;
            case Direction.Straight:
                newPlatform.transform.position = spawnPosition + new Vector3(0f, 0f, platformOffset.z);
                break;
        }

        // Update the last platform end position and add the new platform to the list
        lastPlatformEndPosition = newPlatformEndPosition;
        _platformGOList.Add(newPlatform);
        lastPlatformEndPosition = newPlatform.transform.Find("EndPoint").position;
    }

    public enum Direction
    {
        Left,
        Right,
        Straight
    }
}
