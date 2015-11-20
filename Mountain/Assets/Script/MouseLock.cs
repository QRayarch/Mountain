using UnityEngine;
using System.Collections;

public class MouseLock : MonoBehaviour {

	public CursorLockMode lockMode = CursorLockMode.None;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Cursor.lockState = lockMode;
	}
}
