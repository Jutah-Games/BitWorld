using UnityEngine;
using System.Collections;

public class _HandlerUtilities : MonoBehaviour {
	/*
	 * TODO
	 * 	- Create functions where the camera can get data from handlers without much conding 
	*/
	
	public static void PlaceCamera(float x, float y) {
		switch(Application.loadedLevelName){
		case "TestSceneSwitch":
			x = 13;
			y = 10;
			break;
		case "TestLevel":
			x = 8;
			y = 6;
			break;
		default:
			x = 10;
			y = 8;
			break;
		}
	}
}