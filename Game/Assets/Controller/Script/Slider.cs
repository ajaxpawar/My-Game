
using UnityEngine;

public class Slider : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private Camera mainCam;
    private float xSlide;
    private float ySlide;
    public GameManager gameManagerScript; 
    [SerializeField] private float leftWallLimit;
    [SerializeField] private float rightWallLimit;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCam = FindObjectOfType<Camera>();
        ySlide = this.transform.position.y;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerScript.gameOver)
        {
            return;
        }
        movement();
        if (transform.position.x < leftWallLimit)
        {
            transform.position = new Vector2(leftWallLimit, transform.position.y);
        }
        if (transform.position.x > rightWallLimit)
        {
            transform.position = new Vector2(rightWallLimit, transform.position.y);
        }
    }
    void movement()
    {
        xSlide = mainCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0, 0)).x;
        this.transform.position = new Vector3(xSlide, ySlide, 0);
        
    }
}
