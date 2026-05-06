using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    public float minSpeed = 12;
    public float maxSpeed = 16;
    public float maxTorque = 10;    
    public float xRange = 4;
    public float yRange = 6;
    private GameManager gameManager;
    public int pointValue;
    public ParticleSystem explosionParticle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(Vector3.up * Random.Range(minSpeed, maxSpeed), ForceMode.Impulse);
        targetRb.AddTorque(Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque), ForceMode.Impulse); 
        transform.position = new Vector3(Random.Range(-xRange, xRange), -yRange);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }   
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), -yRange);
    }   
    private void OnMouseDown()
    {
        
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);   
       
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }
}
