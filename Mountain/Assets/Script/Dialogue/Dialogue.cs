using UnityEngine;
using System.Collections;

public enum Character {
	Unknown,
	
}

[System.Serializable]
public struct Dialogue {
	[Multiline]
	public string text;
	public Character speaker;
	public AudioClip sound;
	public float duration;
}
