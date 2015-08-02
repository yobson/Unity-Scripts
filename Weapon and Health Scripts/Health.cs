//James Hobson 2015

//This should come with gun.cs and bullet.cs by me too!
//To use, add to anythinbg that needs health that is changed by ammo
//Set health, thats it!

using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	
	public int StartHealth = 100;
	public string ProjectileTag = "Ammo";
	public GameObject OptionalExplosion = null;
	private int currentHealth;
	
	
	void Start () {
		currentHealth = StartHealth;
	}
	
	void OnTriggerEnter (Collider col) {
		if (col.gameObject.tag == ProjectileTag) {
			int dam = col.gameObject.GetComponent<Bullet>().giveDamage();
			currentHealth = currentHealth - dam;
		}
		if (currentHealth <= 0) {
			die();
		}
	}
	
	public void OtherDamage(int dam) {
		print ("hit");
		currentHealth = currentHealth - dam;
		if (currentHealth <= 0) {
			die();
		}
	}
	public int getCurrentHealth() {
		return currentHealth;
	}
	
	void die() {
		if (gameObject.tag != "Player") {
			ScoreChanger scoreScript = gameObject.GetComponent<ScoreChanger> ();
			if (scoreScript != null) {
				scoreScript.changeScore ();
			}
			if(OptionalExplosion!=null)Instantiate(OptionalExplosion, gameObject.transform.position, Quaternion.identity);
			Destroy (gameObject);
		} else {
			Application.LoadLevel ("GameOverScreen");
		}
	}
}
