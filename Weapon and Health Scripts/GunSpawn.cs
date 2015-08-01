//James Hobson 2015

//This is a spawn point for weapons. Use it with Gun.cs, Bullet.cs, Weapon.cs, MultiGun.cs
//and reload.cs all written by me
//To Use, make sure that the player has a collider
//Make a physical spawn point and add this script
//One Shot, when true means that spawn point will disapear after use
//If Respawn is true, after a certain amount of seconds (SecsBeforeRespwn) it will respawn
//The Gun lost desined which weapon it will enable
//Player is the player that can take the gun
//Weapon manager is where you drag the gameobject with MultiGun.cs attached

//Enjoy x

using UnityEngine;
using System.Collections;

public class GunSpawn : MonoBehaviour {

	public enum GunList {One = 1, Two = 2, Three = 3, Four = 4, Five = 5, Six = 6, Seven = 7};

	public bool OneShot = true;
	public bool Respwan = false;
	public int SecsBeforeRespwn = 60;
	
	public GunList Gun = GunList.One;
	public GameObject Player;
	public GameObject WeaponManager;

	void OnTriggerEnter(Collider col) {
		if (col.gameObject == Player) {
			MultiGun PlayerInfo = WeaponManager.GetComponent<MultiGun>();
			switch (Gun.GetHashCode()) {
			case 1:
				PlayerInfo.Gun1 = true;
				break;
			case 2:
				PlayerInfo.Gun2 = true;
				break;
			case 3:
				PlayerInfo.Gun3 = true;
				break;
			case 4:
				PlayerInfo.Gun4 = true;
				break;
			case 5:
				PlayerInfo.Gun5 = true;
				break;
			case 6:
				PlayerInfo.Gun6 = true;
				break;
			case 7:
				PlayerInfo.Gun7 = true;
				break;
			}
			if (OneShot && !Respwan) { Destroy(gameObject); }
			if (OneShot && Respwan) { 
				gameObject.GetComponent<Collider>().enabled = false;
				gameObject.GetComponent<MeshRenderer>().enabled = false;
				StartCoroutine(respawn());
			}

		}
	}

	IEnumerator respawn() {
		yield return new WaitForSeconds(SecsBeforeRespwn);
		gameObject.GetComponent<Collider>().enabled = true;
		gameObject.GetComponent<MeshRenderer>().enabled = true;
	}
	
}
