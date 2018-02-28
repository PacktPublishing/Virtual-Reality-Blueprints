using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour {

	float speed = 10.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Mouse X") > 0) {
			transform.position += new Vector3 (Input.GetAxisRaw ("Mouse X") * Time.deltaTime * speed,
				0.0f, Input.GetAxisRaw ("Mouse Y") * Time.deltaTime * speed);
		}	else if (Input.GetAxis ("Mouse X") < 0) {

			transform.position += new Vector3 (Input.GetAxisRaw ("Mouse X") * Time.deltaTime * speed,
				0.0f, Input.GetAxisRaw ("Mouse Y") * Time.deltaTime * speed);
		}
	}
}
