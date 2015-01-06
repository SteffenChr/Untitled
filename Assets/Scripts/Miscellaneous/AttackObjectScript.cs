using UnityEngine;
using System.Collections;

/// <summary>
/// This script contains all the information needed for the attack object.
/// All the parameters of the obejct is set when it is awoken.
/// hwo long it lives, how much damage it deals anyone who gets into contact with it.
/// </summary>
public class AttackObjectScript : MonoBehaviour {

    private float damageDealing = 0;

    /// <summary>
    /// Starts the courutine to destroy the object
    /// </summary>
    /// <param name="time">The time until the object should be destroyed</param>
    public void StartDestroyObejctSequence(float time)
    {
        StartCoroutine(DestroyObject(time));
    }

    /// <summary>
    /// Waits until the time has passed then destroys itself
    /// </summary>
    /// <param name="time">The waiting time</param>
    /// <returns>Nothing</returns>
    private IEnumerator DestroyObject(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }

    public float DamageDealing { get; set; }
}
