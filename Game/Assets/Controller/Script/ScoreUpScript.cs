using UnityEngine;

public class ScoreUpScript : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0f,-1f)*Time.deltaTime*3f);//move downword ScoreUp
        if (transform.position.y <-4.35f)//remove ScroeUp if miss
        {
            Destroy(gameObject);
        }
    }
    
}
