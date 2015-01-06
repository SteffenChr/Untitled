using UnityEngine;
using System.Collections;

public class PlayerHealt : MonoBehaviour
{
    public GameObject prefabHeart;

    private int currentPlayerHealt;
    private static int maxPlayerHealt;

    void Start()
    {
        CurrentPlayerHealt = 8;
        SetPlayerHealt();
    }

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
        SetPlayerHealt();
    }

    /// <summary>
    /// This handles what will happen on collision enter with the healt of the player.
    /// </summary>
    /// <param name="coll"></param>
    void OnCollisionEnter(Collision coll)
    {
        if (coll.transform.CompareTag("Enemy"))
        {
            int enemyDamage = coll.gameObject.GetComponent<Enemy>().damageDealing;
            ReducePlayerHealt(enemyDamage);
            SetPlayerHealt();
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
        SetPlayerHealt();
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

    /// <summary>
    /// Makes sure that the player healt UI is correct
    /// </summary>
    private void SetPlayerHealt()
    {
        //float floatAmount = CalculateCurrentHealt();
        ChangePlayerUI(CurrentPlayerHealt);
    }

    /// <summary>
    /// Sets the hearts in the player UI, 1 heart per life
    /// </summary>
    private void ChangePlayerUI(int life)
    {
        GameObject playerUI = GameObject.FindGameObjectWithTag("PlayerUI");
        GameObject[] hearts = GameObject.FindGameObjectsWithTag("PlayerHeart");

        DeleteAllInArray(hearts);

        for (int i = 0; i < life; i++)
        {
            InstantiateAndSetParent(prefabHeart, playerUI);
        }
    }

    /// <summary>
    /// Delets the items in the array from the scene
    /// </summary>
    /// <param name="arrayList">The arraylist of items that needs to be deleted from the scene</param>
    private void DeleteAllInArray(GameObject[] arrayList)
    {
        foreach (GameObject arrayItem in arrayList)
        {
            Destroy(arrayItem);
        }
    }

    /// <summary>
    /// This functions instantiates a prefab and sets the prefabs parent object
    /// </summary>
    /// <param name="prefab">The prefab to be instantiated</param>
    /// <param name="parent">The parent of the new instance gameobject</param>
    /// <returns>The instantiated gameobejct</returns>
    private GameObject InstantiateAndSetParent(GameObject prefab, GameObject parent)
    {
        GameObject newInstance = Instantiate(prefab) as GameObject;
        newInstance.transform.SetParent(parent.transform, false);
        return newInstance;
    }

    /// <summary>
    /// This methode calculates the player int healt into float
    /// </summary>
    /// <returns>the life value in float</returns>
    private float CalculateCurrentHealt()
    {
        //CurrentPlayerHealt as
        //if(life)
        //float floatLife = life / 4;
        return 0F;
    }

    public int CurrentPlayerHealt { get; set; }

    public int MaxPlayerHealt { get { return maxPlayerHealt; } }
}

