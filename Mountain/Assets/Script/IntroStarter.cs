using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class IntroStarter : MonoBehaviour {
	public DialogueReader reader;
	public FirstPersonController firstPerson;
	public Animator panelAnimator;
	// Use this for initialization
	void Start () {
		firstPerson.enabled = false;
		panelAnimator.SetBool("isVisible", true);
	}
	
	// Update is called once per frame
	void Update () {
		if(!reader.IsReading) {
			firstPerson.enabled = true;
			panelAnimator.SetBool("isVisible", false);
			Destroy(gameObject);
		}
	}
}
