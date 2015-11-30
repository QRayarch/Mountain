using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public Transform travelLocation;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if(other.CompareTag("Player")) {
			other.transform.position = travelLocation.position;
		}
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube(transform.position, transform.localScale);
		if(travelLocation != null) {
			Gizmos.color = Color.red;
			Gizmos.DrawWireCube(travelLocation.position, travelLocation.localScale);
		}
	}
}
