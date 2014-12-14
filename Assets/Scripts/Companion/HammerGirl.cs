using UnityEngine;
using System.Collections;

public class HammerGirl : MonoBehaviour {

    public int damageDealing;
    public float puchDistance;
    public float wormHoleRadius;
    public float wormHoleForce;
    public int wormHoleDamage;
    public int attack3Damage;
    public float attack3Radius;

    public Transform attack1;
    public Transform attack2;
    public Transform attack3;

    private GameObject attackPoint;

    void Start(){
        attackPoint = GameObject.FindGameObjectWithTag("AttackPoint");
    }

    public void Attack()
    {

    }

	private void StartAttack1()
	{
        Instantiate(attack3, attackPoint.transform.position,attackPoint.transform.rotation);
	}

    private void StartAttack2()
	{
		throw new System.NotImplementedException();
	}

    private void StartAttack3()
	{
		throw new System.NotImplementedException();
	}

}
