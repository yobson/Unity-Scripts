//James Hobson 2015

//This is to be used with Gun.cs, Health.cs and bullet.cs. This is a weapon selector
//To use, create empty game object and drag on this script
//place every gun model you want it possible to have set up with the Gunscript to player
//Tick the boxes of all the guns you want avalable when the game starts
//drag the gun game object from hierachy to the responding Gun$Object variable

//MAKE SURE COLLIDERS ARE OFF!

using UnityEngine;
using System.Collections;

public class MultiGun : MonoBehaviour {
	
	public bool Gun1 = true;
	public GameObject Gun1Object;
	public bool Gun2 = false;
	public GameObject Gun2Object;
	public bool Gun3 = false;
	public GameObject Gun3Object;
	public bool Gun4 = false;
	public GameObject Gun4Object;
	public bool Gun5 = false;
	public GameObject Gun5Object;
	public bool Gun6 = false;
	public GameObject Gun6Object;
	public bool Gun7 = false;
	public GameObject Gun7Object;
	
	void Start () {
		try { activate(Gun1Object); } catch {}
		try { deactivate(Gun2Object); } catch {}
		try { deactivate(Gun3Object); } catch {}
		try { deactivate(Gun4Object); } catch {}
		try { deactivate(Gun5Object); } catch {}
		try { deactivate(Gun6Object); } catch {}
		try { deactivate(Gun7Object); } catch {}
	}
	
	// Update is called once per frame
	void Update () {
		loop ();
	}
	
	void loop() {
		if (Input.GetKeyDown (KeyCode.Alpha1) ) {
			if (Gun1) { activate(Gun1Object); }
			if (Gun2) { deactivate(Gun2Object); }
			if (Gun3) { deactivate(Gun3Object); }
			if (Gun4) { deactivate(Gun4Object); }
			if (Gun5) { deactivate(Gun5Object); }
			if (Gun6) { deactivate(Gun6Object); }
			if (Gun7) { deactivate(Gun7Object); }
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			if (Gun1) { deactivate(Gun1Object); }
			if (Gun2) { activate(Gun2Object); }
			if (Gun3) { deactivate(Gun3Object); }
			if (Gun4) { deactivate(Gun4Object); }
			if (Gun5) { deactivate(Gun5Object); }
			if (Gun6) { deactivate(Gun6Object); }
			if (Gun7) { deactivate(Gun7Object); }
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			if (Gun1) { deactivate(Gun1Object); }
			if (Gun2) { deactivate(Gun2Object); }
			if (Gun3) { activate(Gun3Object); }
			if (Gun4) { deactivate(Gun4Object); }
			if (Gun5) { deactivate(Gun5Object); }
			if (Gun6) { deactivate(Gun6Object); }
			if (Gun7) { deactivate(Gun7Object); }
		}
		if (Input.GetKeyDown (KeyCode.Alpha4)) {
			if (Gun1) { deactivate(Gun1Object); }
			if (Gun2) { deactivate(Gun2Object); }
			if (Gun3) { deactivate(Gun3Object); }
			if (Gun4) { activate(Gun4Object); }
			if (Gun5) { deactivate(Gun5Object); }
			if (Gun6) { deactivate(Gun6Object); }
			if (Gun7) { deactivate(Gun7Object); }
		}
		if (Input.GetKeyDown (KeyCode.Alpha5)) {
			if (Gun1) { deactivate(Gun1Object); }
			if (Gun2) { deactivate(Gun2Object); }
			if (Gun3) { deactivate(Gun3Object); }
			if (Gun4) { deactivate(Gun4Object); }
			if (Gun5) { activate(Gun5Object); }
			if (Gun6) { deactivate(Gun6Object); }
			if (Gun7) { deactivate(Gun7Object); }
		}
		if (Input.GetKeyDown (KeyCode.Alpha6)) {
			if (Gun1) { deactivate(Gun1Object); }
			if (Gun2) { deactivate(Gun2Object); }
			if (Gun3) { deactivate(Gun3Object); }
			if (Gun4) { deactivate(Gun4Object); }
			if (Gun5) { deactivate(Gun5Object); }
			if (Gun6) { activate(Gun6Object); }
			if (Gun7) { deactivate(Gun7Object); }
		}
		if (Input.GetKeyDown (KeyCode.Alpha7)) {
			if (Gun1) { deactivate(Gun1Object); }
			if (Gun2) { deactivate(Gun2Object); }
			if (Gun3) { deactivate(Gun3Object); }
			if (Gun4) { deactivate(Gun4Object); }
			if (Gun5) { deactivate(Gun5Object); }
			if (Gun6) { deactivate(Gun6Object); }
			if (Gun7) { activate(Gun7Object); }
		}
	}
	
	void activate(GameObject gun) {
		gun.GetComponent<MeshRenderer> ().enabled = true;
		gun.GetComponentInChildren<Gun> ().enabled = true;
		//gun.GetComponentInChildren<Collider> ().enabled = true;
	}
	
	void deactivate(GameObject gun) {
		gun.GetComponent<MeshRenderer> ().enabled = false;
		gun.GetComponentInChildren<Gun> ().enabled = false;
		//gun.GetComponentInChildren<Collider> ().enabled = false;
	}
}
