using UnityEngine;
using System.Collections;

public class CameraPosition : MonoBehaviour {

	public Transform CameraObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = CameraObject.position;
	}
}
