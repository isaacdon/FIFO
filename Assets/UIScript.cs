using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIScript : MonoBehaviour {

	public Button wepSelect;
	public Button wepBullet;
	public Button wepMissile;
	public Button wepSnapper;

	public bool isSelecting;
	public string weapon;

	// Use this for initialization
	void Start () {
		wepSelectClose ();

		wepSelect.onClick.AddListener (wepSelectDown);
		wepBullet.onClick.AddListener (bulletSelect);
		wepMissile.onClick.AddListener (missileSelect);
		wepSnapper.onClick.AddListener (snapperSelect);


		weapon = "bullet";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void wepSelectDown() {
		if (isSelecting) {
			wepSelectClose ();
		} else {
			wepSelectOpen ();
		}
	}

	void wepSelectOpen() {
		wepBullet.gameObject.SetActive (true);
		wepMissile.gameObject.SetActive (true);
		wepSnapper.gameObject.SetActive (true);

		isSelecting = true;
	}

	void wepSelectClose() {
		wepBullet.gameObject.SetActive (false);
		wepMissile.gameObject.SetActive (false);
		wepSnapper.gameObject.SetActive (false);

		isSelecting = false;
	}

	void bulletSelect() {
		weapon = "bullet";
		wepSelectClose ();
	}

	void missileSelect() {
		weapon = "missile";
		wepSelectClose ();
	}

	void snapperSelect() {
		weapon = "snapper";
		wepSelectClose ();
	}
}
