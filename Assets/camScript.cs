using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class camScript : MonoBehaviour {

	public Button fireButton;

	// Use this for initialization
	void Start () {
		fireButton.onClick.AddListener (fireButtonDown);
		StartCoroutine ("EnemyGen");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void fireButtonDown() {
		GameObject bullet = Instantiate (Resources.Load ("Bullet", typeof(GameObject))) as GameObject;
		Rigidbody rb = bullet.GetComponent<Rigidbody> ();
		bullet.transform.rotation = Camera.main.transform.rotation;
		bullet.transform.position = Camera.main.transform.position;
		rb.AddForce (Camera.main.transform.forward * 1500f);
		Destroy (bullet, 3);
	}

	IEnumerator EnemyGen() {
		Random random = new Random ();

		while (true) {
			yield return new WaitForSeconds (3.5f);

			if (GameObject.FindGameObjectsWithTag ("Enemy").Length == 0) {
				Debug.Log ("== 0");

				GameObject enemy1 = Instantiate (Resources.Load ("Enemy", typeof(GameObject))) as GameObject;
				GameObject enemy2 = Instantiate (Resources.Load ("Enemy", typeof(GameObject))) as GameObject;

				GameObject[] enemies = { enemy1, enemy2 };

				for (int i = 0; i < 2; i++) {
					float x = Random.Range (-5.0f, 5.0f);
					float y = Random.Range (-5.0f, 5.0f);
					float z = Random.Range (0.0f, 20.0f);

					enemies[i].transform.position = new Vector3 (x, y, z);
				}

			} else {
				Debug.Log ("> 0");
			}
		}
	}
}
