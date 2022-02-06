
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
    public Transform LifePowerUp;
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        brakingbrick = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (gameManagerScript.gameOver)//game over
        {
            transform.position = ballStartPosition.position;
            return;
        }
        if (!inPlay)
        {
           
            transform.position = ballStartPosition.position;

        }
        if (Input.GetMouseButtonDown(0) && !inPlay )//jump=spase button
        {
            inPlay = true;
           // rb.AddForce(Vector2.up*250);
            rb.AddForce(new Vector2(0, 250));

        }
    }
     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bottom"))
        {
            rb.velocity = Vector2.zero;
            inPlay = false;
            gameManagerScript.UpdateLives(-1);//remove lives
        }
    }
     void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject!=slider)
        {
            brakingbrick.Play();//sound
        }
        if (other.transform.CompareTag("Brick"))
        {
            /*  int randomChance = Random.Range(1, 101);
            if (randomChance >90)//LifePowerUp Spon
             {
                 Instantiate(LifePowerUp,other.transform.position,other.transform.rotation);
             }*/
            gameManagerScript.UpdateScore(other.gameObject.GetComponent<normalBrick>().points);//add point score
            Destroy(other.gameObject);
            gameManagerScript.UpdateNumberOfBricks();//remove bricks

        }
    }

}
