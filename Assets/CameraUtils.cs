using System;
using System.Collections;
using UnityEngine;

public static class CameraUtils
{

	public static string ScreenShotName(int width, int height) {
		return string.Format("{0}/Screenshots/screen_{1}x{2}_{3}.png", 
			Application.dataPath, 
			width, height, 
			System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
	}

	public static void SaveImage(Texture2D image) {
		byte[] bytes = image.EncodeToPNG();
		string filename = CameraUtils.ScreenShotName(image.width, image.height);
		Debug.Log(string.Format("Took screenshot to: {0}", filename));

		System.IO.File.WriteAllBytes(filename, bytes);
	}

//	public static void CaptureFromCameraAsPNG(Camera camera, int width, int height) {
//		RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
//		camera.targetTexture = rt;
//		Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
//		camera.Render();
//		RenderTexture.active = rt;
//		screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
//		camera.targetTexture = null;
//		RenderTexture.active = null; // JC: added to avoid errors
//		Destroy(rt);
//		byte[] bytes = screenShot.EncodeToPNG();
//		return 
//	}
}
