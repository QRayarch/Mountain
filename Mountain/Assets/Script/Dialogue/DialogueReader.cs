using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public delegate void EnteredNewDialogue(Dialogue dialogue);

public class DialogueReader : MonoBehaviour {

	private int readIndex = 0;
	private float readTimer = 0;
	private List<Conversation> conversations = new List<Conversation>();
	private event EnteredNewDialogue newDialogueEntered;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(conversations.Count > 0) {
			readTimer += Time.deltaTime;
			Dialogue dia = CurrentDialogue;
			if(readTimer >= dia.duration) {
				if(dia == Dialogue.Empty) {
					RemoveDialogue();
					NewDialogue();
				} else {
					readIndex++;
					NewDialogue();
				}
			}
		}
	}

	public void AddDialogue(Conversation con, bool overRide = true) {
		if(overRide) {
			conversations.Clear();
			ResetReading();
			conversations.Add(con);
			NewDialogue();
		} else {
			conversations.Add(con);
			if(conversations.Count == 1) {
				NewDialogue();
			}
		}
	}

	void RemoveDialogue() {
		conversations.RemoveAt(0);
		ResetReading();
	}

	void NewDialogue() {
		readTimer = 0;
		if(newDialogueEntered != null) {
			newDialogueEntered.Invoke(CurrentDialogue);
		}
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

	public EnteredNewDialogue NewDialogueEntered {
		get { return newDialogueEntered; }
		set { newDialogueEntered = value; }
	}

	public bool IsReading {
		get{ return conversations.Count > 0; }
	}
}
