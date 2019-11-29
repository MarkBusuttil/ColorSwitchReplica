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

	List<PlayerColor> colors = new List<PlayerColor>(){ PlayerColor.Cyan, PlayerColor.Yellow, PlayerColor.Pink, PlayerColor.Purple };

    void Start ()
	{
		SetRandomColor();
	}
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") || Input.GetMouseButtonDown (0))
        {
			if (rb.bodyType == RigidbodyType2D.Kinematic)
			{
				rb.bodyType = RigidbodyType2D.Dynamic;
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
			Debug.Log("NICENICENICENICE");
			return;
		}

		if (col.tag == "Score")
		{
			Debug.Log("+1 PT");
			Destroy(col.gameObject);
			return;
		}

		if (col.tag != currentColor.ToString())
		{
			Debug.Log("GAME OVER!");
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
