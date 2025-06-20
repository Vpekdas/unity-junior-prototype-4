using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    private float _horizontalInput;

    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime * _horizontalInput);
    }
}