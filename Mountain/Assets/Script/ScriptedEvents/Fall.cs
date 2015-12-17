using UnityEngine;
using System.Collections;

public class Fall : MonoBehaviour {

	[Header("Setup")]
	public Animator panelAnimator;

	[Header("Configure")]
	public float waitTime = 1;

	private bool wasTriggered;
	private float timer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(wasTriggered) {
			timer += Time.deltaTime;
			if(timer >= waitTime) {
				panelAnimator.SetBool("isVisible", false);
				Destroy(gameObject);
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		if(wasTriggered || !other.CompareTag("Player")) return;
		panelAnimator.SetBool("isVisible", true);
		wasTriggered = true;
	}
}
