using UnityEngine;
using System.Collections;

public class Boss : Enemy
{
    public GameObject Companion;
    public GameObject Projectile;
    public int EnemiesToSpawn;
    public float SpawnRange;
    protected override void Start()
    {
        base.Start();
        StartCoroutine(BossFireRoutine());
        StartCoroutine(SpawnCompanionRoutine());
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void TakeSmashEffect()
    {
        float range = 10.0f;
        float distance = Vector3.Distance(transform.position, Player.transform.position);
        Vector3 AwayFromPlayer = transform.position - Player.transform.position;
        EnemyRB.AddForce((range - distance) / 2 * AwayFromPlayer, ForceMode.Impulse);
    }

    private Vector3 GenerateRandomSpawn()
    {
        float spawnX = Random.Range(-SpawnRange, SpawnRange);
        float spawnZ = Random.Range(-SpawnRange, SpawnRange);
        return new Vector3(spawnX, 0.0f, spawnZ);
    }

    IEnumerator BossFireRoutine()
    {
        while (true)
        {
            ThrowProjectiles();
            yield return new WaitForSeconds(2.0f);
        }
    }

    private void ThrowProjectiles()
    {
        Vector3 playerDirection = (Player.transform.position - transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(playerDirection);
        Instantiate(Projectile, transform.position, rotation);
    }

    IEnumerator SpawnCompanionRoutine()
    {
        while (true)
        {
            for (int i = 0; i < EnemiesToSpawn; i++)
            {
                Instantiate(Companion, GenerateRandomSpawn(), Companion.transform.rotation);
            }
            yield return new WaitForSeconds(10.0f);
        }
    }
}