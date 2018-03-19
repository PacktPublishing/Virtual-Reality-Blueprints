using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleController : MonoBehaviour {
	[SerializeField] float popupSpeed;
	[SerializeField] float distanceToRaise;
	float maxMoleTime = 4f;

	Animator animator;
	AudioSource audioSource;

	bool canActivate = true;
	bool isActivated = false;
	bool wasActivated = false;

	IEnumerator runningCoroutine;

	int timesHasBeenWhacked = 0;

	void Start() {
		animator = GetComponentInChildren<Animator>();
		audioSource = GetComponent<AudioSource>();
	}

	void Update() {
		animator.SetBool("isActive", isActivated);
		animator.SetBool("wasActive", wasActivated);

		if ((wasActivated && !isActivated) || (!wasActivated && isActivated)) {
			float animationLength = animator.GetCurrentAnimatorStateInfo(0).length;
		}

		wasActivated = isActivated;
	}

	public void ResetGame() {
		StopCoroutine(RandomlyToggle());
	}

	public void StartGame() {
		StartCoroutine(RandomlyToggle());
	}

	public void StopGame() {
		StopCoroutine(RandomlyToggle());
	}

	IEnumerator RandomlyToggle() {
		float randomTimeLength = Random.Range(0f, maxMoleTime);
		yield return new WaitForSeconds(randomTimeLength);

		if (canActivate) {
			isActivated = !isActivated;
		}
		StartCoroutine(RandomlyToggle());
	}

	IEnumerator DeactivateCooldown() {
		yield return new WaitForSeconds(1f);
		canActivate = true;
	}
	void OnCollisionEnter(Collision other) {
		if (isActivated && other.gameObject.tag == "Player") {
			isActivated = false;
			canActivate = false;
			timesHasBeenWhacked++;
			StartCoroutine(DeactivateCooldown());
		}
	}

	public int TimesBeenWhacked {
		get {
			return timesHasBeenWhacked;
		}
	}
}
