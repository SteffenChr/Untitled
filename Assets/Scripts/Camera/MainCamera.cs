using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

	public Transform CameraPositionObject;
	public float CameraBack = 15.0F;
	public float CameraUp = 15.0F;

	// Use this for initialization
	void Start () 
	{
		transform.position = CameraPositionObject.position + new Vector3 (0, CameraUp, -CameraBack);
		transform.LookAt (CameraPositionObject);
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
}
