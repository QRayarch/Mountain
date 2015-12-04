using UnityEngine;
using System.Collections;


[System.Serializable]
public struct Dialogue {
	public static readonly Dialogue Empty = new Dialogue();
	[Multiline]
	public string text;
	public Character speaker;
	public AudioClip sound;
	public float duration;

	public static bool operator ==(Dialogue dia1, Dialogue dia2) 
	{
		return dia1.Equals(dia2);
	}
	
	public static bool operator !=(Dialogue dia1, Dialogue dia2) 
	{
		return !dia1.Equals(dia2);
	}
}
