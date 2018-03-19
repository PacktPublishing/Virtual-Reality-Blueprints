using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour {
	private Animator _animator;
	private Rigidbody _rigidbody;
	private CapsuleCollider _collider;
	private GameObject _target;


	public float moveSpeed = 1.5f;
	private bool _isDead, _isAttacking;

	private void Awake () {
		_animator = GetComponent<Animator> ();
		_rigidbody = GetComponent<Rigidbody> ();
		_collider = GetComponent<CapsuleCollider> ();
		_target = GameObject.FindGameObjectWithTag("Player");
	}

	private void Update () {
		Vector3 targetPostition = new Vector3( _target.transform.position.x, 0f, _target.transform.position.z ) ;
		transform.LookAt (targetPostition);
	}

	private void FixedUpdate () {
		if (!_isDead && !_isAttacking) {
			_rigidbody.velocity = (_target.transform.position - transform.position).normalized * moveSpeed;
		}
	} 
	public void Die () {
		_rigidbody.velocity = Vector3.zero;
		_collider.enabled = false;
		_isDead = true;
		_animator.SetBool ("Death", true);
		_animator.SetInteger ("DeathAnimationIndex", Random.Range (0, 3));
		StartCoroutine (DestroyThis());
	}

	IEnumerator DestroyThis () {
		yield return new WaitForSeconds (1.5f);
		Destroy (gameObject);
	} 
		
	private void OnCollisionEnter (Collision other) {
		if (other.collider.tag == "Player" && !_isDead) {
			StartCoroutine(Attack (other.collider.gameObject.GetComponent<PlayerController>()));
		}
	}

	IEnumerator Attack (PlayerController player) {
		_isAttacking = true;
		_animator.SetBool ("Attack", true);
		yield return new WaitForSeconds (44f / 30f);
		Die ();
	}
} 
