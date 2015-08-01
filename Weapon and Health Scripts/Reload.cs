using UnityEngine;
using System.Collections;

public class Reload : MonoBehaviour {

	public bool OneShot = true;
	public bool Respwan = false;
	public int SecsBeforeRespwn = 60;
	public int PercentToAdd = 100;

	public GameObject Player;

	public bool Gun1 = true;
	public bool Gun2 = true;
	public bool Gun3 = true;
	public bool Gun4 = true;
	public bool Gun5 = true;
	public bool Gun6 = true;
	public bool Gun7 = true;

	public GameObject WeaponManager;


	void OnTriggerEnter(Collider col) {
		if (col.gameObject == Player) {
			MultiGun PlayerInfo = WeaponManager.GetComponent<MultiGun>();
			if (PlayerInfo.Gun1 && Gun1) { PlayerInfo.Gun1Object.GetComponentInChildren<Gun>().reload(PercentToAdd); }
			if (PlayerInfo.Gun2 && Gun2) { PlayerInfo.Gun2Object.GetComponentInChildren<Gun>().reload(PercentToAdd); }
			if (PlayerInfo.Gun3 && Gun3) { PlayerInfo.Gun3Object.GetComponentInChildren<Gun>().reload(PercentToAdd); }
			if (PlayerInfo.Gun4 && Gun4) { PlayerInfo.Gun4Object.GetComponentInChildren<Gun>().reload(PercentToAdd); }
			if (PlayerInfo.Gun5 && Gun5) { PlayerInfo.Gun5Object.GetComponentInChildren<Gun>().reload(PercentToAdd); }
			if (PlayerInfo.Gun6 && Gun6) { PlayerInfo.Gun6Object.GetComponentInChildren<Gun>().reload(PercentToAdd); }
			if (PlayerInfo.Gun7 && Gun7) { PlayerInfo.Gun7Object.GetComponentInChildren<Gun>().reload(PercentToAdd); }
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
