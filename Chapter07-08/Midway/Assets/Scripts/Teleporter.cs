using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {
	[SerializeField] GameObject teleporter;
	[SerializeField] LayerMask layerMask;

	void Update () {
		RaycastHit hit;
		if (Physics.Raycast (Camera.main.transform.position, Camera.main.transform.rotation * Vector3.forward, out hit, 9999, layerMask)) {
			teleporter.SetActive (true);
			teleporter.transform.position = hit.point;
		} else {
			teleporter.SetActive (false);
		} 
		if (Input.GetButtonDown("Button.One") || Input.GetButtonDown("Button.Three")) { 
			transform.position = teleporter.transform.position;
		} 
	}
}

