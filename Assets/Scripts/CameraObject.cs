using UnityEngine;
using System.Collections;

public class CameraObject : MonoBehaviour {

	private float Speed;
	private bool AtPlayer;

	public Transform Player;
	public float SpeedMultiplyer = 0.01F;



	// Use this for initialization
	void Start () {
	
	}
	

	// Update is called once per frame
	void Update () 
	{

			float Dist = Vector3.Distance(Player.position, transform.position);
			//Debug.Log (Dist);
			Speed = Dist*SpeedMultiplyer;	

			if(AtPlayer==false && Dist > 0.01)
			{
			transform.LookAt(Player);
			transform.Translate (Vector3.forward * Speed);
			}

			if (Dist < 0.01) 
			{
				AtPlayer = true;
			}
	}
		
	public void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player")) 
		{
			AtPlayer = false;
			//Debug.Log ("false");
		}
	}
}
