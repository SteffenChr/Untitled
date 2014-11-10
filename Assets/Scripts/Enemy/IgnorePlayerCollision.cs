using UnityEngine;
using System.Collections;

public class IgnorePlayerCollision : MonoBehaviour {

	private GameObject Player;

	public int MyValue;

	void Awake()
	{
		Player = GameObject.FindGameObjectWithTag("Player");
		Physics.IgnoreCollision(Player.collider, collider);
		MyValue = SpawnEnemies.EnemyNumericValue;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
