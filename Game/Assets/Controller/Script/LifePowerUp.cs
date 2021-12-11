using UnityEngine;

public class LifePowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0f,-1f)*Time.deltaTime*3f);//move downword lifePowerUp
        if (transform.position.y <-4.35f)//remove lifePowerUp if miss
        {
            Destroy(gameObject);
        }
    }
    
}
