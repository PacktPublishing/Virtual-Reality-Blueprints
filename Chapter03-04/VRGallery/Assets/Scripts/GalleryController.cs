using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(GraphicRaycaster))]

public class ImageSelector : MonoBehaviour {
	public string categoryTitleName;
	public Text categoryTitle;
	public Image fullImage;
	public Material hilightMaterial;

	// Use this for initialization
	private void Start () {
		categoryTitle.text = categoryTitleName;
	}

	// Update is called once per frame
	private void Update () {
		if (Input.GetMouseButtonDown(0)) {
			OnPointerDown ();
		}
	}

	public void OnPointerDown () {
		GraphicRaycaster gr = GetComponent<GraphicRaycaster> ();
		PointerEventData data = new PointerEventData (null);
		data.position = Input.mousePosition;

		List<RaycastResult> results =new List<RaycastResult> ();
		gr.Raycast (data, results);

		Debug.Log(data.position);

		if (results.Count > 0) {
			OnPreviewClick (results [0].gameObject);
		}
	} 

	void OnPreviewClick (GameObject thisButton) {
		Image previewImage = thisButton.GetComponent<Image> ();
		if (previewImage != null) {
			fullImage.sprite = previewImage.sprite;
			fullImage.type = Image.Type.Simple;
			fullImage.preserveAspect = true;
		}
	}

	public void OnPointerEnter (Image image) {
		image.material = hilightMaterial;
	}

	public void OnPointerExit (Image image) {
		image.material = null;
	}


}
