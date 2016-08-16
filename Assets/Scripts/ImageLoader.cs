using System.IO;
using UnityEngine;
using System.Collections;

public class ImageLoader : MonoBehaviour {


	public static Texture2D LoadIMG(string filePath) {

		Texture2D tex = null;
		byte[] fileData;

		if (File.Exists (filePath)) {
			fileData = File.ReadAllBytes (filePath);
			tex = new Texture2D (2, 2);
			tex.LoadImage (fileData);
		} else
			Debug.Log ("no file found");

		return tex;
	}

	public static Texture2D LoadIMG2(string filename) {

		Texture2D tex = new Texture2D (4, 4);

		FileStream fs = new FileStream (filename, FileMode.Open, FileAccess.Read);
		byte[] imageData = new byte[fs.Length];
		fs.Read (imageData, 0, (int)fs.Length);
		tex.LoadImage (imageData);

		return tex;
	}

	// Use this for initialization
	void Start() {
		Debug.Log ("Path: " + Path.GetFullPath("./"));
		GameObject go = GameObject.CreatePrimitive(PrimitiveType.Plane);
		go.transform.parent = transform;
		Renderer rend = go.GetComponent<Renderer>();
		rend.material.mainTexture = LoadIMG("143845.png");
		Texture2D tex = rend.material.mainTexture as Texture2D;
		Color32[] pix = tex.GetPixels32();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
