using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public float Health = 100;
    
	// Update is called once per frame
	void Update () 
	{
		if(Health <= 0)
		{
			SpawnEnemies.HaltModifier += 1;
			Destroy(this.gameObject);
		}
	}

    /// <summary>
    /// This is what happens when a trigger enters the enemy collider
    /// </summary>
    /// <param name="collider"></param>
	void OnTriggerEnter(Collider collider)
	{
		if(collider.CompareTag("DealEnemyDamage"))
		{
            Health = Health - collider.GetComponent<DamageDealing>().damageDealing;
		}
	}
}
