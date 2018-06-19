using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float playerSpeed;

	void OnTriggerEnter(Collider collision) {
		if(collision.tag == "Goal"){ Debug.Log("Goal"); }

		if(collision.tag == "Obstacle"){ playerSpeed = 0.0f; }
	}

	public void move(Vector2 currentVec, float angle){

		this.transform.Rotate(0.0f * Time.deltaTime, 
							 (angle - Mathf.Asin(this.transform.localRotation.y)*360/Mathf.PI) * Time.deltaTime , 
							 0.0f * Time.deltaTime);

		this.transform.Translate(currentVec.x * Time.deltaTime * playerSpeed, 
								 0.0f * Time.deltaTime * playerSpeed, 
								 currentVec.y * Time.deltaTime * playerSpeed,
								 Space.World);
	}
}
