using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoleGameController : MonoBehaviour {
	[SerializeField] Text timerUI, scoreUI;
	[SerializeField] float startingTimeInSeconds = 30f;

	List<MoleController> moles;
	int score = 0;
	float timer = 0f;
	bool isTiming;

	void Start() {
		moles = new List<MoleController>();
		StartGame();
	}

	void Update() {
		int scoreAccumulator = 0;
		foreach (MoleController mole in GetComponentsInChildren<MoleController>()) {
			scoreAccumulator += mole.TimesBeenWhacked;
		}

		score = scoreAccumulator;
		scoreUI.text = score.ToString();

		int minutesLeft = (int) Mathf.Clamp((startingTimeInSeconds - timer) / 60, 0, 99);
		int secondsLeft = (int) Mathf.Clamp((startingTimeInSeconds - timer) % 60, 0, 99);
		timerUI.text = string.Format("{0:D2}:{1:D2}", minutesLeft, secondsLeft);
	}

	void FixedUpdate() {
		if (isTiming) {
			timer += Time.deltaTime;
		}
	}

	public void StartGame() {
		foreach (MoleController mole in GetComponentsInChildren<MoleController>()) {
			moles.Add(mole);
			mole.StartGame();
		}
		StartTimer();
	}

	public void StopGame() {
		StopTimer();
	}

	// Starts Timer
	public void StartTimer() {
		timer = 0f;
		isTiming = true;
	}

	public void StopTimer() {
		isTiming = false;
	}
}
