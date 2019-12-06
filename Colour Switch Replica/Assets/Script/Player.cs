using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum PlayerColor
{
	Cyan, Yellow, Purple, Pink
}

public class Player : MonoBehaviour
{
    public float jumpForce = 10;

    public Rigidbody2D rb;
    public SpriteRenderer sr;

    public PlayerColor currentColor;

    public Color colorCyan;
	public Color colorYellow;
	public Color colorPurple;
	public Color colorPink;

	private bool _hasGameStarted = false;

	List<PlayerColor> colors = new List<PlayerColor>(){ PlayerColor.Cyan, PlayerColor.Yellow, PlayerColor.Pink, PlayerColor.Purple };

	Score score;

    void Start ()
	{
		SetRandomColor();
		score = GetComponent<Score>();
	}
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") )
        {
			if (rb.bodyType == RigidbodyType2D.Kinematic && _hasGameStarted == false)
			{
				rb.bodyType = RigidbodyType2D.Dynamic;
				_hasGameStarted = true;
			}
            rb.velocity = Vector2.up * jumpForce;
        }
        
    }

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "ColorChanger")
		{
			SetRandomColor();
			Destroy(col.gameObject);
			return;
		}

		if (col.tag == "FinishLine")
		{
			score.DoGameOver();
			// stop the game
			return;
		}

		if (col.tag == "Score")
		{
			Debug.Log("+1 PT");
			score.SetScore(score.score + 1);
			Destroy(col.gameObject);
			return;
		}

		if (col.tag != currentColor.ToString())
		{
			score.DoGameOver();
		}
	}

		void SetRandomColor ()
	{
		int index = Random.Range(0, colors.Count);
		PlayerColor newColor = colors[index];

		colors.Remove(newColor);
		if (!colors.Contains(currentColor)) colors.Add(currentColor);

		currentColor = newColor;

		switch (currentColor)
		{
			case PlayerColor.Cyan:
				sr.color = colorCyan;
				break;
			case PlayerColor.Yellow:
				sr.color = colorYellow;
				break;
			case PlayerColor.Purple:
				sr.color = colorPurple;
				break;
			case PlayerColor.Pink:
				sr.color = colorPink;
				break;
		}
	}
}
