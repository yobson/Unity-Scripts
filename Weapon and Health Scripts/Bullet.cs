//James Hobson 2015

//Comes with Health.cs and gun.cs also by me.
//Too use, model a bullet, add to it a ridgid body, the default settings are find.
//If there is no mesh, add an aproproate one. Made sure that there are not two meshes, and
//that they are set to triggers.
//add this script.
//Save as prefab by dragging off the herachy into a folder.


using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{
	public GameObject OptionalExplosion = null;

	private int damage;

	void Update () 
	{
		//if the AutoDestruct() method isn't already being invoked
		if(!IsInvoking("AutoDestruct"))
		{
			//schedule the execution of the AutoDestruct() method to happen in the next 3 seconds
			Invoke("AutoDestruct",3);
		}
	
	}
	
	//destroys the game object
	void AutoDestruct()
	{
		Destroy(gameObject);
	}
	void OnTriggerEnter(Collider col) {
		if(OptionalExplosion!=null)Instantiate(OptionalExplosion, gameObject.transform.position, Quaternion.identity);
		Destroy (gameObject);
	}

	public void setDamage(int dam) {
		damage = dam;
	}
	public int giveDamage() {
		return damage;
	}
}
