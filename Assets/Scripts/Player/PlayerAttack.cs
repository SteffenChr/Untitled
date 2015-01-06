using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    private bool PlayerAttack01Activated = false;
    private bool PlayerAttack02Activated = true;
    private bool PlayerAttack03Activated = true;
    private bool CanMove = true;
    private float YPosition;
    private int TimeStamp;

    public Transform AttackPoint;
    public GameObject PlayerAttack01;
    public GameObject PlayerAttack02;
    public GameObject PlayerAttack03;
    public GameObject PlayerAttack04;
    public float PlayerAttack01Cooldown = 2.0F;
    public float PlayerAttack02Cooldown = 2.0F;
    public float PlayerAttack03Cooldown = 2.0F;
    public float PlayerAttack04Cooldown = 2.0F;
    public float AttackPointDistance = 5.0F;
    public float ComboTime = 3.0F;
    public float TimeDown01 = 0.1F;
    public float TimeDown02 = 0.1F;
    public float TimeDown03 = 0.1F;
    public float FloatUpSpeed = 2.0F;
    public float FloatDuration = 2.0F;

    public static bool PlayerAttackDestoy = false;
    public static bool PlayerAttack01Immobalize = false;
    public static bool PlayerAttack02Immobalize = false;
    public static bool PlayerAttack03Immobalize = false;
    public static bool PlayerAttack03Float = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //immobalized while attacking
        if (PlayerAttack01Immobalize || PlayerAttack02Immobalize || PlayerAttack03Immobalize)
        {
            CanMove = false;
        }
        else
        {
            YPosition = GameObject.FindGameObjectWithTag("Player").transform.position.y - 0.2F;
            CanMove = true;
        }

        if (PlayerAttack03Float == true)
        {
            //PrivateFloatSpeed = FloatUpSpeed;
            transform.Translate(Vector3.up * FloatUpSpeed);
            StartCoroutine(Floating());
        }
	}
    
    internal void PlayerAttacks(int attackNumber)
    {
        if (!PlayerAttack01Activated && attackNumber.Equals(1))
        {
            PlayerAttackDestoy = false;
            CreateAttackTransform(PlayerAttack01, PlayerAttack01Cooldown);
            PlayerAttack01Activated = true;
            PlayerAttack01Immobalize = true;
            StartCoroutine(CooldownPlayerAttack01());
        }

        if (!PlayerAttack02Activated && attackNumber.Equals(2))
        {
            PlayerAttackDestoy = false;
            CreateAttackTransform(PlayerAttack02, PlayerAttack02Cooldown);
            PlayerAttack02Activated = true;
            PlayerAttack02Immobalize = true;
            StartCoroutine(CooldownPlayerAttack02());
        }

        if (!PlayerAttack03Activated && attackNumber.Equals(3))
        {
            PlayerAttackDestoy = false;
            CreateAttackTransform(PlayerAttack03, PlayerAttack03Cooldown);
            PlayerAttack03Activated = true;
            PlayerAttack03Immobalize = true;
            PlayerAttack03Float = true;
            StartCoroutine(CooldownPlayerAttack03());
        }
    }

    private void CreateAttackTransform(GameObject playerTransform, float attackActiveTime)
    {
        GameObject instantiatedAttackObject = GameObject.Instantiate(playerTransform, AttackPoint.transform.position, AttackPoint.transform.rotation) as GameObject;
        instantiatedAttackObject.GetComponent<AttackObjectScript>().StartDestroyObejctSequence(attackActiveTime);
    }

    IEnumerator Floating()
    {
        yield return new WaitForSeconds(FloatDuration);
        //PrivateFloatSpeed = 0;
        transform.position = new Vector3(transform.position.x, YPosition, transform.position.z);
    }

    IEnumerator CooldownPlayerAttack01()
    {
        yield return new WaitForSeconds(PlayerAttack01Cooldown);
        PlayerAttackDestoy = true;
        StartCoroutine(DownTime01(TimeDown01));
    }

    IEnumerator CooldownPlayerAttack02()
    {
        yield return new WaitForSeconds(PlayerAttack02Cooldown);
        PlayerAttackDestoy = true;
        StartCoroutine(DownTime02(TimeDown02));
    }

    IEnumerator CooldownPlayerAttack03()
    {
        yield return new WaitForSeconds(PlayerAttack03Cooldown);
        StartCoroutine(CooldownPlayerAttack04());
    }

    IEnumerator CooldownPlayerAttack04()
    {
        CreateAttackTransform(PlayerAttack04, PlayerAttack04Cooldown);
        yield return new WaitForSeconds(PlayerAttack04Cooldown);
        PlayerAttackDestoy = true;
        PlayerAttack03Float = false;
        StartCoroutine(DownTime03(TimeDown03));
    }

    //short pause between despawn of previous attack and ability to attack again
    IEnumerator DownTime01(float TimeDown01)
    {
        yield return new WaitForSeconds(TimeDown01);
        PlayerAttack01Immobalize = false;
        PlayerAttack02Activated = false;
    }

    IEnumerator DownTime02(float TimeDown02)
    {
        yield return new WaitForSeconds(TimeDown02);
        PlayerAttack02Immobalize = false;
        PlayerAttack03Activated = false;
    }

    IEnumerator DownTime03(float TimeDown03)
    {
        yield return new WaitForSeconds(TimeDown03);
        PlayerAttack03Immobalize = false;
        PlayerAttack01Activated = false;
    }
}
