using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScreenSHortSave : MonoBehaviour {

	// Use this for initialization
	bool creatingFile = false;
	string fileName = "Screenshot.png";
		void Update() 
		{ 
		if(ControlFreak2.CF2Input.GetKeyDown(KeyCode.K)) 
			{
				Application.CaptureScreenshot(fileName);
			print ("secren shot taken");
				creatingFile = true;
			}
		if (creatingFile) {
			string origin = System.IO.Path.Combine(Application.persistentDataPath, fileName);
			string destination = "/sdcard/DCIM/camera/" + fileName; // could be anything
			if (System.IO.File.Exists(origin)) {
				System.IO.File.Move(origin, destination);
				creatingFile = false;
			}
		}
	}
}
