using UnityEngine;

public class Points : MonoBehaviour
{
   [SerializeField] private Point[] _points;

    public Point GetRandomPoint()
    {
       return _points[Random.Range(0, _points.Length)];
    }
}