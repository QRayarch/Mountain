using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
[RequireComponent(typeof(Collider))]
public class Pickup : MonoBehaviour {

	public Item itemToPickUp;

	// Use this for initialization
	void Start () {
		if(itemToPickUp != null) {
			Transform trans = transform;
			int children = trans.childCount;
			for(int c = 0; c < children; c++) {
				DestroyImmediate(trans.GetChild(0).gameObject);
			}

			Transform graphicT = itemToPickUp.transform.FindChild("Graphic");
			Transform itemGraphicTransform = Instantiate(graphicT, transform.position, transform.rotation) as Transform;
			itemGraphicTransform.SetParent(transform);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if(other.CompareTag("Player")) {
			Transform playerTransform = other.transform;
			Transform hand = FindPlayerHand(playerTransform);//.FindChild("Hand");
			if(hand == null) {
				Debug.LogWarning("--Player does not have a hand--//Please attach a transfrom to the player named hand.");
			} else {
				//Nothing is equipt. Lets get a new thing
				if(hand.childCount == 0) {
					Item pickedUpItem = Instantiate(itemToPickUp) as Item;
					Transform itemTransform = pickedUpItem.transform;
					itemTransform.SetParent(hand, false);
					itemTransform.localPosition = Vector3.zero;
					Destroy(gameObject);
				}
			}
		}
	}

	private Transform FindPlayerHand(Transform playerT) {
		Transform hand = null;
		for(int c = 0; c < playerT.childCount; c++) {
			hand = playerT.GetChild(c).FindChild("Hand");
			if(hand != null) return hand;
		}
		return null;
	}
}
