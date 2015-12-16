﻿using UnityEngine;
using System.Collections;

public class KindFriendIntro : DialogueTrigger {

	[Header("Setup")]
	public Transform friend;

	[Header("Config")]
	public float force = 10;

	private bool hasRun = false;
	private Rigidbody friendBody;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(friendBody != null) {
			Vector3 velo = friendBody.velocity;
			if(velo.y == 0) {//Our friend hit the ground
				GameObject player = GameObject.FindGameObjectWithTag("Player");
				DialogueReader reader = player.GetComponent<DialogueReader>();
				if(reader != null) {
					TriggerDialogue(reader);
				}
				Destroy(friendBody);
				NavMeshAgent friendAgent = friend.gameObject.GetComponent<NavMeshAgent>();
				if(friendAgent != null) {
					friendAgent.enabled = true;
				}
				Destination friendDest = friend.gameObject.GetComponent<Destination>();
				if(friendDest != null) {
					friendDest.destination = player.transform;
				}
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		if(hasRun || !other.CompareTag("Player")) return;
		Debug.Log("GO!!");
		friendBody = friend.gameObject.AddComponent<Rigidbody>();
		friendBody.freezeRotation = true;
		Vector3 translation = (other.transform.position + other.transform.forward * 10.0f) - friend.position;
		friendBody.AddForce(translation * force);
		Vector3 velo = new Vector3(0.0f, 1.0f, 0.0f);
		friendBody.velocity = velo;
		DialogueReader reader = other.GetComponent<DialogueReader>();
		hasRun = true;
	}
}
