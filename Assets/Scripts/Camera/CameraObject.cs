using UnityEngine;
using System.Collections;

public class CameraObject : MonoBehaviour {

	private float Speed;
	private bool AtPlayer;
	private float RandomShakeFactorX;
	private float RandomShakeFactorZ;

	public Transform Player;
	public float SpeedMultiplyer = 0.01F;
	public float CameraShakeSpeed = 1.0F;
	public float ShakeReducer = 0.5F;


	// Use this for initialization
	void Start () {
	
	}
	

	// Update is called once per frame
	void Update () 
	{

		float Dist = Vector3.Distance(Player.position, transform.position);
		Speed = Dist*SpeedMultiplyer;	

		if(AtPlayer==false && Dist > 0.01)
		{
		transform.LookAt(Player);
		transform.Translate (Vector3.forward * Speed);
		}

		if (Dist < 0.01) 
		{
			AtPlayer = true;
		}

		if (Input.GetKeyDown("space"))
		{
			StartCoroutine(SpaceBarShake());
		}
		

	}
		
	public void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player")) 
		{
			AtPlayer = false;
		}
	}

	IEnumerator SpaceBarShake()
	{
		RandomShakeFactorX = Player.position.x + Random.value * ShakeReducer;
		RandomShakeFactorZ = Player.position.z + Random.value * ShakeReducer;
		transform.position = new Vector3 (RandomShakeFactorX, transform.position.y, RandomShakeFactorZ );
		yield return new WaitForSeconds (CameraShakeSpeed);
		RandomShakeFactorX = Player.position.x - Random.value * ShakeReducer;
		RandomShakeFactorZ = Player.position.z - Random.value * ShakeReducer;
		transform.position = new Vector3 (RandomShakeFactorX, transform.position.y,RandomShakeFactorZ );
		yield return new WaitForSeconds (CameraShakeSpeed);
		RandomShakeFactorX = Player.position.x + Random.value * ShakeReducer;
		RandomShakeFactorZ = Player.position.z + Random.value * ShakeReducer;
		transform.position = new Vector3 (RandomShakeFactorX, transform.position.y, RandomShakeFactorZ );
		yield return new WaitForSeconds (CameraShakeSpeed);
		RandomShakeFactorX = Player.position.x - Random.value * ShakeReducer;
		RandomShakeFactorZ = Player.position.z - Random.value * ShakeReducer;
		transform.position = new Vector3 (RandomShakeFactorX, transform.position.y,RandomShakeFactorZ );
		yield return new WaitForSeconds (CameraShakeSpeed);
		RandomShakeFactorX = Player.position.x + Random.value * ShakeReducer;
		RandomShakeFactorZ = Player.position.z + Random.value * ShakeReducer;
		transform.position = new Vector3 (RandomShakeFactorX, transform.position.y, RandomShakeFactorZ );
		yield return new WaitForSeconds (CameraShakeSpeed);
		transform.position = new Vector3 (Player.position.x, Player.position.y, Player.position.z);
	}
}
