using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour {

  private float horizontalSpeed;
  private float verticalSpeed;
  private float speed = 0.5f;
  private Transform ownTransform;
	// Use this for initialization
	void Start () {
    ownTransform = gameObject.transform;
    horizontalSpeed = 0f;
    verticalSpeed = 0f;
    if (isLocalPlayer){
      gameObject.GetComponentInChildren<Camera>().enabled = true;
      gameObject.GetComponentInChildren<AudioListener>().enabled = true;
    } else {
      gameObject.GetComponentInChildren<Camera>().enabled = false;
      gameObject.GetComponentInChildren<AudioListener>().enabled = false;
    }
	}

  void FixedUpdate() {
    if (! isLocalPlayer){
      return;
    }
    ownTransform.position = ownTransform.position + new Vector3(horizontalSpeed, 0, verticalSpeed);
  }

	// Update is called once per frame
	void Update () {
    if (! isLocalPlayer){
      return;
    }
		horizontalSpeed= Input.GetAxis("Horizontal") * speed;
		verticalSpeed = Input.GetAxis("Vertical") * speed;
	}
}
