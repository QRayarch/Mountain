using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomWalk : MonoBehaviour {

	public List<Destination> destinations = new List<Destination>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		for(int d = 0; d < destinations.Count; d++) {
			//destinations[d].useTransform = false;
			if(destinations[d].Agent.velocity.magnitude <= 0) {
				SetNewDest(destinations[d]);
			}
		}
	}

	private void SetNewDest(Destination dest, bool mustRandom = false) {
		if(mustRandom || Random.Range(0, 300) < 5) {
			Vector3 halfScale = transform.localScale / 2.0f;
			dest.destination = new Vector3(Random.Range(-halfScale.x, halfScale.x), 0.0f, Random.Range(-halfScale.z, halfScale.z)) + transform.position;
		}
	}

	public void AddDest(Destination dest) {
		dest.useTransform = false;
		destinations.Add(dest);
		SetNewDest(dest, true);
	}

	public void RemoveAll() {
		for(int d = 0; d < destinations.Count; d++) {
			destinations[d].useTransform = true;
		}
		destinations.Clear();
	}

	void OnTriggerEnter(Collider other) {
		Destination dest = other.gameObject.GetComponent<Destination>();
		if(dest != null) {
			AddDest(dest);
		}
	}

	void OnTriggerExit(Collider other) {
		Destination dest = other.gameObject.GetComponent<Destination>();
		if(dest != null) {
			dest.useTransform = true;
			destinations.Remove(dest);
		}
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.magenta;
		for(int d = 0; d < destinations.Count; d++) {
			Gizmos.DrawWireSphere(destinations[d].destination, 0.3f);
		}
	}
}
