using UnityEngine;

public class TrailCamera : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _trailDistance = 5.0f;
    [SerializeField] private float _heightOffset = 3.0f;
    [SerializeField] private float _cameraDelay = 0.02f;

    void Update()
    {
        Vector3 followPos = _target.position - _target.forward * _trailDistance;

        followPos.y += _heightOffset;
        transform.position += (followPos - transform.position) * _cameraDelay;

        transform.LookAt(_target.transform);
    }
}
