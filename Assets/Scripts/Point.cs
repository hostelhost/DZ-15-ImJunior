using System;
using UnityEngine;
[RequireComponent(typeof(SphereCollider))]

public class Point : MonoBehaviour
{
    public event Action Reached;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Purpose>(out Purpose purpose))
            Reached?.Invoke();      
    }
}
