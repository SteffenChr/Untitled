using UnityEngine;
using System.Collections;

public class CompanionAttack : MonoBehaviour {

    public float damageDealing; //The damage the attack inflicts on the enemy
    public float attackCooldown; //The cooldown before the attack can be used again
    public Transform attackTransform; //The transform used in the attack
    public float cooldownTimeUntilNextAttack; //The length of the animation
    public int attackNumber; //The number of the attack in the combo

    private bool isAttackUsable = true;
    private AttackPoint attackPoint;

    void Start()
    {
        attackPoint = GameObject.FindGameObjectWithTag("AttackPoint").GetComponent<AttackPoint>();
    }

    void Update()
    {
        
    }

    /// <summary>
    /// Instantiates the transform used in the attack
    /// </summary>
    public void InstantiateAttack()
    {
        attackPoint.InstantiateAttack(transform);
    }

    private void CooldownAttack(float attackCooldown)
    {
        throw new System.NotImplementedException();
    }

    private void WaitUntilNextAttack(float cooldown)
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// This methode determinds if the attack is the same as the order
    /// </summary>
    /// <param name="attackNum">The number of the attack in the combo</param>
    public virtual void Attack(int attackNum)
    {
        if (attackNum.Equals(attackNumber))
        {
            InstantiateAttack();
        }
    }

    public bool IsAttackUsable { get; set; }
}
