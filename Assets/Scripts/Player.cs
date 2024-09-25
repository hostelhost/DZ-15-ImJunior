using System;
using UnityEngine;
[RequireComponent(typeof(Renderer))]

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 7.0f;
    private Action<Player> _onRelease;
    private Purpose _target;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, _target.transform.position) == 0)
            _onRelease?.Invoke(this);
    }

    public void Initialize(Material material, Purpose target, Action<Player> onRelease)
    {
        _target = target;
        GetComponent<Renderer>().material = material;
        _onRelease = onRelease;
    }
}
