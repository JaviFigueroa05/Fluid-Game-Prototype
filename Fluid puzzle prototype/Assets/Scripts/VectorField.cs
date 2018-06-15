using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorField : MonoBehaviour {

	public GameObject player;
	public Transform field;
	public int vecFieldRes;
	public Transform vector;

	Vector2[,] vecField;
	Vector2 currentVec;
	float angle, alpha;

	// Use this for initialization
	void Start () {
		int vecFieldX = Mathf.CeilToInt(field.localScale.x * vecFieldRes); 
		int vecFieldY = Mathf.CeilToInt(field.localScale.z * vecFieldRes);

		vecField = new Vector2[vecFieldX , vecFieldY];

		for(int i = 0; i < vecFieldX; i++){
			for(int j = 0; j < vecFieldY; j++){
				vecField[i,j] = vectorField(i, j);
			}
		}

		Quaternion q = new Quaternion();
		for (int i = 0; i < field.localScale.x; i++) {
			for (int j = 0; j < field.localScale.z; j++) {
				currentVec = vecField[Mathf.CeilToInt(field.localScale.x * vecFieldRes)-1, Mathf.CeilToInt(field.localScale.y * vecFieldRes)-1];
				if(currentVec.x > 0){
					alpha = Mathf.Atan(currentVec.y/currentVec.x)*180/Mathf.PI;
					angle = 90 - alpha;
				}else{
					alpha = Mathf.Atan(currentVec.y/-currentVec.x)*180/Mathf.PI;
					angle = alpha - 90;
				}	
				q.eulerAngles = new Vector3(0.0f, angle, 0.0f); 
				Instantiate(vector, new Vector3(i + 0.5f, 0.5f, j + 0.5f), q);
			}
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		if(player.transform.position.x < field.localScale.x && player.transform.position.z < field.localScale.z &&
		   player.transform.position.x > 0 && player.transform.position.z > 0){

			currentVec = vecField[Mathf.FloorToInt(player.transform.position.x * vecFieldRes) , 
			  					  Mathf.FloorToInt(player.transform.position.z * vecFieldRes)];

			if(currentVec.x > 0){
				alpha = Mathf.Atan(currentVec.y/currentVec.x)*180/Mathf.PI;
			}else{
				alpha = Mathf.Atan(currentVec.y/-currentVec.x)*180/Mathf.PI;
			}	

			player.transform.Rotate(0.0f * Time.deltaTime, 
									(angle - Mathf.Asin(player.transform.localRotation.y)*360/Mathf.PI) * Time.deltaTime , 
									0.0f * Time.deltaTime);

			player.transform.Translate(currentVec.x * Time.deltaTime, 
									   0.0f * Time.deltaTime, 
							 		   currentVec.y * Time.deltaTime,
									   Space.World);
		}
	}

	Vector2 vectorField(int x, int y){ return new Vector2(x/100, y/100); }
}
