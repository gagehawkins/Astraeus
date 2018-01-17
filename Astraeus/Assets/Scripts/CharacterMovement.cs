using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {
    public float speed;
    public float jumpStrength;

    public Rigidbody2D rb;

    LayerMask jumpCollider;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();

        jumpCollider = LayerMask.NameToLayer("Middleground");
        //Debug.Log("LayerINT = " + jumpCollider.value);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 lineStart = new Vector2(transform.position.x, transform.position.y - 1);
        Vector2 lineEnd = new Vector2(transform.position.x, transform.position.y - 2);

        Vector2 movement = new Vector2(horizontal, 0);
        //Debug.Log(jumpCollider.value << 9);
        //Send Linecast below character to ground
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, Mask.value);
        RaycastHit2D hit = Physics2D.Linecast(lineStart, lineEnd, jumpCollider.value << 9);

        //Debug.DrawRay(lineStart, Vector3.down, Color.blue, 1);

        //Test if Linecast hit ground
        if (hit.collider != null && hit.collider.tag == "Jump")
        {
            //Debug.Log("Colliding with = " + hit.collider.name);
            //Debug.Log("Has Tag = " + hit.collider.tag);
            //Debug.Log("Distance = " + hit.distance);
            //Test if player is on ground
            if (hit.distance <= 0.05)
            {
                if (vertical > 0)
                {
                    //Make character jump
                    rb.AddForce(Vector2.up * (jumpStrength * 100));
                    //Debug.Log("Ground Distance = " + hit.distance);
                }

                //Move character
                rb.AddForce(movement * speed);
            }
        }
    }
}