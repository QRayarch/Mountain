using UnityEngine;
using System.Collections;
using System.Collections.Generic;

delegate void EnteredNewDialogue(Dialogue dialogue);

public class DialogueReader : MonoBehaviour {

	private int readIndex = 0;
	private float readTimer = 0;
	private List<Conversation> conversations = new List<Conversation>();

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(conversations.Count > 0) {
			readTimer += Time.deltaTime;
			Dialogue dia = CurrentDialogue;
			if(readTimer >= dia.duration) {
				readTimer = 0;
				if(dia == Dialogue.Empty) {
					RemoveDialogue();
				}
			}
		}
	}

	public void AddDialogue(Conversation con, bool overRide = false) {
		if(overRide) {
			RemoveDialogue();
			conversations.Insert(0, con);
		} else {
			conversations.Add(con);
		}
	}

	void RemoveDialogue() {
		conversations.RemoveAt(0);
		ResetReading();
	}

	void ResetReading() {
		readIndex = 0;
		readTimer = 0;
	}

	public Conversation CurrentConversation {
		get{ 
			if(conversations.Count > 0) return conversations[0]; 
			return null;
		}
	}

	public Dialogue CurrentDialogue {
		get {
			if(CurrentConversation != null) {
				return CurrentConversation.GetDialogue(readIndex);
			}
			return Dialogue.Empty;
		}
	}
}
