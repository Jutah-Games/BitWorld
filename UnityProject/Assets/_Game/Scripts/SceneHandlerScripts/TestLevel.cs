using UnityEngine;
using System.Collections;

public class TestLevel : MonoBehaviour {

	_HandlerUtilities handler;
	
	private CameraFollow cameraFollow;

	void Awake () {
		cameraFollow = GetComponent<CameraFollow>();

	}

	// Use this for initialization
	void Start () {
		Debug.Log(Application.loadedLevelName);

		_HandlerUtilities.PlaceCamera(cameraFollow.maxXAndY.x, cameraFollow.maxXAndY.y);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
