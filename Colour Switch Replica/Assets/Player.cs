﻿using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce = 10;

    public Rigidbody2D rb;
    public SpriteRenderer sr;

    public string currentColor;

    public Color colorCyan;
	public Color colorYellow;
	public Color colorPurple;
	public Color colorPink;

    	void Start ()
	{
		SetRandomColor();
	}
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") || Input.GetMouseButtonDown (0))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        
    }



		void SetRandomColor ()
	{
		int index = Random.Range(0, 4);

		switch (index)
		{
			case 0:
				currentColor = "Cyan";
				sr.color = colorCyan;
				break;
			case 1:
				currentColor = "Yellow";
				sr.color = colorYellow;
				break;
			case 2:
				currentColor = "Purple";
				sr.color = colorPurple;
				break;
			case 3:
				currentColor = "Pink";
				sr.color = colorPink;
				break;
		}
	}
}
