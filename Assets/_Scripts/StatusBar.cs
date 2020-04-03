using UnityEngine;
using System;

/// <summary>
/// Displays a configurable health bar for any object with a Damageable as a parent
/// </summary>
public class StatusBar : MonoBehaviour {

	MaterialPropertyBlock matBlock;
	MeshRenderer meshRenderer;
	Camera mainCamera;
	RenewableResource damageable;

	private void Awake() {
		meshRenderer = GetComponent<MeshRenderer>();
		matBlock = new MaterialPropertyBlock();
		// get the damageable parent we're attached to
		damageable = GetComponentInParent<RenewableResource>();
	}

	private void Start() {
		// Cache since Camera.main is super slow
		mainCamera = Camera.main;
	}

	private void Update() {
		// Only display on partial health
		if (damageable.fullCount < damageable.limit) {
			meshRenderer.enabled = true;
			AlignCamera();
			UpdateParams();
		} else {
			meshRenderer.enabled = false;
		}
	}

	private void UpdateParams() {
		meshRenderer.GetPropertyBlock(matBlock);


		float amt = 0f;

		if (damageable.collecting)
			amt = (float) (damageable.fullCount - Math.Truncate(damageable.fullCount));
		else
			amt = 2;


		matBlock.SetFloat("_Fill", amt);
		meshRenderer.SetPropertyBlock(matBlock);
	}

	private void AlignCamera() {
		if (mainCamera != null) {
			var camXform = mainCamera.transform;
			var forward = transform.position - camXform.position;
			forward.Normalize();
			var up = Vector3.Cross(forward, camXform.right);
			transform.rotation = Quaternion.LookRotation(forward, up);
		}
	}

}