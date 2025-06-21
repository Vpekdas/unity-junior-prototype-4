using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControllerX : MonoBehaviour
{
    public bool HasPowerup;
    public GameObject PowerupIndicator;
    public int PowerUpDuration = 5;
    public ParticleSystem SmokeParticle;
    private readonly float _normalStrength = 10; // how hard to hit enemy without powerup
    private readonly float _powerupStrength = 25; // how hard to hit enemy with powerup
    private Rigidbody _playerRb;
    private readonly float _speed = 500;
    private GameObject _focalPoint;

    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        _focalPoint = GameObject.Find("Focal Point");
    }

    void Update()
    {
        // Add force to player in direction of the focal point (and camera)
        float verticalInput = Input.GetAxis("Vertical");

        // Set powerup indicator position to beneath player
        PowerupIndicator.transform.position = transform.position + new Vector3(0, -0.6f, 0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SmokeParticle.Play();
            _playerRb.AddForce(_focalPoint.transform.forward * 10.0f, ForceMode.Impulse);
        }
        else
        {
            _playerRb.AddForce(_speed * Time.deltaTime * verticalInput * _focalPoint.transform.forward);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }

    }

    // If Player collides with powerup, activate powerup
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            HasPowerup = true;
            PowerupIndicator.SetActive(true);
            StartCoroutine(PowerupCooldown());
        }
    }

    // Coroutine to count down powerup duration
    IEnumerator PowerupCooldown()
    {
        yield return new WaitForSeconds(PowerUpDuration);
        HasPowerup = false;
        PowerupIndicator.SetActive(false);
    }

    // If Player collides with enemy
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = other.gameObject.transform.position - transform.position;

            if (HasPowerup) // if have powerup hit enemy with powerup force
            {
                enemyRigidbody.AddForce(awayFromPlayer * _powerupStrength, ForceMode.Impulse);
            }
            else // if no powerup, hit enemy with normal strength 
            {
                enemyRigidbody.AddForce(awayFromPlayer * _normalStrength, ForceMode.Impulse);
            }
        }
    }
}