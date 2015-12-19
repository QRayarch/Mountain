using UnityEngine;
using System.Collections;

public class AdventureRunOff : MonoBehaviour {
	
	public Destination destination;
	public float delay = 4.0f;
	public float runSpeed = 10.0f;
	public Transform[] nodes;


	private float timer = 0;
	private int currentNode = 0;
	private bool wasTriggered = false;
	private bool isReady = false;
	private float oldSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(isReady) {
			if(destination.IsAtLocation) {
				if(currentNode + 1 < nodes.Length) {
					currentNode++;
					destination.transformDest = nodes[currentNode];
				} else if(destination.IsAtLocation) {
					destination.Agent.speed = oldSpeed;
				}
			}
			//Debug.Log(currentNode);
		}
		if(wasTriggered) {
			timer += Time.deltaTime;
			//Debug.Log(timer);
		}
		if(timer >= delay && !isReady) {
			Activate();
		}
	}

	public void Activate() {
		isReady = true;
		Debug.Log("ACTIvATED!!!");
		currentNode = 0;
		oldSpeed = destination.Agent.speed;
		destination.useTransform = true;
		destination.transformDest = nodes[currentNode];
		destination.Agent.speed = runSpeed;
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.yellow;
		for(int n = 0; n < nodes.Length; n++) {
			if(n + 1 < nodes.Length) {
				Gizmos.DrawLine(nodes[n].position, nodes[n + 1].position);
			}
			Gizmos.DrawWireSphere(nodes[n].position, 0.1f);
		}
	}
	void OnTriggerEnter(Collider other) {
		if(wasTriggered || !other.CompareTag("Player")) return;
		wasTriggered = true;
	}

}
