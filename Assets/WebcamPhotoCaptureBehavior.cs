using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebcamPhotoCaptureBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int resWidth = 1024; 
	public int resHeight = 768;

	private bool takeHiResShot = false;

	public void TakeHiResShot() {
		takeHiResShot = true;
	}

	void LateUpdate() {
		var camera = Camera.allCameras[0];
		takeHiResShot |= Input.GetKeyDown("k");
		if (takeHiResShot && camera != null) {
			RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
			camera.targetTexture = rt;
			Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
			camera.Render();
			RenderTexture.active = rt;
			screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
			camera.targetTexture = null;
			RenderTexture.active = null; // JC: added to avoid errors
			Destroy(rt);
			CameraUtils.SaveImage (screenShot);
			takeHiResShot = false;
		}
	}
}
