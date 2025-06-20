using UnityEngine;
public class Enemy : MonoBehaviour
{
    public float Speed;
    protected Rigidbody EnemyRB;
    protected GameObject Player;
    protected virtual void Start()
    {
        EnemyRB = GetComponent<Rigidbody>();
        Player = GameObject.Find("Player");
    }

    protected virtual void Update()
    {
        Vector3 lookDirection = (Player.transform.position - transform.position).normalized;
        EnemyRB.AddForce(lookDirection * Speed);
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
        if (Player.GetComponent<PlayerController>().IsSmashing)
        {
            TakeSmashEffect();
        }
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
            Vector3 AwayFromProjectile = transform.position - other.gameObject.transform.position;
            EnemyRB.AddForce(10 * EnemyRB.mass * AwayFromProjectile, ForceMode.Impulse);
        }
    }

    protected virtual void TakeSmashEffect()
    {
        float range = 15.0f;
        float distance = Vector3.Distance(transform.position, Player.transform.position);
        Vector3 AwayFromPlayer = transform.position - Player.transform.position;
        EnemyRB.AddForce((range - distance) * AwayFromPlayer, ForceMode.Impulse);

    }
}
