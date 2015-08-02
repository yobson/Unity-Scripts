using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {

	public enum oriantations {TopLeft = 0, TopRight = 1, BottomLeft = 2, BottomRight = 3};
	public enum counterSetting {CountUp, CountDown };

	public bool AmmoCounter = false;
	public oriantations AmmoCounterPos = oriantations.BottomRight;
	//public bool pseudographical = false;

	public bool Health = false;
	public oriantations HealthPos = oriantations.BottomLeft;
	public bool Pseudographical = false;

	public bool Score = false;
	public oriantations ScorePos = oriantations.TopLeft;
	public string ScoreText = "Score:";

	public bool Timer = false;
	public oriantations TimerPos = oriantations.TopRight;
	public counterSetting CounterNature = counterSetting.CountUp;
	public int CountDownFrom;
	public string TimerText = "Time:";

	public Text TopLeftText;
	public Text TopRightText;
	public Text BottomLeftText;
	public Text BottomRightText;
	public GameObject Player;
	public GameObject WeaponManager;

	private int AmmoLeft;
	private int score = 0;
	private float time = 0f;
	private string timeText = "";
	private string healthText = "";
	private string scoreText = "";
	private string ammoText = "";

	private MultiGun WM;

	void Start () {
		WM = WeaponManager.GetComponent<MultiGun> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Timer) { TimerScript (); } 
		if (Health) { healthScript(); }
		if (Score) { scoreScript(); }
		if (AmmoCounter) {ammoScript(); }
	}

	void TimerScript() {
		if (CounterNature == counterSetting.CountUp) {

			time = time + Time.deltaTime;
			timeText = TimerText + " " + Mathf.RoundToInt(time);
		}
		if (CounterNature == counterSetting.CountDown) {
			time = (float)CountDownFrom;
			time = time - Time.deltaTime;
			timeText = TimerText + " " + Mathf.RoundToInt(time);
		}

		switch(TimerPos.GetHashCode()) {
		case(0):
			TopLeftText.text = timeText;
			break;
		case(1):
			TopRightText.text = timeText;
			break;
		case(2):
			BottomLeftText.text = timeText;
			break;
		case(3):
			BottomRightText.text = timeText;
			break;
			}
	}

	void healthScript() {
		int health = Player.GetComponent<Health> ().getCurrentHealth (); 
		int total = Player.GetComponent<Health> ().StartHealth;
		if (Pseudographical) {
			int unit = total / 10;
			int bars = health/unit;
			string partOne = "";
			string partTwo = "";
			for (int i = 0; i < bars; i++) {
				partOne = partOne + "||";
			}
			for (int i = 0; i < 10-bars; i++) {
				partTwo = partTwo + "  ";
			}
			healthText = "Health: [" + partOne + partTwo + "]";
		} else {
			healthText = "Health: "+ health+ " / " + total;
		}
		switch(HealthPos.GetHashCode()) {
		case(0):
			TopLeftText.text = healthText;
			break;
		case(1):
			TopRightText.text =healthText;
			break;
		case(2):
			BottomLeftText.text = healthText;
			break;
		case(3):
			BottomRightText.text = healthText;
			break;
		}
	}

	void scoreScript () {
		scoreText = ScoreText + " " + score;
		switch(ScorePos.GetHashCode()) {
		case(0):
			TopLeftText.text = scoreText;
			break;
		case(1):
			TopRightText.text = scoreText;
			break;
		case(2):
			BottomLeftText.text = scoreText;
			break;
		case(3):
			BottomRightText.text = scoreText;
			break;
		}
	}

	public void addToScore(int value) {
		score = score + value;
	}

	void ammoScript() {
		ammoText = "Ammo:" + WM.returnAmmoInCurrentGun ();
		switch(AmmoCounterPos.GetHashCode()) {
		case(0):
			TopLeftText.text = ammoText;
			break;
		case(1):
			TopRightText.text = ammoText;
			break;
		case(2):
			BottomLeftText.text = ammoText;
			break;
		case(3):
			BottomRightText.text = ammoText;
			break;
		}
	}
}


