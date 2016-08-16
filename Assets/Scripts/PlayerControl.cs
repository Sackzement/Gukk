using UnityEngine;
//using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class PlayerControl : MonoBehaviour {

    public float moveSpeed = 10f;
    public float rotSpeed = 90f;
	public float zoomSpeed = 20f;
	public float minZoom = 10f, maxZoom = 90f;
    Rigidbody rb;
    int curr_cam = 1;
	Camera[] cameras;
	Vector3 moveTarget = new Vector3();
	bool movingActive = false;


	void AssignVars () {
		rb = GetComponent<Rigidbody> ();

		GameObject[] camObjs = GameObject.FindGameObjectsWithTag("Camera");
		List<Camera> camList = new List<Camera> ();
		foreach (GameObject obj in camObjs) {
			camList.Add( obj.GetComponent<Camera>() );
		}
		cameras = camList.ToArray ();
	}

    void Start () 
	{
		AssignVars ();
        setCamera(curr_cam);
	}
	
    void disableAllCameras()
    {
        foreach (Camera cam in cameras)
            cam.enabled = false;
    }

    void setCamera(int idx)
    {
        if (idx < cameras.Length)
        {
            disableAllCameras();
            cameras[idx].enabled = true;
            curr_cam = idx;
        }
    }
	// Update is called once per frame

	Vector3 Get3DMouseFloorPos() {
		Ray ray = cameras [curr_cam].GetComponent<Camera> ().ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		LayerMask layer = LayerMask.GetMask("Floor");
		if (Physics.Raycast (ray, out hit, 100.0f, layer))
			return hit.point;
		else // return last mouse pos / moveTarget
			return moveTarget;
	}
	void SetMoveTargetActivateMoving() {

		moveTarget = Get3DMouseFloorPos ();
		moveTarget.y = transform.position.y;

		movingActive = true;
	}
	void MoveToTarget () {
		Vector3 dir = moveTarget - transform.position;
		float distance = dir.magnitude;
		dir.Normalize ();

		Vector3 moveVec = dir * moveSpeed * Time.deltaTime;
		if (moveVec.magnitude >= distance) {
			rb.MovePosition (new Vector3 (moveTarget.x, moveTarget.y, moveTarget.z));
			movingActive = false;
		}
		else
			rb.MovePosition (rb.position + moveVec);
	}
	void ToggleThroughCameras ()
	{
		++curr_cam;
		if (curr_cam >= cameras.Length)
			curr_cam = 0;

		setCamera(curr_cam);
	}
	void Zoom (float scroll) {
		float fov = cameras [curr_cam].fieldOfView;
		fov -= scroll * zoomSpeed;
		fov = Mathf.Clamp (fov, minZoom, maxZoom);
		cameras [curr_cam].fieldOfView = fov;
	}
	void Update () {

		float leftRight = Input.GetAxisRaw ("Horizontal");
		float downUp = Input.GetAxisRaw ("Vertical");
		float rotVal = Input.GetAxisRaw("Diagonal");
		float scroll = Input.GetAxis ("Mouse ScrollWheel");

		if (leftRight != 0f)
			rb.transform.Translate(Vector3.right * leftRight * moveSpeed * Time.deltaTime);
		if (downUp != 0f)
			rb.transform.Translate(Vector3.forward * downUp * moveSpeed * Time.deltaTime);
		if (rotVal != 0f)
			rb.transform.Rotate(Vector3.up * rotVal * rotSpeed * Time.deltaTime);

		if (Input.GetKeyDown (KeyCode.Space))
			ToggleThroughCameras ();

		if (Input.GetMouseButton (1))
			SetMoveTargetActivateMoving ();

		if (scroll != 0f)
			Zoom (scroll);
		
		if (movingActive)
			MoveToTarget ();
	
	
	}




}
