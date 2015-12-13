using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIDialogue : MonoBehaviour {

	[Header("Setup")]
	public Text text;
	public Animator animator;
	[Header("Config")]
	public string preCharacter;
	public string postCharacter;
	[Range(0.0f, 1.0f)]
	public float textApearBeforeFinish = 0.5f;

	private DialogueReader reader;
	private CharacterRefernece charRef;
	private bool isVisible = false;

	private float textTimer = 0;
	private float timePerWord = 0;
	private int textIndex = 0;
	private string[] textToAdd;
	private Dialogue dialogue;
	private CharacterRefernece.CharacterDialogueInfo charInfo;

	// Use this for initialization
	void Start () {
		reader = GameObject.FindObjectOfType<DialogueReader>();
		if(reader == null) {
			Debug.LogError("--No Dialogue Reader--//The UIDialogue Can not find a dialogue reader in the scene.");
		} else {
			reader.NewDialogueEntered += EnteredNewDialogue;
		}
		charRef = GameObject.FindObjectOfType<CharacterRefernece>();
	}
	
	// Update is called once per frame
	void Update () {
		if(dialogue != Dialogue.Empty) {
			if(textToAdd.Length > 0 && textIndex < textToAdd.Length) {
				textTimer += Time.deltaTime;
				if(textTimer >= timePerWord) {
					textTimer = 0;
					text.text += " " + textToAdd[textIndex];
					textIndex++;
				}
			} else {
				//isVisible = false;
			}
		} else {
			isVisible = false;
		}
		animator.SetBool("isVisible", isVisible);
	}

	void EnteredNewDialogue(Dialogue dialogue) {
		this.dialogue = dialogue;
		textTimer = 0;
		textIndex = 0;
		if(dialogue == Dialogue.Empty) {
			text.color = Color.white;
			text.text = "";
			return;
		}
		isVisible = true;
		charInfo = null;
		textToAdd = dialogue.text.Split(new char[]{' '});
		if(textToAdd.Length > 0 && dialogue.duration > 0) {
//			Debug.Log("W " + textToAdd.Length + " " + ((textToAdd.Length + 1) / dialogue.duration) + " " + ((textToAdd.Length + 1) / dialogue.duration * textApearBeforeFinish));
			timePerWord = dialogue.duration / (textToAdd.Length + 1) * textApearBeforeFinish; 
		} else {
			Debug.LogWarning("--Empty string or duration zero--//");
		}
		if(charRef == null) {
			text.color = Color.white;
		} else {
			charInfo = charRef.GetCharacterDialogueInfo(dialogue.speaker);
			if(charInfo != null) {
				text.text = preCharacter + charInfo.textAperance + postCharacter + " ";
				text.color = charInfo.textColor;
			}
		}
	}
}
