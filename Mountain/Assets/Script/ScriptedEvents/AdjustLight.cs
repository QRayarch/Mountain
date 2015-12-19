using UnityEngine;
using System.Collections;

public class AdjustLight : MonoBehaviour {

	[Header("Setup")]
	public Light light;
	public Transform newOrientations;
	public Jar.LightProfile newLight;

	private bool wasTriggered = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if(wasTriggered || !other.CompareTag("Player")) return;
		light.transform.rotation = newOrientations.rotation;
		light.color = newLight.color;
		light.range = newLight.range;
		light.intensity = newLight.intensity;
		wasTriggered = true;
	}
}
