using UnityEngine;
using System.Collections;

//To Use this script, add it to the main camera in the game. drag the player inot target and select smoothing

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public float smoothing = 5f;

	Vector3 offset;

	void Start ()
	{
		offset = transform.position - target.position;
	}

	void FixedUpdate ()
	{
		Vector3 targetCamPos = target.position + offset;
		transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);
	}
}
