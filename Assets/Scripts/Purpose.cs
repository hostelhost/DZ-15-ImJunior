using UnityEngine;

public class Purpose : MonoBehaviour
{
    [SerializeField] private float _speed = 3.0f;
    
    private Points _points;
    private Point _target;

    private void Awake() =>    
        _points = FindObjectOfType<Points>();

    private void Start() =>
        TakeNewPoint();   

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, _target.transform.position) == 0)       
            TakeNewPoint();        
    }

    private void TakeNewPoint()
    {
        if (_target != null)
            _target.Reached -= TakeNewPoint;

        _target = _points.GetRandomPoint();
        _target.Reached += TakeNewPoint;
    }
}
