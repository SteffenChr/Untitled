using UnityEngine;
using System.Collections;

public class CompanionPoint : MonoBehaviour
{
	public Transform playerPosition;
	public float XPositionRelativeToPlayer = 0;
	public float YPositionRelativeToPlayer = 0;
	public float ZPositionRelativeToPlayer = 0;
	
	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{
//		transform.position = playerPosition.position + new Vector3 (XPositionRelativeToPlayer, YPositionRelativeToPlayer, ZPositionRelativeToPlayer);
//		transform.LookAt(playerPosition);
	}
}

