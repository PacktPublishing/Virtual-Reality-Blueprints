using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour {
	[SerializeField] float size = 800f;

	// Update is called once per frame
	void Update () {
		RaycastHit hitInfo;
		if (Physics.Raycast (Camera.main.transform.position, Camera.main.transform.forward, out hitInfo)) {
			RectTransform rt = GetComponent<RectTransform> ();
			rt.position = hitInfo.point + (hitInfo.normal * 0.1f);
			rt.transform.rotation = Quaternion.FromToRotation (transform.forward, hitInfo.normal) * transform.rotation;
		}

		Vector3 a = Camera.main.WorldToScreenPoint (transform.position);
		Vector3 b = new Vector3 (a.x, a.y + size, a.z);

		Vector3 aa = Camera.main.ScreenToWorldPoint (a);
		Vector3 bb = Camera.main.ScreenToWorldPoint (b);

		transform.localScale = Vector3.one * (aa - bb).magnitude;
	}
}
