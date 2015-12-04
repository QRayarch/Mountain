using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class DiaCollisionTrigger : DialogueTrigger {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if(other.CompareTag("Player")) {
			DialogueReader reader = other.GetComponent<DialogueReader>();
			if(reader != null) {
				TriggerDialogue(reader);
			}
		}
	}
}
