using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// This class takes care of all the inputs from the player during playtime.
/// </summary>
public class PlayerInput : MonoBehaviour
{
    private PlayerMovementScript playerMovementScript;
    private AttackManagement attManagement;

	// Use this for initialization
	void Start ()
	{
		playerMovementScript = this.GetComponent<PlayerMovementScript>();
        attManagement = this.GetComponent<AttackManagement>();
        
	}
	// Update is called once per frame
	void FixedUpdate ()
	{
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
        if (Input.GetButtonDown("PlayerAttack"))
        {
            attManagement.PlayerAttack();
        }

        //Left companion attack
        if (Input.GetButtonDown("Companion1Attack"))
        {
            attManagement.CompanionLeftAttack();
        }

        //Right companion attack
        if (Input.GetButtonDown("Companion2Attack"))
        {
            attManagement.CompanionRightAttack();
        }
	}
}

