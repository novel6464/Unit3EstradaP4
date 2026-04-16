using UnityEngine;
using System.Collections;
public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed = 5.0f;
    private GameObject focalPoint;
    public bool hasPowerup;
    private float powerupStrength = 1500.0f;
    public GameObject powerupIndicator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {

        float fowardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed *fowardInput);

        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
                StartCoroutine(PowerupCountdownRoutine());
        }
        powerupIndicator.gameObject.SetActive(true);    
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position); 
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            Debug.Log("Collided with: " + collision.gameObject.name + " with powerup set to " + hasPowerup);
        }
    }
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }
}
