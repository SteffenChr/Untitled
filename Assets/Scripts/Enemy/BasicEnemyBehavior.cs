﻿using UnityEngine;
using System.Collections;

public class BasicEnemyBehavior : MonoBehaviour {

	private GameObject Player;
	private bool CollideWithAlly;
	private int AllyValue;
	private float RandomDirection;
	private bool Stop = false;
	private bool AttackedStop = false;
	private float ForwardSpeed;
	private int MyValue;
	private int MyWaveNumber;
	private float NewHalt;
	private float NewAlmostHalt;
	private float PrivateFloatSpeed;
	private bool FloatAttacked = false;
	private bool KnockedBack = false;
	private float FloatingYPosition;
	private NavMeshAgent agent;

	public float Speed = 2.0F;
	public float BackSpeed = 2.0F;
	public float SideSpeed = 2.0F;
	public float ProxySpeed = 2.0F;
	public float ShakeSpeed = 2.0F;
	public float FloatUpSpeed = 2.0F;
	public float FloatDuration = 1.0F;
	public float ShakeDirectionChangeTime = 0.5F;
	public float Halt = 2.0F;
	public float BackOff = 2.0F;
	public float YPosition = 0.0F;
	public float AlmostHalt = 2.0F;
	public float ForwardStop = 2.0F;
	public float ProximityToPlayer = 2.0F;
	public float AttackedForwardStop = 0.5F;
	public float FloatingAttackForwardStop = 0.6F;
	public float KnockbackForwardStop =0.8F;
	public float KnockbackSpeed = 2.0F;
	public float HaltDivider = 8.0F;

	void Awake()
	{
		Player = GameObject.FindGameObjectWithTag("Player");
		agent = GetComponent<NavMeshAgent>();
		MyValue = SpawnEnemies.EnemyNumericValue;
		MyWaveNumber = SpawnEnemies.WaveNumber;
		NewHalt = Halt + MyWaveNumber - (SpawnEnemies.HaltModifier/HaltDivider);
		NewAlmostHalt = Halt + MyWaveNumber + AlmostHalt - (SpawnEnemies.HaltModifier/HaltDivider);
	}

	// Update is called once per frame
	void Update () 
	{
		agent.SetDestination(Player.transform.position);
		//get different values based on when it enemy is spawned and how many are killed, used to determine how close enemy gets to player

        if (AttackedStop || Stop)
        {
            agent.Stop();
        }
//		float Dist = Vector3.Distance(Player.transform.position, transform.position);
//		NewHalt = Halt + MyWaveNumber - (SpawnEnemies.HaltModifier/HaltDivider);
//		NewAlmostHalt = Halt + MyWaveNumber + AlmostHalt - (SpawnEnemies.HaltModifier/HaltDivider);
//
//		if(Halt > NewHalt)
//		{
//			NewHalt = Halt;
//		}
//		//slow when close to player
//		if(Dist < ProximityToPlayer)
//			ForwardSpeed = ProxySpeed;
//		else
//			ForwardSpeed = Speed;
//
//		//move towards player
//		if( Dist > NewHalt && Stop == false && AttackedStop == false)
//		{
//			transform.LookAt(Player.transform);
//			transform.Translate (Vector3.forward * ForwardSpeed);
//		}
//
//		//back off if player gets too close
//		if(Dist < BackOff && AttackedStop == false)
//		{
//			transform.Translate (Vector3.back * BackSpeed);
//		}
//
//		//move to a random side if colliding with another enemy
//		if(CollideWithAlly == true && Dist > NewAlmostHalt && AttackedStop == false)
//		{
//			if(RandomDirection < 0.5)
//			{
//				transform.Translate (Vector3.right * SideSpeed);
//			}
//			else
//				transform.Translate (Vector3.left * SideSpeed);
//		}
//
//		if(FloatAttacked == true)
//		{
//			PrivateFloatSpeed = FloatUpSpeed;
//			transform.Translate(Vector3.up * PrivateFloatSpeed);
//
//			StartCoroutine(Floating());
//		}
//		else if(KnockedBack == true)
//		{
//			transform.Translate (Vector3.back * KnockbackSpeed);
//			transform.position = new Vector3(transform.position.x,FloatingYPosition,transform.position.z);
//		}
//		else
//			transform.position = new Vector3(transform.position.x,YPosition,transform.position.z);

		//if(KnockedBack == false && FloatAttacked == false)
			//transform.position = new Vector3(transform.position.x,YPosition,transform.position.z);
	}

