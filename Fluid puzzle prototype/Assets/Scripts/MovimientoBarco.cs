using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoBarco : MonoBehaviour {

	public float boatSpeed;

	void OnTriggerEnter(Collider collision) {
		if(collision.tag == "Goal"){ Debug.Log("Goal"); }

		if(collision.tag == "Obstacle"){ boatSpeed = 0.0f; }
	}
}
