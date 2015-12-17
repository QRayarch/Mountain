using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class Destination : MonoBehaviour {

	public Animator animator;
	public Transform transformDest;
	public Vector3 destination;
	public bool useTransform = true;
	private NavMeshAgent agent;

	private Transform trans;
	private Transform billboardTransform;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		trans = transform;
		if(animator != null) {
			billboardTransform = animator.transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(transformDest != null && useTransform)  {
			agent.destination = transformDest.position;
		} else if(destination != Vector3.zero){
			agent.destination = destination;
		}
		if(animator != null) {
			animator.SetBool("isWalking", agent.velocity.magnitude > 0);
			Vector3 delta = trans.position - destination;
			int dir = -1;
			if(delta.x > 0 || agent.velocity.magnitude == 0) {
				dir = 1;
			}
			Vector3 scale = billboardTransform.localScale;
			scale.x = Mathf.Abs(scale.x) * dir;
			billboardTransform.localScale = scale;
		}
	}

	public NavMeshAgent Agent {
		get{ return agent; }
	}

	public bool IsAtLocation {
		get{ return agent.velocity.magnitude <= 0;}
	}
}
