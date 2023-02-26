using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private float maxFollowDistance = 10f;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Vector3 offset;

    private Transform _playerTransform;

    private void Start()
    {
        _playerTransform = playerTransform;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = playerTransform.position + offset;
        transform.position = targetPosition;
        transform.LookAt(new Vector3(targetPosition.x, transform.position.y, targetPosition.z));
    }
}
