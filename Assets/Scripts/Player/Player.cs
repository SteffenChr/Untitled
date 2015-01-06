using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private bool canMove;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool CanMove { get { return canMove; } set { value = canMove; } }
}
