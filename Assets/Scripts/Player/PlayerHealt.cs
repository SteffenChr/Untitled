using UnityEngine;
using System.Collections;

public class PlayerHealt : MonoBehaviour
{
    private int currentPlayerHealt;
    private static int maxPlayerHealt;

    void Update()
    {
        if(CurrentPlayerHealt <= 0){
            PlayerIsDead();
        }
    }

    /// <summary>
    /// This methode is called when the players life is less than or equal to zero
    /// </summary>
    private void PlayerIsDead()
    {
        print("You are dead :-(  Life restored to 10");
        CurrentPlayerHealt = 10;
    }

    /// <summary>
    /// This handles what will happen on collision enter with the healt of the player.
    /// </summary>
    /// <param name="coll"></param>
    void OnCollisionEnter(Collision coll)
    {
        if (coll.transform.CompareTag("Enemy"))
        {
            ReducePlayerHealt(1);
        }
    }

    /// <summary>
    /// This methode reduces the player healt with the variable amount
    /// </summary>
    /// <param name="p">The damage done to the player</param>
    private void ReducePlayerHealt(int amount)
    {
        CurrentPlayerHealt -= amount; 
    }

    /// <summary>
    /// Add life to the player healt. If the life added exceeds the max player healt, you will only get to the maximum amount.
    /// </summary>
    /// <param name="amount">The amount to add to the player</param>
    public void AddToPlayerHealt(int amount)
    {
        if (!ExceedsMaxPlayerHealt(amount))
        {
            CurrentPlayerHealt += amount;
        }
        else
        {
            CurrentPlayerHealt = MaxPlayerHealt;
        }
    }

    /// <summary>
    /// This is a control to see if the amount being added to the players healt exceeds the players maximum healt.
    /// </summary>
    /// <param name="amount">The amount to add to the player healt</param>
    /// <returns>True if the amount plus the player healt exceeds the player healt, otherwise false</returns>
    private bool ExceedsMaxPlayerHealt(int amount)
    {
        return (CurrentPlayerHealt + amount) > MaxPlayerHealt ? true : false;
    }

    public int CurrentPlayerHealt { get; set; }

    public int MaxPlayerHealt { get { return maxPlayerHealt; } }
}

