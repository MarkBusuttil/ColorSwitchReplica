using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _scoreText;

    public void SetScoreText(int score)
    {
        _scoreText.SetText(score.ToString ());
    }
}
