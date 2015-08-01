//James Hobson 2015

//This should come with gun.cs and bullet.cs by me too!
//To use, add to anythinbg that needs health that is changed by ammo
//Set health, thats it!

using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	
	public int StartHealth = 100;
	public string ProjectileTag = "Ammo";
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
			Destroy(gameObject);
		}
	}
	
	public void OtherDamage(int dam) {
		print ("hit");
		currentHealth = currentHealth - dam;
		if (currentHealth <= 0) {
			Destroy(gameObject);
		}
	}
}
