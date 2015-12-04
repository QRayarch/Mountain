using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Conversation : MonoBehaviour {

	public List<Dialogue> dialogues;

	public Dialogue GetDialogue(int index) {
		if(index >= 0 && index < dialogues.Count) {
			return dialogues[index];
		}
		return Dialogue.Empty;
	}
}
