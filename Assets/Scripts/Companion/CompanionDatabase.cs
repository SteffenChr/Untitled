using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Keeps track on which companions are active and in which slot they are set in.
/// </summary>
public class CompanionDatabase : MonoBehaviour 
{
	public List<Companion> companions = new List<Companion>();

	void Start(){

	}

    /// <summary>
    /// This methode saves the companion to the designated spot.
    /// </summary>
    /// <param name="companion">The companion class needed to be saved</param>
    /// <param name="companionSpot">The position the companion can be saved in 1=left, 2=right</param>
    internal void SetCompanion(Companion companion, int companionSpot)
    {
        companions.Insert(companionSpot - 1, companion);
    }

    /// <summary>
    /// This methode returns the companion in the spot which is designated by the attribute.
    /// </summary>
    /// <param name="companionNumber">The number spot of the companion 1=left, 2=right</param>
    /// <returns>The companion class</returns>
    internal Companion GetCompanion(int companionSpot)
    {
        return companions[companionSpot - 1];
    }

    /// <summary>
    /// Removes all companions from their spots
    /// </summary>
    internal void DeleteAllCompanions()
    {
        companions.Clear();
    }

    /// <summary>
    /// Deletes the companion stored in this specific spot
    /// </summary>
    /// <param name="companionSpot">The spot of the companion 1=left, 2=right</param>
    internal void DeleteCompanion(int companionSpot)
    {
        companions.RemoveAt(companionSpot - 1);
    }

    /// <summary>
    /// Returns the active companions
    /// </summary>
    /// <returns>A list of all the active companions</returns>
    internal List<Companion> GetCompanions()
    {
        return companions;
    }
}

