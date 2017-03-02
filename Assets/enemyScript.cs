using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour {

	public float speed;
	public float goTime;
	public float goAngel;
	public float climbAngel;
	public int directionxy;
	public int directionz;
	public float boundayX=30;
	public float boundayY=30;
	public float boundayZ=30;

	// Use this for initialization
	void Start () {
		Debug.Log (GetComponent <EnemyObject>().hp);
		StartCoroutine ("Move");
	}

	// Update is called once per frame
	void Update () {
		speed = Random.Range (3f, 10f);
		transform.Translate (Vector3.forward * speed * Time.deltaTime); // speed

	}

	IEnumerator Move() {
		directionxy = Random.Range (0,2); 
		directionz = Random.Range (0,2); 
		while (true) {
			Debug.Log (transform.position);
			goTime = Random.Range (0f, 2f);
			yield return new WaitForSeconds (goTime); // go streight until time out
			if (directionxy==0){
				goAngel = Random.Range (-4f, 60f);
			}
			else{
				goAngel = Random.Range (-60f, 4f);
			}
			if (directionz==0){
				climbAngel = Random.Range (-1f, 5f);
			}
			else{
				climbAngel = Random.Range (-5f, 1f);
			}
//			transform.eulerAngles += new Vector3 (0, goAngel, climbAngel);// angle change

			if (transform.position.x>=50 || transform.position.y>=50 ||transform.position.z>=50){
				transform.eulerAngles += new Vector3 (0, -goAngel, -climbAngel);// angle change
			}


			if (Mathf.Abs(transform.position.x)>=boundayX||Mathf.Abs(transform.position.y)>=boundayY||Mathf.Abs(transform.position.z)>=boundayZ){
//				Debug.Log ("out of bound");
//				Vector3 newPosition = new Vector3(0f, 0f, 0f);
//				float step = 5f * Time.deltaTime;
//				transform.position = Vector3.MoveTowards(transform.position, newPosition, 7f)

//				Vector3 firstPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
//				Vector3 secondPosition = new Vector3(0f, 0f, 0f);
//
//				while( Mathf.Abs(transform.position.x)>10 || Mathf.Abs(transform.position.y)>10 || Mathf.Abs(transform.position.z)>10)
//				{	
//					if (transform.position.x > 10) {
//						transform.position = new Vector3 (transform.position.x - 0.001f, transform.position.y, transform.position.z);
//					}
//					else if (transform.position.y > 10){
//						transform.position = new Vector3(transform.position.x, transform.position.y- 0.001f, transform.position.z);
//					}
//					else if (transform.position.z > 10){
//						transform.position = new Vector3(transform.position.x , transform.position.y, transform.position.z- 0.001f);
//					}
//					else if (transform.position.x < -10){
//						transform.position = new Vector3(transform.position.x + 0.001f, transform.position.y, transform.position.z);
//					}
//					else if (transform.position.y < -10){
//						transform.position = new Vector3(transform.position.x, transform.position.y+ 0.001f, transform.position.z);
//					}
//					else if (transform.position.z < -10){
//						transform.position = new Vector3(transform.position.x , transform.position.y, transform.position.z+ 0.001f);
//					}
//				}
			}
		}
	}
}
