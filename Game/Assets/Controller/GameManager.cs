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
    public Text highScoreText;
   // public Text menuHighScoreText;
    private AudioSource backgroundAudio;
    //private AudioSource gameOverAudio ;
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
     //   menuHighScoreText = highScoreText;
        backgroundAudio = GetComponent<AudioSource>();
       // gameOverAudio = GetComponent<AudioSource>();
        backgroundAudio.Play();//sound

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
        backgroundAudio.Stop();
      //  gameOverAudio.Play();
        gameOver = true;
        GameOverPanal.SetActive(true);
        int highScore = PlayerPrefs.GetInt("HIGHSCORE");
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HIGHSCORE", score);
            highScoreText.text = "NEW HIGH SCORE: " + score;
        }
        else
        {
            highScoreText.text = "HIGH SCORE: " + highScore+"\n\n"+"Can You Set New Record";

        }
    }
    public void TryAgain()
    {
        SceneManager.LoadScene("Main");
    }
    public void Quit()
    {

        SceneManager.LoadScene("Menu");
    }
    public void NextLevel()
    {
        NextLevelPanal.SetActive(false);
        curruntLevelIndex++;
        Instantiate(levels[curruntLevelIndex], Vector2.zero, Quaternion.identity);
        nuberOfBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
        UpdateLives(1);
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
