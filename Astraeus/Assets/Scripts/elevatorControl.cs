using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevatorControl : MonoBehaviour {
    float elevatorCooldown;

    //float Distance;
    LayerMask elevator;

    // Use this for initialization
    void Start () {
        elevator = LayerMask.NameToLayer("Elevator");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        if (elevatorCooldown != 0)
        {
            elevatorCooldown--;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        float elevatorControl = Input.GetAxis("elevatorControl");
        Debug.Log(elevatorControl);
        //float moveChange;

        Vector2 rayDownStart = new Vector2(transform.position.x, transform.position.y - 2);
        Vector2 rayDownEnd = new Vector2(transform.position.x, transform.position.y - 10);
        Vector2 rayUpStart = new Vector2(transform.position.x, transform.position.y + 2);
        Vector2 rayUpEnd = new Vector2(transform.position.x, transform.position.y + 10);
        //Vector2 newElevator = new Vector2(0, 0);
        //Debug.Log(elevator.value << 10);
        if (elevatorControl < 0 && elevatorCooldown == 0)
        {
            RaycastHit2D downHit = Physics2D.Linecast(rayDownStart, rayDownEnd, elevator.value << 10);
            if (downHit.collider != null)
            {

                Debug.Log("down");
                Vector2 newElevator = new Vector2(downHit.transform.position.x, downHit.transform.position.y);
                Debug.Log(newElevator);
                collision.transform.position = newElevator;
                elevatorCooldown = 100;
            }
        }
        else if (elevatorControl > 0 && elevatorCooldown == 0)
        {
            RaycastHit2D upHit = Physics2D.Linecast(rayUpStart, rayUpEnd, elevator.value << 10);
            if (upHit.collider != null)
            {
                Debug.Log("up");
                Vector2 newElevator = new Vector2(upHit.transform.position.x, upHit.transform.position.y);
                Debug.Log(newElevator);
                collision.transform.position = newElevator;
                elevatorCooldown = 100;
            }
        }
    }
}
