using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;

    private void Update()
    {
        transform.Rotate(_speed * Time.deltaTime * Vector3.up);
    }
}
