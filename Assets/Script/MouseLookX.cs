using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookX : MonoBehaviour {

    public float rotateSpeed = 3f;
    public float minimumVert = -45f;
    public float maximumVert = 45f;
    private float _rotationX = 0;
	// Use this for initialization
	void Start () {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null) {
            body.freezeRotation = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
        _rotationX -= Input.GetAxis("Mouse Y") * rotateSpeed;
        _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

        float delta = Input.GetAxis("Mouse X") * rotateSpeed;
        float rotationY = transform.localEulerAngles.y + delta;

        transform.localEulerAngles = new Vector3(0, rotationY, 0);

    }
}
