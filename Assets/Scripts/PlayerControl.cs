using UnityEngine;
using UnityEditor;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    public float moveSpeed = 10;
    public float rotSpeed = 90;
    Rigidbody rb;
    public int curr_cam = 1;
    GameObject[] cameras;



    void Start () {
		rb = GetComponent<Rigidbody> ();
        cameras = GameObject.FindGameObjectsWithTag("Camera");
        setCamera(curr_cam);
	}
	
    void disableAllCameras()
    {
        foreach (GameObject cam in cameras)
            cam.GetComponent<Camera>().enabled = false;
    }
    void setCamera(int idx)
    {
        if (idx < cameras.Length)
        {
            disableAllCameras();
            cameras[idx].GetComponent<Camera>().enabled = true;
        }
    }
	// Update is called once per frame
	void Update () {
        
		float ver = Input.GetAxisRaw ("Vertical");
		float hor = Input.GetAxisRaw ("Horizontal");
        float dia = Input.GetAxisRaw("Diagonal");

        if (ver != 0)
			rb.transform.Translate(Vector3.forward * ver * moveSpeed * Time.deltaTime);
		if (hor != 0)
			rb.transform.Translate(Vector3.right * hor * moveSpeed * Time.deltaTime);
        if (dia != 0)
            rb.transform.Rotate(Vector3.up * dia * rotSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) )
        {
            ++curr_cam;
            if (curr_cam >= cameras.Length)
                curr_cam = 0;

            setCamera(curr_cam);
            
        }
	}
}
