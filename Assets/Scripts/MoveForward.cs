using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private readonly float _speed = 10.0f;
    private Vector3 _startPos;

    void Start()
    {
        _startPos = transform.position;
        transform.Rotate(new Vector3(0.0f, 0.0f, 90.0f));
    }

    void Update()
    {
        transform.Translate(_speed * Time.deltaTime * Vector3.forward);
        float distance = Vector3.Distance(transform.position, _startPos);
        if (distance >= 30.0f)
        {
            Destroy(gameObject);
        }
    }
}
