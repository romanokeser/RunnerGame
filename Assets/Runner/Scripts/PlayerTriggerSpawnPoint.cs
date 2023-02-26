using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerSpawnPoint : MonoBehaviour
{
    public static Action OnPlayerEnterEndPoint;
    private bool _doOnce = false;


    private void OnTriggerEnter(Collider other)
    {
        if (!_doOnce)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("TriggerEndPoint"))
            {
                Debug.Log("Player triggered spawning of next platform");
                OnPlayerEnterEndPoint?.Invoke();
            }
            _doOnce = true;
            StartCoroutine(ResetBool());
        }
    }

    private IEnumerator ResetBool()
    {
        yield return new WaitForSeconds(0.2f);
        _doOnce = false;
    }
}
