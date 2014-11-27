using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour
{
	private PlayerMovementScript playerMovementScript;
    private AttackPoint attackPoint;

	// Use this for initialization
	void Start ()
	{
		playerMovementScript = this.GetComponent<PlayerMovementScript>();
        attackPoint = this.GetComponentInChildren<AttackPoint>();
	}

	// Update is called once per frame
	void Update ()
	{
		//ALL INPUT SHOULD USE THE INPUT FROM UNITY, NOT GetKey
        //Player movement (use axis for joystick)
        if (Input.GetButton("Left") && Input.GetButton("Forward"))
		{
			playerMovementScript.RunDiagonal(new Vector3(-1,0,1));
		}
        else if (Input.GetButton("Forward") && Input.GetButton("Right"))
		{
			playerMovementScript.RunDiagonal(new Vector3(1,0,1));
		}
        else if (Input.GetButton("Left") && Input.GetButton("Back"))
		{
			playerMovementScript.RunDiagonal(new Vector3(-1,0,-1));
		}
        else if (Input.GetButton("Back") && Input.GetButton("Right"))
		{
			playerMovementScript.RunDiagonal(new Vector3(1,0,-1));
		}
		else if (Input.GetButton("Forward"))
		{
			playerMovementScript.RunStrait(Vector3.forward);
		}
        else if (Input.GetButton("Back"))
		{
			playerMovementScript.RunStrait(Vector3.back);
		}
		else if (Input.GetButton("Left"))
		{
			playerMovementScript.RunStrait(Vector3.left);
		}
		else if (Input.GetButton("Right"))
		{
			playerMovementScript.RunStrait(Vector3.right);
		}

        //Player attack
        if (Input.GetButton("Attack"))
        {
            attackPoint.PlayerAttacks();
        }
	}
}

