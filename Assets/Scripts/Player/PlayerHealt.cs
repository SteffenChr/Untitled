using UnityEngine;
using System.Collections;

public class PlayerHealt : MonoBehaviour
{
    void OnCollisionEnter(Collision coll)
    {
        if (coll.transform.CompareTag("Enemy"))
        {
            print("Hit by enemy");
        }
    }
}

