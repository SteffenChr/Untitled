using UnityEngine;
using System.Collections;

public class PlayerMovementScript : MonoBehaviour 
{
	private bool CanMove = true;
	//private float PrivateFloatSpeed;
	private float YPosition;

	public float Speed = 5.0F;
	public float FloatUpSpeed = 2.0F;
	public float FloatDuration = 2.0F;
	public float Division = 2.0F;

	// Use this for initialization
	void Start () 
	{
		YPosition = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () 
	{ 
		float ActualSpeed = Speed;
		/*
		//Xbox controller input. Dosn't work at the moment
		float translationVert = Input.GetAxis ("Vertical") * Speed;
		float translationHori = Input.GetAxis ("Horizontal") * Speed;
		transform.Translate (0, 0, translationVert);
		transform.Translate (translationHori, 0, 0);
		*/

		//immobalized while attacking
		if(AttackPoint.PlayerAttack01Immobalize == true)
		{
			CanMove = false;
		}
		else if(AttackPoint.PlayerAttack02Immobalize == true)
		{
			CanMove = false;
		}
		else if(AttackPoint.PlayerAttack03Immobalize == true)
		{
			CanMove = false;
		}
		else
		{
			CanMove = true;
		}

		if(CanMove == true){
			if(Input.GetKey("d") && Input.GetKey("w"))
			{
				transform.forward = new Vector3(1,0,1);
				RunDiagonal();
			}
			else if (Input.GetKey("w") && Input.GetKey("a"))
			{
				transform.forward = new Vector3(-1,0,1);
				RunDiagonal();
			}
			else if (Input.GetKey("a") && Input.GetKey("s"))
			{
				transform.forward = new Vector3(-1,0,-1);
				RunDiagonal();
			}
			else if (Input.GetKey("s") && Input.GetKey("d"))
			{
				transform.forward = new Vector3(1,0,-1);
				RunDiagonal();
			}
			else if (Input.GetKey("w"))
			{
				transform.forward = Vector3.forward;
				RunStrait();
			}
			else if (Input.GetKey("s"))
			{
				transform.forward = Vector3.back;
				RunStrait();
			}
			else if (Input.GetKey("a"))
			{
				transform.forward = Vector3.left;
				RunStrait();
			}
			else if (Input.GetKey("d"))
			{
				transform.forward = Vector3.right;
				RunStrait();
			}
		}

		//making sure you don't get double speed while moving diagonally
	

		if(AttackPoint.PlayerAttack03Float == true)
		{
			//PrivateFloatSpeed = FloatUpSpeed;
			transform.Translate(Vector3.up * FloatUpSpeed);
			StartCoroutine(Floating());
		}
	}

	void RunStrait ()
	{
		transform.Translate(Vector3.forward * Speed);
	}

	void RunDiagonal ()
	{
		transform.Translate(Vector3.forward * (Speed/Division));
	}

	IEnumerator Floating()
	{
		yield return new WaitForSeconds (FloatDuration);
		//PrivateFloatSpeed = 0;
		transform.position = new Vector3(transform.position.x,YPosition,transform.position.z);
	}
}