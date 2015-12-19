using UnityEngine;
using System.Collections;

public class DoorBust : MonoBehaviour {

	[Header("Setup")]
	public Rigidbody doorToBreak;
	[Header("Configure")]
	public float force = 10;

	private bool wasTriggered = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if(wasTriggered || !other.name.Equals("AdventureFriend")) return;
		wasTriggered = true;
		doorToBreak.isKinematic = false;
		Debug.Log("BOOM!");
		doorToBreak.AddForce(-doorToBreak.transform.forward * force, ForceMode.Impulse);
	}
}
