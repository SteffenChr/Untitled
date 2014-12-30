using System;
using UnityEngine;
using System.Collections;

public class HGAttack : MonoBehaviour {

    private HG1Attack attack1;
    private HG2Attack attack2;
    private HG3Attack attack3;

    void Start()
    {
        attack1 = this.GetComponent<HG1Attack>();
        attack2 = this.GetComponent<HG2Attack>();
        attack3 = this.GetComponent<HG3Attack>();
    }
}
