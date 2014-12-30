using UnityEngine;
using System.Collections;

public class AttackManagement : MonoBehaviour {

    private AttackPoint attackPoint;
    private CompanionDatabase companionDB;
    private GameObject[] activeCompanions;

    private int attackNumber = 1; //1=first attack 2=second attack 3=third attack

    public float ComboTime = 1.0F;

	// Use this for initialization
    void Start()
    {
        attackPoint = this.GetComponentInChildren<AttackPoint>();
        GameObject scripts = GameObject.FindGameObjectWithTag("Scripts");
        companionDB = scripts.GetComponent<CompanionDatabase>();
        GetCompanions();
        FillEmptyCompanionSpots();
	}

    /// <summary>
    /// Activate the player attack
    /// </summary>
    internal void PlayerAttack()
    {
        StartCombo();
        attackPoint.PlayerAttacks(attackNumber);
        IncreaseAttackNumber();
    }

    /// <summary>
    /// Activate the left companion attack
    /// </summary>
    internal void CompanionLeftAttack()
    {
        if (activeCompanions[(int)CompanionPosition.Left] != null)
        {
            StartCombo();
            activeCompanions[(int)CompanionPosition.Left].SendMessage("Attack",attackNumber);
            IncreaseAttackNumber();
        }
    }

    /// <summary>
    /// Activate the right companion attack
    /// </summary>
    internal void CompanionRightAttack()
    {
        if (activeCompanions[(int)CompanionPosition.Right] != null)
        {
            StartCombo();
            activeCompanions[(int)CompanionPosition.Right].SendMessage("Attack",attackNumber);
            IncreaseAttackNumber();
        }
    }
    /// <summary>
    /// Find the companions for the left and right position
    /// </summary>
    private void FillEmptyCompanionSpots()
    {
        if (isCompanionSpotEmpty(CompanionPosition.Left))
        {
            GetCompanion(CompanionPosition.Left);
        }

        if (isCompanionSpotEmpty(CompanionPosition.Right))
        {
            GetCompanion(CompanionPosition.Right);
        }
    }

    /// <summary>
    /// This methode starts the combo if it is the first attack
    /// </summary>
    private void StartCombo()
    {
        if(attackNumber==1)
            StartCoroutine(StartComboTimer());
    }

    /// <summary>
    /// This methode starts the combo timer. It will wait ComboTime seconds, 
    /// before it resets the attack number and thereby the combo.
    /// </summary>
    /// <returns></returns>
    private IEnumerator StartComboTimer()
    {
        yield return new WaitForSeconds(ComboTime);
        ResetAttackNumber();
    }

    /// <summary>
    /// Sets the companion to eiher left or right, depending on the position
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
    private void GetCompanions()
    {
        activeCompanions = GameObject.FindGameObjectsWithTag("Companion");
    }

    /// <summary>
    /// Increase the attacknumber with one
    /// </summary>
    private void IncreaseAttackNumber()
    {
        if (attackNumber < 3)
            attackNumber++;
        else
            ResetAttackNumber();
    }

    /// <summary>
    /// Reset the combo to be the first combo again
    /// </summary>
    private void ResetAttackNumber()
    {
        attackNumber = 1;
    }
}
