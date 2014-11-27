using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CompanionDatabase : MonoBehaviour
{
	public List<Companion> companions = new List<Companion>();

	void Start(){
		companions.Add(new Companion("Jeff", 101, 10, 1F, true));
	}
}

