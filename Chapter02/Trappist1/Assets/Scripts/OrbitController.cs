using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitController : MonoBehaviour {

	public Transform orbitPivot;
	public float orbitSpeed;
	public float rotationSpeed;
	public float planetRadius;
	public float distFromStar; 

	// Use this for initialization
	void Start () {
		// Creates a random position along the orbit path
		// and sets the planet's position to that location
		Vector2 randomPosition = Random.insideUnitCircle;
		transform.position = new Vector3 (randomPosition.x, 0f, randomPosition.y) * distFromStar;

		// Sets the size of the GameObject to the Planet radius value
		transform.localScale = Vector3.one * planetRadius;
	} 

	
	// Update is called once per frame. This code block updates the Planet's position during each
	// runtime frame.
	void Update () {
		this.transform.RotateAround (orbitPivot.position, Vector3.up, orbitSpeed * Time.deltaTime);
		this.transform.Rotate (Vector3.up, rotationSpeed * Time.deltaTime);
	} 

}
