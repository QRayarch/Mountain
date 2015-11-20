using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

	protected Transform trans;

	// Use this for initialization
	protected virtual void Start () {
		trans = transform;
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		CheckInputs();
	}

	protected virtual void CheckInputs() {

	}
}
