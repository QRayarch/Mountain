using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class JarJailCell : MonoBehaviour {

	[Header("Setup")]
	public Transform effect;
	public Transform jailCell;

	public RandomWalk walkZone;

	private bool wasTriggered = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if(wasTriggered || !other.CompareTag("Player")) return;

		Transform hand = Camera.main.transform.FindChild("Hand");
		if(hand != null) {
			Transform jar = hand.FindChild("Jar(Clone)");
			if(jar != null) {
				
				for(int i = 0; i < 20; i++) {
					GameObject newEffect = (Instantiate(effect, jar.position, Quaternion.identity) as Transform).gameObject;
					Rigidbody effectBody = newEffect.GetComponent<Rigidbody>();
					if(effectBody != null) {
						Vector3 vector = (jailCell.position + Random.insideUnitSphere * 0.5f) - other.transform.position;
						effectBody.AddForce(vector * Random.Range(60.0f, 80.0f));
					}
					Destroy(newEffect, 3.0f);
				}
				Destroy(jailCell.gameObject, 0.3f);
				if(walkZone != null) {
					walkZone.RemoveAll();
				}
				
				wasTriggered = true;
			}
		}
	}
}
