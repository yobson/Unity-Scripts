//James Hobosn 2015
//This script is to be used with health and Health.cs and Bullet.cs written by James too
//To use, create a empty game object and add this script to it. Place this on the muzzel of the gun
//Make sure the gun is its parent in the hiarachy. Add the bullet prefab (Instructions in Bullet.cs)
//The drop down power will affect the amount of damage each bullet will do.
//The Automatic checkbox will make it automatic
//The Checkbox will switch between unlimited ammop and a limited clip size.
//Size of clip will determin how much ammo the gun has max
//Cool down will determin how long it is until the gun can shoot again
//Bullet is where you drag the bullet prefab

using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {
	
	public enum PowerList {VerySmall = 2, Small = 5, Medium = 10, Large = 15, VeryLarge = 20 }
	public PowerList Power = PowerList.Medium;
	
	public bool Automatic = false;
	
	public bool UnlimitedAmmo = true;
	
	public int ClipSizeIfLimited = 40;
	
	public float CoolDown;
	
	public GameObject Bullet;
	
	private Transform Spawn;
	private int damage;
	private int clip;
	private bool canShoot = true;
	// Use this for initialization
	void Start () {
		Spawn = gameObject.transform;
		damage = Power.GetHashCode ();
		clip = ClipSizeIfLimited;
		GUIUpdate ();
	}
	
	// Update is called once per frame
	void Update () {
		if (canShoot) {
			if (Input.GetButtonDown ("Fire1") && !Automatic) {
				if (UnlimitedAmmo) {
					Fire ();
				}
				if (!UnlimitedAmmo) {
					if (clip > 0) {
						Fire ();
						clip --;
						GUIUpdate ();
					}
				}
				
			}
			if (Input.GetButton ("Fire1") && Automatic) {
				if (UnlimitedAmmo) {
					Fire ();
				}
				if (!UnlimitedAmmo) {
					if (clip > 0) {
						Fire ();
						clip --;
						GUIUpdate ();
					}
				}
				
			}
		}
	}
	
	void Fire() {
		if (CoolDown != 0) { StartCoroutine(CoolGun(CoolDown)); }
		GameObject bul = (GameObject)Instantiate (Bullet, Spawn.position, Spawn.rotation);
		bul.GetComponent<Rigidbody> ().AddForce (transform.forward * 8000);
		bul.GetComponent<Bullet> ().setDamage (damage);
	}
	
	void GUIUpdate() {
		GUI.Label(new Rect(10,10,100,30),"Bullets Left: "+clip.ToString());
	}
	
	public void reload(int percent) {
		clip = clip + ((ClipSizeIfLimited * percent)/100);
		if (clip > ClipSizeIfLimited) { clip = ClipSizeIfLimited; }
	}
	
	IEnumerator CoolGun(float coolDown) {
		canShoot = !canShoot;
		yield return new WaitForSeconds(coolDown);
		canShoot = !canShoot;
	}
	
}
