using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public Transform travelLocation;
	public bool travelsFriends = false;
	public bool removesItem = false;
	public bool friendsAllFollow = false;
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
			if(removesItem && Camera.main.transform.FindChild("Hand").childCount > 0) {
				Transform item = Camera.main.transform.FindChild("Hand").GetChild(0);
				if(item) {
					Destroy(item.gameObject);
				}
			}
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
			if(friendsAllFollow) {
				GameObject[] friends =  GameObject.FindGameObjectsWithTag("Friend");
				for(int f = 0; f < friends.Length; f++) {
					Destination dest = friends[f].GetComponent<Destination>();
					if(dest != null) {
						dest.useTransform = true;
						dest.transformDest = other.transform;
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
