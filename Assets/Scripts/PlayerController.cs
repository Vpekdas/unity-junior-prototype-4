using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public bool HasPowerUp;
    public bool HasPowerUpSmash;
    public bool IsSmashing;
    public float Speed;
    public float PowerUpStrength;
    public int PowerUpDuration;
    public TextMeshProUGUI RestartText;

    public GameObject PowerUpIndicator;
    public GameObject Projectile;
    private Rigidbody _playerRB;
    private GameObject _focalPoint;
    private GameObject[] _enemies;
    private float _verticalInput;
    private readonly int _smashCount = 2;


    void Start()
    {
        _playerRB = GetComponent<Rigidbody>();
        _focalPoint = GameObject.Find("Focal Point");
        _enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    void Update()
    {
        _verticalInput = Input.GetAxis("Vertical");
        _playerRB.AddForce(Speed * _verticalInput * _focalPoint.transform.forward);
        PowerUpIndicator.transform.position = transform.position + new Vector3(0.0f, -0.5f, 0.0f);
        _enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();

        }
        if (transform.position.y < -10)
        {
            RestartText.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && HasPowerUp)
        {
            Rigidbody EnemyRB = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 AwayFromPlayer = collision.gameObject.transform.position - transform.position;
            EnemyRB.AddForce(AwayFromPlayer * PowerUpStrength, ForceMode.Impulse);
        }
        if (collision.gameObject.CompareTag("Ground") && HasPowerUpSmash)
        {
            IsSmashing = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsSmashing = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            HasPowerUp = true;
            PowerUpIndicator.SetActive(true);
            StartCoroutine(PowerUpCountdownRoutine());
        }
        else if (other.CompareTag("PowerUpProjectile"))
        {
            Destroy(other.gameObject);
            PowerUpIndicator.SetActive(true);
            StartCoroutine(FirePowerUpCountdownRoutine());
        }
        else if (other.CompareTag("PowerUpSmash"))
        {
            HasPowerUpSmash = true;
            Destroy(other.gameObject);
            PowerUpIndicator.SetActive(true);
            StartCoroutine(SmashPowerUpCountdownRoutine());
        }
        else if (other.CompareTag("BossProjectile"))
        {
            Destroy(other.gameObject);
            Vector3 AwayFromProjectile = transform.position - other.gameObject.transform.position;
            _playerRB.AddForce(2 * _playerRB.mass * AwayFromProjectile, ForceMode.Impulse);
        }
    }

    IEnumerator PowerUpCountdownRoutine()
    {
        yield return new WaitForSeconds(PowerUpDuration);
        HasPowerUp = false;
        PowerUpIndicator.SetActive(false);
    }

    IEnumerator FirePowerUpCountdownRoutine()
    {
        InvokeRepeating(nameof(ThrowProjectiles), 0.1f, 1.0f);
        yield return new WaitForSeconds(PowerUpDuration);
        PowerUpIndicator.SetActive(false);
        CancelInvoke(nameof(ThrowProjectiles));
    }

    private void ThrowProjectiles()
    {
        foreach (GameObject enemy in _enemies)
        {
            Vector3 enemyDirection = (enemy.transform.position - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(enemyDirection);
            Instantiate(Projectile, transform.position, rotation);
        }
    }

    IEnumerator SmashPowerUpCountdownRoutine()
    {
        for (int i = 0; i < _smashCount; i++)
        {
            while (transform.position.y < 5.0f)
            {
                transform.position += Speed * Time.deltaTime * Vector3.up;
                yield return null;
            }
            while (transform.position.y > 1.0f)
            {
                transform.position -= Speed * Time.deltaTime * Vector3.down;
                yield return null;
            }
        }
        HasPowerUpSmash = false;
        PowerUpIndicator.SetActive(false);
    }


    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}