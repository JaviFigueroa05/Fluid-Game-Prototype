using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoBarco : MonoBehaviour {

	public float boatSpeed;

	void OnTriggerEnter(Collider collision) {
		if(collision.tag == "Goal"){ Debug.Log("Goal"); }

		if(collision.tag == "Obstacle"){ 
			Debug.Log("Obstacle"); 
			boatSpeed = 0.0f;
		}
	}

	// Update is called once per frame
	void Update () {
		transform.Translate(0*boatSpeed*Time.deltaTime, 
							0*boatSpeed*Time.deltaTime, 
							1.0f*boatSpeed*Time.deltaTime);
	}
}
