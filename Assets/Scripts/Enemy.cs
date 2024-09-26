using System;
using UnityEngine;
[RequireComponent(typeof(Renderer))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 7.0f;
    private Action<Enemy> _onRelease;
    private Purpose _target;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);

        if (Vector3.SqrMagnitude(transform.position - _target.transform.position) == 0)
            _onRelease?.Invoke(this);           
    }

    public void Initialize(Material material, Purpose target, Action<Enemy> onRelease)
    {
        _target = target;
        GetComponent<Renderer>().material = material;
        _onRelease = onRelease;
    }
}
