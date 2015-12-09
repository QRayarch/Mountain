using UnityEngine;
using System.Collections;

public class Stick : Item {

	public float range = 0.3f;
	public float force = -2000;

	float timer = 0;

	// Use this for initialization
	protected override void Start () {
		base.Start();
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update();
	}

	protected override void CheckInputs() {
		if(Input.GetButtonDown("Fire")) {
			Hit();
		}
		timer += Time.deltaTime;
		if(timer >= 0.4f) {
			trans.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f));
		}
	}

	private void Hit() {
		RaycastHit hit = new RaycastHit();
		Vector3 targ = trans.forward;
		targ = Camera.main.ScreenPointToRay(Input.mousePosition).direction;
		Debug.DrawRay(trans.position, targ * range,  Color.red, 2.0f);
		timer = 0;
		trans.localRotation = Quaternion.Euler(new Vector3(40.0f, 0.0f, 30.0f));
		if(Physics.Raycast(trans.position, targ, out hit, range)) {
			GameObject objectHit = hit.collider.gameObject;
			if(objectHit.CompareTag("Rock")) {
				Rigidbody body = objectHit.GetComponent<Rigidbody>();
				if(body != null) {
					body.isKinematic = false;
					body.AddForceAtPosition(trans.right * force, hit.point);
				}
			}
		}
	}
}
