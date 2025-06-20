using UnityEngine;
public class SpawnManager : MonoBehaviour
{
    public GameObject PowerUpPrefab;
    public GameObject FirePowerUpPrefab;
    public GameObject SmashPowerUpPrefab;
    public GameObject Boss;
    public GameObject[] EnemyTypes;
    public float SpawnRange;
    private int _waveNumber = 1;
    private int _enemies;

    public virtual void Start()
    {
        Instantiate(PowerUpPrefab, GenerateRandomSpawn(), PowerUpPrefab.transform.rotation);
        Instantiate(FirePowerUpPrefab, GenerateRandomSpawn(), FirePowerUpPrefab.transform.rotation);
        Instantiate(SmashPowerUpPrefab, GenerateRandomSpawn(), SmashPowerUpPrefab.transform.rotation);
        SpawnEnemyWave(_waveNumber);
    }

    public virtual void Update()
    {
        _enemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (_enemies != 0)
        {
            return;
        }
        Instantiate(PowerUpPrefab, GenerateRandomSpawn(), PowerUpPrefab.transform.rotation);
        Instantiate(FirePowerUpPrefab, GenerateRandomSpawn(), FirePowerUpPrefab.transform.rotation);
        Instantiate(SmashPowerUpPrefab, GenerateRandomSpawn(), SmashPowerUpPrefab.transform.rotation);
        _waveNumber++;

        if (_waveNumber % 3 == 0)
        {
            SpawnBossWave();
        }
        else
        {
            SpawnEnemyWave(_waveNumber);
        }
    }

    private Vector3 GenerateRandomSpawn()
    {
        float spawnX = Random.Range(-SpawnRange, SpawnRange);
        float spawnZ = Random.Range(-SpawnRange, SpawnRange);
        return new Vector3(spawnX, 0.0f, spawnZ);
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        int enemyIndex;
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            enemyIndex = Random.Range(0, EnemyTypes.Length);
            Instantiate(EnemyTypes[enemyIndex], GenerateRandomSpawn(), EnemyTypes[enemyIndex].transform.rotation);
        }
    }

    private void SpawnBossWave()
    {
        Instantiate(Boss, new Vector3(), Boss.transform.rotation);
    }
}