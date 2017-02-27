using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider col) {
		GameObject explosion = Instantiate (Resources.Load ("FlareMobile", typeof(GameObject))) as GameObject;
		explosion.transform.position = transform.position;
		Destroy (col.gameObject);
		Destroy (explosion, 2);

		Destroy (gameObject);
	}
}
