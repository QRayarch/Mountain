using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Jar : Item {

	public int maxFireFlies = 5;
	public LightProfile startingLight;
	public LightProfile endLight;
	public Light light;
	public Collider fireflyBounds;
	
	private List<Transform> fireFlies = new List<Transform>();

	[System.Serializable]
	public struct LightProfile {
		public float range;
		public float intensity;
		public Color color;
	}

	// Use this for initialization
	protected override void Start () {
		base.Start();
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update();
		for(int f = 0; f < fireFlies.Count; f++) {
			fireFlies[f].position += Random.insideUnitSphere * 0.2f * Time.deltaTime;
		}
	}

	void OnTriggerEnter(Collider other) {
		if(fireFlies.Count >= maxFireFlies) return;
		if(other.CompareTag("FireFly")) {
			Transform fireFlyGraphic = other.transform.FindChild("Graphic");
			if(fireFlyGraphic != null) {
				fireFlyGraphic.SetParent(trans, false);
				fireFlies.Add(fireFlyGraphic);
				UpdateLight();
			}
			Destroy(other.gameObject);
		}
	}

	void UpdateLight() {
		LerpLight(startingLight, endLight, fireFlies.Count / (float)maxFireFlies);
	}

	void LerpLight(LightProfile start, LightProfile end, float t) {
		if(light == null) {
			Debug.LogWarning("--No light found in Jar--//Try adding a light to the jar script");
			return;
		}
		light.color = Color.Lerp(start.color, end.color, t);
		light.range = Mathf.Lerp(start.range, end.range, t);
		light.intensity = Mathf.Lerp(start.intensity, end.intensity, t);
	}
}
