using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class Destination : MonoBehaviour {

	public Animator animator;
	public Transform destination;
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
		if(destination == null) return;
		agent.destination = destination.position;
		if(animator != null) {
			animator.SetBool("isWalking", agent.velocity.magnitude > 0);
			Vector3 delta = trans.position - destination.position;
			int dir = -1;
			if(delta.x > 0 || agent.velocity.magnitude == 0) {
				dir = 1;
			}
			Debug.Log(delta);
			Vector3 scale = billboardTransform.localScale;
			scale.x = Mathf.Abs(scale.x) * dir;
			billboardTransform.localScale = scale;
		}
	}
}
