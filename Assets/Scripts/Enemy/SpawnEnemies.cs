using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour {

	private bool PrivateSpawn = false;
	private int PrivateStartCount = 0;
	private int PrivateNumericValue;
	private int WaveNumberCount = 0;

	public static bool Spawned = false;
	public static int EnemyNumericValue;
	public static int WaveNumber = 0;
	public static int HaltModifier;
	public float SpawnTime = 5.0F;
	public Transform BasicEnemy;
	public int StartCount = 0;
	public int SpawnAmount = 10;
	public int SpawnPointNumber = 0;

	// Use this for initialization
	void Start () 
	{
		PrivateNumericValue = StartCount;
	}
	
	// Update is called once per frame
	void Update () {
		EnemyNumericValue = PrivateNumericValue;
		WaveNumber = WaveNumberCount;

		if(PrivateSpawn == false && PrivateStartCount != SpawnAmount)
		{
			StartCoroutine (Spawn (SpawnTime));
		}
	}

    /// <summary>
    /// The methode spawns the enemy into the scene with a cooldown.
    /// </summary>
    /// <param name="SpawnTime">The cooldown until next spawn</param>
	IEnumerator Spawn(float SpawnTime)
	{
		Instantiate (BasicEnemy, transform.position, transform.rotation);
		Spawned = true;
		PrivateSpawn = true;
		yield return new WaitForSeconds (SpawnTime);
		PrivateNumericValue = PrivateNumericValue + 1;
		PrivateStartCount = PrivateStartCount + 1;
		WaveNumberCount = WaveNumberCount + 1;
		Spawned = false;
		PrivateSpawn = false;
	}
}
