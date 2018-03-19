using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	Vector3 hitPoint = new Vector3 (0, 1, 0);

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			Shoot ();
		}
	}

	void Shoot () {
		RaycastHit hit;
		if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit)) {
			hitPoint = hit.point;
			ZombieController z = hit.collider.GetComponent<ZombieController> ();
			Debug.Log (z);
			if (z != null)
				z.Die ();
		}
	}

	private void OnDrawGizmos () {
		Gizmos.color = Color.red;
		Gizmos.DrawLine (hitPoint, Camera.main.transform.position);
	}
}
