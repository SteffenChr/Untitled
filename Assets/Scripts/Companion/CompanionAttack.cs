using UnityEngine;
using System.Collections;

public class CompanionAttack : MonoBehaviour {

    public float damageDealing;
    public float attackCooldown;
    public Transform attackTransform;
    public float cooldownTimeUntilNextAttack;
    public int attackNumber;

    private bool isAttackUsable = true;
    private GameObject attackPoint;

    void Start()
    {
        attackPoint = GameObject.FindGameObjectWithTag("AttackPoint");
    }

    void Update()
    {
        
    }

    private void InstantiateAttack(Transform attackTransform)
    {
        throw new System.NotImplementedException();
    }

    private void CooldownAttack(float attackCooldown)
    {
        throw new System.NotImplementedException();
    }

    private void WaitUntilNextAttack(float cooldown)
    {
        throw new System.NotImplementedException();
    }

    public bool IsAttackUsable { get; set; }
}
