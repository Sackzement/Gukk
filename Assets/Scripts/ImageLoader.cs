<<<<<<< HEAD
﻿using UnityEngine;
=======
﻿using System.IO;
using UnityEngine;
>>>>>>> daf91f4e4107a49f5d9bdb1851af52707f8353e8
using System.Collections;

public class ImageLoader : MonoBehaviour {

<<<<<<< HEAD
	public static Texture2D LoadPNG(string filePath) {
=======

	public static Texture2D LoadIMG(string filePath) {
>>>>>>> daf91f4e4107a49f5d9bdb1851af52707f8353e8

		Texture2D tex = null;
		byte[] fileData;

<<<<<<< HEAD
		if (File.Exists(filePath))     {
			fileData = File.ReadAllBytes(filePath);
			tex = new Texture2D(2, 2);
			tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
		}
=======
		if (File.Exists (filePath)) {
			fileData = File.ReadAllBytes (filePath);
			tex = new Texture2D (2, 2);
			tex.LoadImage (fileData);
		} else
			Debug.Log ("no file found");

>>>>>>> daf91f4e4107a49f5d9bdb1851af52707f8353e8
		return tex;
	}

	public static Texture2D LoadIMG2(string filename) {
<<<<<<< HEAD
		Texture2D texture = new Texture2D(4,4);

		FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
		byte[] imageData = new byte[fs.Length];
		fs.Read(imageData, 0, (int) fs.Length);
		texture.LoadImage(imageData);
		return texture;
	}

	// Use this for initialization
	void Start () {
		GameObject go = new GameObject.CreatePrimitive(PrimitiveType.Plane); 
	
	}


=======

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
>>>>>>> daf91f4e4107a49f5d9bdb1851af52707f8353e8
	
	// Update is called once per frame
	void Update () {
	
	}
}
