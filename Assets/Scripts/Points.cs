using UnityEngine;

public class Points : MonoBehaviour
{
    private Point[] _points;

    private void Start() =>   
        _points = GetComponentsInChildren<Point>();

    public Point GetRandomPoint() => 
        _points[Random.Range(0, _points.Length)];
}