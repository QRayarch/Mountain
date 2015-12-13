using UnityEngine;
using System.Collections;

public class BillBoard : MonoBehaviour {

	private Transform trans;
	private Transform cameraTrans;

	public bool noUp = true;

	// Use this for initialization
	void Start () {
		trans = transform;
		cameraTrans = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {
		if(noUp) {
			Quaternion rot = cameraTrans.rotation;
			Vector3 angles = rot.eulerAngles;
			angles.x = 0;
			angles.z = 0;
			rot.eulerAngles = angles;
			trans.rotation = rot;
		} else {
			trans.rotation = cameraTrans.rotation;
		}
	}
}
