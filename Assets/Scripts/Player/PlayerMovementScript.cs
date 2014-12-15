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
	public float Division = 0.5F; //This is a procentage which defines how fast it should move diagonaly compared to normal speed

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

		if(AttackPoint.PlayerAttack03Float == true)
		{
			//PrivateFloatSpeed = FloatUpSpeed;
			transform.Translate(Vector3.up * FloatUpSpeed);
			StartCoroutine(Floating());
		}
	}

	public void RunStrait(Vector3 direction)
	{
		if(CanMove){
			transform.forward = direction;
			transform.Translate(Vector3.forward * Speed);
		}
	}

	public void RunDiagonal(Vector3 direction)
	{
		if(CanMove){
			transform.forward = direction;
			transform.Translate(Vector3.forward * (Speed*Division));
		}
	}

	IEnumerator Floating()
	{
		yield return new WaitForSeconds (FloatDuration);
		transform.position = new Vector3(transform.position.x,YPosition,transform.position.z);
	}
}