	//triggers to determine what happens when colliding with other objects
	void OnTriggerEnter(Collider collider)
	{
        print(collider.name);
		if(collider.name.Equals("PlayerAttack01(Clone)"))
		{
			StartCoroutine(AttackedStopForward());
			StartCoroutine(ShakeLeftRight());
		}

        if (collider.name.Equals("PlayerAttack02(Clone)"))
		{
			StartCoroutine(AttackedStopForward());
			StartCoroutine(ShakeLeftRight());
		}

        if (collider.name.Equals("PlayerAttack03(Clone)"))
		{
			StartCoroutine (FloatingAttackedStopForward());
			FloatAttacked = true;
		}

        if (collider.name.Equals("PlayerAttack04(Clone)"))
		{
			FloatingYPosition = transform.position.y;
			StartCoroutine(Knockback());
		}

		if(collider.CompareTag("Enemy"))
		{
			float DistPlayer = Vector3.Distance(Player.transform.position, transform.position);
			AllyValue = collider.gameObject.GetComponent<IgnorePlayerCollision> ().MyValue;

			if(AllyValue != MyValue && DistPlayer >= NewAlmostHalt )
			{
				StartCoroutine(StopForward());
				CollideWithAlly = true;
				RandomDirection = Random.value;

			}
			if(AllyValue != MyValue && DistPlayer <= NewAlmostHalt )
			{
				CollideWithAlly = true;
				RandomDirection = Random.value;
			}
		}
	}

	void OnTriggerStay(Collider collider)
	{
		float DistPlayer = Vector3.Distance(Player.transform.position, transform.position);
		//float NewAlmostHalt = Halt + MyWaveNumber + AlmostHalt -(SpawnEnemies.HaltModifier/HaltDivider);


		if(collider.CompareTag("Enemy"))
		{
			if(AllyValue != MyValue && DistPlayer >= NewAlmostHalt )
			{
				CollideWithAlly = true;
			}
		}
	}
	
	void OnTriggerExit(Collider collider)
	{
		if(AllyValue != MyValue && collider.CompareTag("Enemy"))
		{
			CollideWithAlly = false;
		}
	}

	IEnumerator StopForward()
	{
		Stop = true;
		yield return new WaitForSeconds (ForwardStop);
        StartAgent();
	}

    private void StartAgent()
    {
        AttackedStop = false;
        Stop = false;
        agent.Resume();
    }

	IEnumerator AttackedStopForward()
	{
		AttackedStop = true;
		yield return new WaitForSeconds (AttackedForwardStop);
        StartAgent();
	}

	IEnumerator FloatingAttackedStopForward()
	{
		AttackedStop = true;
		yield return new WaitForSeconds (FloatingAttackForwardStop);
        StartAgent();
	}

	IEnumerator Knockback()
	{
		AttackedStop = true;
		KnockedBack = true;
		yield return new WaitForSeconds (KnockbackForwardStop);
		KnockedBack = false;
        StartAgent();
	}

	IEnumerator ShakeLeftRight()
	{
		transform.Translate (Vector3.left * ShakeSpeed);
		yield return new WaitForSeconds (ShakeDirectionChangeTime);
		transform.Translate (Vector3.right * ShakeSpeed);
		yield return new WaitForSeconds (ShakeDirectionChangeTime);
		transform.Translate (Vector3.left * ShakeSpeed);
		yield return new WaitForSeconds (ShakeDirectionChangeTime);
		transform.Translate (Vector3.right * ShakeSpeed);
		yield return new WaitForSeconds (ShakeDirectionChangeTime);
		transform.Translate (Vector3.left * ShakeSpeed);
	}

	IEnumerator Floating()
	{
		yield return new WaitForSeconds (FloatDuration);
		PrivateFloatSpeed = 0;
		FloatAttacked = false;
		//transform.position = new Vector3(transform.position.x,YPosition,transform.position.z);
	}


}