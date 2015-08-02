using UnityEngine;
using System.Collections;

public class ScoreChanger : MonoBehaviour {

	public enum TriggerOptions { OnTrigger = 0, OnDeath = 1 };
	public TriggerOptions Trigger = TriggerOptions.OnTrigger;
	public int ChangeScoreBy = 10;
	public bool DestroyAfterChange = true;
	public GameObject HUDObject;
	public GameObject Player;
	// Use this for initialization

	void OnTriggerEnter (Collider col) {
		if (col.gameObject == Player && Trigger.GetHashCode() == 0) {
			changeScore();
			if (DestroyAfterChange) { Destroy (gameObject); }
		}
	}

	public void changeScore() {
		HUDObject.GetComponent<HUDManager> ().addToScore (ChangeScoreBy);
	}
}
