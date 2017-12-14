using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform player;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {    
        //Makes camera follow player
        transform.position = new Vector3(player.position.x, player.position.y, -10);
	}
}
