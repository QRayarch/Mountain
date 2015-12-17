using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public Transform travelLocation;
	public bool travelsFriends = false;
	public RandomWalk possibleWalk;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if(other.CompareTag("Player")) {
			other.transform.position = travelLocation.position;
			if(travelsFriends) {
				GameObject[] friends =  GameObject.FindGameObjectsWithTag("Friend");
				Debug.Log(friends.Length);
				for(int f = 0; f < friends.Length; f++) {
					NavMeshAgent agent = friends[f].GetComponent<NavMeshAgent>();
					if(agent != null) {
						agent.enabled = false;
					}
					friends[f].transform.position = travelLocation.position;
					if(agent != null) {
						agent.enabled = true;
					}
					Destination dest = friends[f].GetComponent<Destination>();
					if(possibleWalk != null && dest != null) {
						possibleWalk.AddDest(dest);
					}
				}
			}
		}
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube(transform.position, transform.localScale);
		if(travelLocation != null) {
			Gizmos.DrawLine(transform.position, travelLocation.position);
			Gizmos.color = Color.red;
			Gizmos.DrawWireCube(travelLocation.position, travelLocation.localScale);
		}
	}
}
