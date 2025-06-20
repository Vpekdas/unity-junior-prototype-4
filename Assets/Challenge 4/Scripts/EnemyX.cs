using UnityEngine;

public class EnemyX : MonoBehaviour
{
    public float Speed;
    private Rigidbody _enemyRb;
    private GameObject _playerGoal;

    private GameObject _spawnManager;

    private float _waveCount;

    void Start()
    {
        _enemyRb = GetComponent<Rigidbody>();
        _playerGoal = GameObject.Find("Player Goal");
        _spawnManager = GameObject.Find("Spawn Manager");
        _waveCount = _spawnManager.GetComponent<SpawnManagerX>().WaveCount;
    }

    void Update()
    {
        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (_playerGoal.transform.position - transform.position).normalized;
        _enemyRb.AddForce(lookDirection * (Speed + _waveCount));
    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal" || other.gameObject.name == "Player Goal")
        {
            Destroy(gameObject);
        }
    }
}