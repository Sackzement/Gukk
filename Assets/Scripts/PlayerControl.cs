using UnityEngine;
using UnityEditor;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float moveSpeed = 10;
	Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {

		float ver = Input.GetAxisRaw ("Vertical");
		float hor = Input.GetAxisRaw ("Horizontal");
			
		if (ver != 0)
			rb.transform.Translate(Vector3.forward * ver * Time.deltaTime);
		if (hor != 0)
			rb.transform.Translate(Vector3.right * hor * Time.deltaTime);

		if (Input.GetKeyDown(KeyCode.Space) )
			Handles.DrawCamera (new Rect(0,0,1024,800), Camera.allCameras [1]);
	}
}
