using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {
    public float speed;
    public float jump;

    public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float flyMode = Input.GetAxis("Submit");
        
        //move player acording to input
        if (flyMode == 0)
        {
            vertical = 0;
            rb.gravityScale = 2;
        }
        else
        {
            rb.gravityScale = 0;
        }

        if (vertical == 1)
        {

        }

        Vector2 movement = new Vector2(horizontal, vertical);

        rb.AddForce(movement * speed);
    }
}