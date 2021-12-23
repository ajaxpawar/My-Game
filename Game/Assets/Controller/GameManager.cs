using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int lives,score;
    [SerializeField] private Text livesText;
    [SerializeField] private Text scoreText;
    public bool gameOver;
    public GameObject GameOverPanal;
    public GameObject NextLevelPanal;
    public Transform[] levels;
    private int curruntLevelIndex=0;
    int nuberOfBricks;
    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
        score = 0;
        livesText.text = "Lives: " + lives;
        scoreText.text = "Score: " + score;
        nuberOfBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateLives(int changeInLives)
    {
        lives = lives + changeInLives;
        //check the lives=0 and end game 
        if (lives <= 0)
        {
            lives = 0;
            GameOver();
        }
        livesText.text = "Lives: " + lives;
    }
    public void UpdateScore(int points)
    {
        score = score + points;
        scoreText.text = "Score: " + score;
    }
    public void GameOver()
    {
        gameOver = true;
        GameOverPanal.SetActive(true);
    }
    public void TryAgain()
    {
        SceneManager.LoadScene("Main");
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Game Over");
    }
    public void NextLevel()
    {
        NextLevelPanal.SetActive(false);
        curruntLevelIndex++;
        Instantiate(levels[curruntLevelIndex], Vector2.zero, Quaternion.identity);
        nuberOfBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
        gameOver = false;
    }
    public void UpdateNumberOfBricks()
    {
        nuberOfBricks--;
        if (nuberOfBricks <= 0)
        {
            if (curruntLevelIndex >= (levels.Length - 1))
            {
                GameOver();
            }
            else
            {
                gameOver = true;
                NextLevelPanal.SetActive(true);
            }
        }
    } 
}