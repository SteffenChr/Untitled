﻿using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {


	public float Health = 100;
	public float PlayerAttack01Damage = 20;
	public float PlayerAttack02Damage = 30;
	public float PlayerAttack03Damage = 50;
	public float PlayerAttack04Damage = 20;

	void Awake()
	{

	}

	// Update is called once per frame
	void Update () 
	{



		if(Health <= 0)
		{
			SpawnEnemies.HaltModifier += 1;
			Destroy(this.gameObject);
		}
	}
	

	void OnTriggerEnter(Collider collider)
	{
		if(collider.CompareTag("PlayerAttack01"))
		{
			Health = Health - PlayerAttack01Damage;
		}
		
		if(collider.CompareTag("PlayerAttack02"))
		{
			Health = Health - PlayerAttack02Damage;
		}
		
		if(collider.CompareTag("PlayerAttack03"))
		{
			Health = Health - PlayerAttack03Damage;
		}

		if(collider.CompareTag("PlayerAttack04"))
		{
			Health = Health - PlayerAttack04Damage;
		}
	}

}
