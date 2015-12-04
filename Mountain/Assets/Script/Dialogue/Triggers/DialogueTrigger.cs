using UnityEngine;
using System.Collections;

public class DialogueTrigger : MonoBehaviour {
	public Conversation conversation;
	public int numTimesCantrigger = 1;

	public virtual void TriggerDialogue(DialogueReader reader) {
		if(numTimesCantrigger > 0) {
			reader.AddDialogue(conversation);
			numTimesCantrigger--;
		}
	}
}
