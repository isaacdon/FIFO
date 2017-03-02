using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class camScript : MonoBehaviour {

	public GameObject radarPlane;

	public Button fireButton;
	public Text ammoText;
	/*public Button weaponF;
	public Button weaponS;*/

	public float fast = 15000f;
	public float slow = 1800f;

	public int bulletCounter;
	public float bulletSpeed;

	// Use this for initialization
	void Start () {
		// preset ammo amount
		bulletCounter = 400;
		//update to main screen
		setAmmoText();

		bulletSpeed = slow;

		fireButton.onClick.AddListener (fireButtonDown);

		/*weaponF.onClick.AddListener (weaponFDown);
		weaponS.onClick.AddListener (weaponSDown);*/

		Debug.Log ("Cam Start");

		StartCoroutine ("EnemyGen");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/*void weaponFDown() {
		Debug.Log ("fast");
		bulletSpeed = fast;
	}

	void weaponSDown() {
		Debug.Log ("slow");
		bulletSpeed = slow;
	}*/

	void fireButtonDown() {
		if (bulletCounter <= 50) {
			//prompt ammo warning
		} 
		if (bulletCounter > 0) {
			Debug.Log ("fire");
			GameObject bullet = Instantiate (Resources.Load ("Bullet", typeof(GameObject))) as GameObject;
			Rigidbody rb = bullet.GetComponent<Rigidbody> ();
			bullet.transform.rotation = Camera.main.transform.rotation;
			bullet.transform.position = Camera.main.transform.position;
			rb.AddForce (Camera.main.transform.forward * bulletSpeed);
			Destroy (bullet, 3);
			//decrement ammo
			bulletCounter -= 1;		
			//update ui counter
			setAmmoText();
		}else {
			//prompt no ammo, self-detroy 
		}


	}


	void setAmmoText(){
		ammoText.text = "Ammo Left: " + bulletCounter.ToString ();
	}

	IEnumerator EnemyGen() {
		Debug.Log ("EnemyGen");

		while (true) {
			yield return new WaitForSeconds (3.5f);

			if (GameObject.FindGameObjectsWithTag ("Enemy").Length == 0) {
				Debug.Log ("== 0");

				GameObject[] enemies = new GameObject[3];

				for (int i = 0; i < enemies.Length; i++) {
					enemies[i] = Instantiate (Resources.Load ("Enemy", typeof(GameObject))) as GameObject;
					float x = Random.Range (-5.0f, 5.0f);
					float y = Random.Range (-5.0f, 5.0f);
					float z = Random.Range (0.0f, 10.0f);

					enemies[i].transform.position = new Vector3 (x, y, z);
				}

			} else {
				Debug.Log ("> 0");
			}
		}
	}
}
