using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Character {
	Unknown,
	ImaginaryFriendWorry,
	ImaginaryFriendAdventure,
	ImaginaryFriendWorryDifference,
	RedBeans,
	RedBeanCommander,
}

public class CharacterRefernece : MonoBehaviour {

	[System.Serializable]
	public class CharacterDialogueInfo {
		public Character character;
		public string textAperance;
		public Color textColor = Color.white;
	}

	public List<CharacterDialogueInfo> dialogueInfo = new List<CharacterDialogueInfo>();

	public CharacterDialogueInfo GetCharacterDialogueInfo(Character character) {
		for(int c = 0; c < dialogueInfo.Count; c++) {
			if(dialogueInfo[c].character == character) {
				return dialogueInfo[c];
			}
		}
		return null;
	}
}
