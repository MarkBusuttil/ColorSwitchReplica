using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public static bool GameOver = false;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalScoreText;
    public int score;

    public TextMeshProUGUI highscoreText;
    public int totalhighscore;

    public GameObject gameOverScreen;

    void Start ()
    {
        score = 0;
        SetScoreText ();
    }

    public void SetScore(int score)
    {
        this.score = score;
        SetScoreText();
    }
    
        void SetScoreText ()
    {
        scoreText.SetText(score.ToString ());

    }

    public void AddHighscore()
    {

        if(score>= totalhighscore)
        {
            totalhighscore = score;
        }
        
        highscoreText.SetText(totalhighscore.ToString());
    }

    public void DoGameOver()
    {
        AddHighscore();
        GameIsPaused = true; 
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
        finalScoreText.SetText(score.ToString());
        finalScoreText.SetText(totalhighscore.ToString());
    }
    
}