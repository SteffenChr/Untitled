using UnityEngine;
using System.Collections;

/*
 * The companion class is used on all companions and contains the basic functionalities and attributes
 */
public class Companion {

    public string name;
    public int id;
    public int life;
    public float movementSpeed;

    private bool canMove;
    private bool isActive;
    private Vector3 companionDestination;
    
	public void KnockOut(){
		
	}

	public Vector3 CompanionDestination{ get; set; }
    public bool CanMove { get; set; }
    public bool IsActive { get; set; }
}
