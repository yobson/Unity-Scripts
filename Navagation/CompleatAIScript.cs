// James Hobson 2015

//To use:
//Add this script to the thing that will follow the target. also add a Nav mesh agent
//This assunmes that you have baked the navmesh!
//Then add a collider and set to trigger
//Choose the behaviour.
//if you choose damage health you can select the damage.

//Enjoy!! x

using UnityEngine;
using System.Collections;

public class CompleatAIScript : MonoBehaviour {
	
	public GameObject Target;
	public enum actionlist {None = 0, RemoveTarget = 1, DamageHealth = 2};
	public actionlist Payload = actionlist.None;
	public int damage;
	private int selection;
	private bool doDamage = true;
	
	void Awake (){
		selection = Payload.GetHashCode ();
	}
	// Update is called once per frame
	void Update () {
		
		NavMeshAgent agent = GetComponent<NavMeshAgent> ();
		agent.destination = Target.transform.position;
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject != Target) {
			print ("Non player Hit");
			return;
		}
		if (selection == 0) { return; }
		if (selection == 1) { Destroy (Target); }
		if (selection == 2) {  Target.GetComponent<Health>().OtherDamage(damage);}
	}
	
	void hit(){ 
		
		Destroy(gameObject);
		Destroy (Target);
	}
	
	
}
