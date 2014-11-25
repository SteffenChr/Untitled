using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour
{
	private PlayerMovementScript playerMovementScript;

	// Use this for initialization
	void Start ()
	{
		playerMovementScript = this.GetComponent<PlayerMovementScript>();
	}

	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKey("d") && Input.GetKey("w"))
		{
			playerMovementScript.RunDiagonal(new Vector3(1,0,1));
		}
		else if (Input.GetKey("w") && Input.GetKey("a"))
		{
			playerMovementScript.RunDiagonal(new Vector3(-1,0,1));
		}
		else if (Input.GetKey("a") && Input.GetKey("s"))
		{
			playerMovementScript.RunDiagonal(new Vector3(-1,0,-1));
		}
		else if (Input.GetKey("s") && Input.GetKey("d"))
		{
			playerMovementScript.RunDiagonal(new Vector3(1,0,-1));
		}
		else if (Input.GetKey("w"))
		{
			playerMovementScript.RunStrait(Vector3.forward);
		}
		else if (Input.GetKey("s"))
		{
			playerMovementScript.RunStrait(Vector3.back);
		}
		else if (Input.GetKey("a"))
		{
			playerMovementScript.RunStrait(Vector3.left);
		}
		else if (Input.GetKey("d"))
		{
			playerMovementScript.RunStrait(Vector3.right);
		}
	}
}

