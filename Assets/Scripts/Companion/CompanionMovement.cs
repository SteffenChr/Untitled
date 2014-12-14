using UnityEngine;
using System.Collections;

/**
 * Everything that has to do with the companions normal movement AI
 */
public class CompanionMovement : MonoBehaviour {

	public Transform companionPoint;

	private NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		agent.SetDestination(companionPoint.position);
	}
}
