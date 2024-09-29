using UnityEngine;

public class Purpose : MonoBehaviour
{
    [SerializeField] private float _speed = 3.0f;
    [SerializeField] private Points _points;
    private Point _target;

    private void Start()
    {
        _target = TakeNextPoint();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);

        if (Vector3.SqrMagnitude(transform.position - _target.transform.position) == 0 * 0)      
            _target = TakeNextPoint();       
    }

    private Point TakeNextPoint()
    {
        return _points.GetRandomPoint();
    }
}
