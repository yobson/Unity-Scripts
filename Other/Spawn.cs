//James Hobson 2014

//To Use: Place on empty GameObject which will be the spawn point and drag from the hierarchy the same GameObject and drop it into the
//Spawn Point variable on the script. Then name the prefab in the resources folder you want to spawn and put the same name into the Name variable
//Put in the centerfrequency into the FrequanceycHz var


using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour 
{
	//The delay
	public float FrequencyHz;
	//This is the string of the prefab name
	public GameObject ThingToSpawn;
	//Spawn Point
	private Transform SpawnPoint;

	public int SpawnTime = 10;
	public int RestTime = 20;
	//Ai
	private GameObject ai;
	private GameObject thing;

	private bool go = false;
	private bool counting = false;
	
	//How to calculate frequancy


	
	void Awake()
	{

		ai = ThingToSpawn;
		InvokeRepeating ("spawn", 0, (1 / FrequencyHz));
		SpawnPoint = gameObject.transform;
	}

	void Update(){
		if (!go && !counting) {
			StartCoroutine(Cool (RestTime));
		}
		if (go && !counting) {
			StartCoroutine(Cool (SpawnTime));
		}
	}

	public void spawn () 
	{
		//print ("Spawn " + FrequencycHz);
		if (go) {thing = (GameObject)Instantiate (ai, SpawnPoint.position, SpawnPoint.rotation);}
	}


	IEnumerator Cool(int coolDown) {
		counting = !counting;
		yield return new WaitForSeconds(coolDown);
		go = !go;
		counting = !counting;
	}


}
