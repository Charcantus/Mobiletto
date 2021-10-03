using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptSpostamentoCilindro : MonoBehaviour {
	[SerializeField] private Animator myAnimationController;

	private void onTriggerEnter(Collider other) {
		if (other.CompareTag("Player")) {
			myAnimationController.SetBool("PlaySpostamento", true);
		}
	}

	private void onTriggerExit(Collider other) {
		if (other.CompareTag("Player")) {
			myAnimationController.SetBool("PlaySpostamento", false);
		}
	}
}
