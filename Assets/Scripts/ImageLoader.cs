using UnityEngine;
using System.Collections;

public class ImageLoader : MonoBehaviour {

	public static Texture2D LoadPNG(string filePath) {

		Texture2D tex = null;
		byte[] fileData;

		if (File.Exists(filePath))     {
			fileData = File.ReadAllBytes(filePath);
			tex = new Texture2D(2, 2);
			tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
		}
		return tex;
	}

	public static Texture2D LoadIMG2(string filename) {
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


	
	// Update is called once per frame
	void Update () {
	
	}
}
