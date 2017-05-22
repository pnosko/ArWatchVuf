using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebcamDeviceCaptureBehavior : MonoBehaviour {
	private string deviceName;

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
		takeHiResShot |= Input.GetKeyDown ("k");
		if (takeHiResShot) {

			var renderer = GetComponent<Renderer>();
			WebCamDevice[] devices = WebCamTexture.devices;
			deviceName = devices[0].name;
			var wct = new WebCamTexture(deviceName, resWidth, resHeight, 12);
			renderer.material.mainTexture = wct;
			wct.Play();
			Texture2D snap = new Texture2D (wct.width, wct.height);
			snap.SetPixels (wct.GetPixels ());
			snap.Apply ();

			string filename = CameraUtils.ScreenShotName (resWidth, resHeight);

			System.IO.File.WriteAllBytes (filename, snap.EncodeToPNG ());

			Debug.Log(string.Format("Took screenshot to: {0}", filename));
			takeHiResShot = false;
		}
	}
}
