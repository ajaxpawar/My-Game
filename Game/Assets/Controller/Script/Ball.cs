
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    [SerializeField] private Transform ballStartPosition;
    [SerializeField] private bool inPlay = false;
    private AudioSource brakingbrick;
    public GameObject slider;
    public GameManager gameManagerScript;
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        brakingbrick = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!inPlay)
        {
            transform.position = ballStartPosition.position;
            if (gameManagerScript.gameOver)
            {
                return;
            }
        }
        if (Input.GetMouseButtonDown(0) && !inPlay )//jump=spase button
        {
            inPlay = true;
            rb.AddForce(Vector2.up * 250);
        }
    }
     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bottom"))
        {
            rb.velocity = Vector2.zero;
            inPlay = false;
            gameManagerScript.UpdateLives(-1);
        }
    }
     void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject!=slider)
        {
            brakingbrick.Play();
        }
        if (other.transform.CompareTag("Brick"))
        {
            gameManagerScript.UpdateScore(other.gameObject.GetComponent<normalBrick>().points);
            Destroy(other.gameObject);
        }
    }

}
