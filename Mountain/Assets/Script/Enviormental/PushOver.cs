using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class PushOver : MonoBehaviour {

	[Header("Configure")]
	public Vector3 directionToPushOver; 

	private Rigidbody body;
	private bool hasRun = false;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody>();
		if(body != null) {
			//body.freezeRotation = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision) {
		Debug.Log(collision.gameObject.transform.root.gameObject.tag);
		if(hasRun || !collision.gameObject.transform.root.gameObject.CompareTag("Player")) return;
		Debug.Log("HIT");
		Debug.DrawRay(transform.position, collision.relativeVelocity * 10.0f, Color.red, 9.0f);
		if(body != null) {
			body.freezeRotation = false;
		}
		float dot = Vector3.Dot(directionToPushOver.normalized, collision.relativeVelocity);
		//body.AddRelativeForce(directionToPushOver * dot);

		hasRun = true;
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.cyan;
		Gizmos.DrawRay(transform.position, directionToPushOver.normalized * 5.0f);
	}
}
