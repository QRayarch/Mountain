using UnityEngine;
using System.Collections;

public class Firefly : MonoBehaviour {

	public float chnageHeadingTime = 0.3f;
	[Range(0, 1)]
	public float newHeadingChance = 0.1f;
	public float speed = 0.2f;
	public float minGroundDistance = 0.4f;
	public float maxGroundDistance = 1.0f;

	private Vector3 newHeading;
	private Vector3 heading;
	private float changeHeadingTimer = 0;
	private Transform trans;

	// Use this for initialization
	void Start () {
		heading = Random.insideUnitSphere;
		newHeading = Random.insideUnitSphere;
		trans = transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(changeHeadingTimer >= chnageHeadingTime) {
			trans.position += newHeading * speed * Time.deltaTime;
		} else {
			trans.position += Vector3.Lerp(heading, newHeading, changeHeadingTimer / chnageHeadingTime) * speed * Time.deltaTime;
		}

		float heightAboverTerrain = trans.position.y - Terrain.activeTerrain.SampleHeight(trans.position);
		if(heightAboverTerrain < minGroundDistance) {
			newHeading.y = Mathf.Abs(newHeading.y);
			changeHeadingTimer = 0;
		}
		if(heightAboverTerrain > maxGroundDistance) {
			newHeading.y = -Mathf.Abs(newHeading.y);
			changeHeadingTimer = 0;
		}

		changeHeadingTimer += Time.deltaTime;
		if(Random.Range(0, 1.0f) <= newHeadingChance) { 
			changeHeadingTimer = 0;
			heading = newHeading;
			newHeading = Random.insideUnitSphere;
		}
	}
}
