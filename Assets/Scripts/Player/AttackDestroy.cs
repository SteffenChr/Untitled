using UnityEngine;
using System.Collections;

public class AttackDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (AttackPoint.PlayerAttackDestoy == true) 
		{
			Destroy(this.gameObject);
		}
	}
}
