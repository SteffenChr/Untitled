using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// This class takes care of all the inputs from the player during playtime.
/// </summary>
public class PlayerInput : MonoBehaviour
{
	private PlayerMovementScript playerMovementScript;
    private AttackPoint attackPoint;
    private CompanionDatabase companionDB;

    private GameObject[] activeCompanions;

	// Use this for initialization
	void Start ()
	{
		playerMovementScript = this.GetComponent<PlayerMovementScript>();
        attackPoint = this.GetComponentInChildren<AttackPoint>();
        GameObject scripts = GameObject.FindGameObjectWithTag("Scripts");
        companionDB = scripts.GetComponent<CompanionDatabase>();
        
        getCompanions();
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
        if (Input.GetButton("PlayerAttack"))
        {
            attackPoint.PlayerAttacks();
        }

        //Left companion attack
        if (Input.GetButton("Companion1Attack"))
        {
            if (isCompanionSpotEmpty(CompanionPosition.Left))
            {
                GetCompanion(CompanionPosition.Left);
            }

            if (activeCompanions[(int)CompanionPosition.Left] != null)
            {
                activeCompanions[(int)CompanionPosition.Left].SendMessage("Attack");
            }

            

        }

        //Right companion attack
        if (Input.GetButton("Companion2Attack"))
        {
            if (isCompanionSpotEmpty(CompanionPosition.Right))
            {
                GetCompanion(CompanionPosition.Right);
            }

            if (activeCompanions[(int)CompanionPosition.Right] != null)
            {
                activeCompanions[(int)CompanionPosition.Right].SendMessage("Attack");
            }
        }

        
	}

    /// <summary>
    /// 
    /// </summary>
    /// <param name="position">the position of the companion. 1=left, 2=right</param>
    private void GetCompanion(CompanionPosition position)
    {
        Companion companion = companionDB.GetCompanion((int)position);
        if (companion != null)
        {
            GameObject[] companions = GameObject.FindGameObjectsWithTag("Companion");
            foreach (GameObject obj in companions)
            {
                if (obj.name.Equals(companion.name))
                {
                    activeCompanions[(int)position] = obj;
                }
            }
        }
    }

    /// <summary>
    /// Used to see if positions in the activeCompanions list is empty
    /// </summary>
    /// <param name="companionPosition">The companion spot that needs to tjecked 1=left, 2=right</param>
    /// <returns>True == null | False != null</returns>
    private bool isCompanionSpotEmpty(CompanionPosition companionPosition)
    {
        if (activeCompanions[(int)companionPosition] == null)
            return true;
        else
            return false;
    }

    /// <summary>
    /// Used to get all the active companions in the scene view
    /// </summary>
    private void getCompanions()
    {
        activeCompanions = GameObject.FindGameObjectsWithTag("Companion");
    }

}

