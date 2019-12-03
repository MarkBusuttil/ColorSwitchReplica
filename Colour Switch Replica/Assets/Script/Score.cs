using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // [SerializeField]
    // public Transform player;
    public Text scoreText;
    public int score;

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
        scoreText.text = score.ToString ();

    }
    // public void SetScoreText(int Score)
    // {
    //     scoreText.text = Score.ToString ();
    // }



    // public void SetScoreText(int score)
    // {
    //     _scoreText.SetText(score.ToString ());
    // }
}
