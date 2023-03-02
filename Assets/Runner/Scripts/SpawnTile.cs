using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTile : MonoBehaviour
{
    [SerializeField] private GameObject _tileToSpawn;
    [SerializeField] private GameObject _referenceObject;
    [SerializeField] private float _timeOffset = 0.4f;
    [SerializeField] private float _distanceBetweenTiles = 5.0F;
    [SerializeField] private float _randomValue = 0.8f;

    private Vector3 previousTilePosition;
    private float startTime;
    private Vector3 direction, mainDirection = new Vector3(0, 0, 1), otherDirection = new Vector3(1, 0, 0);

    void Start()
    {
        previousTilePosition = _referenceObject.transform.position;
        startTime = Time.time;
    }

    void Update()
    {
        if (Time.time - startTime > _timeOffset)
        {
            if (Random.value < _randomValue)
                direction = mainDirection;
            else
            {
                Vector3 temp = direction;
                direction = otherDirection;
                mainDirection = direction;
                otherDirection = temp;
            }
            Vector3 spawnPos = previousTilePosition + _distanceBetweenTiles * direction;
            startTime = Time.time;
            Instantiate(_tileToSpawn, spawnPos, Quaternion.Euler(0, 0, 0));
            previousTilePosition = spawnPos;
        }
    }
}
