using UnityEngine;
using System.Collections;

public class Character {

	private int characterId;
	private string characterName;
	private float characterMovementSpeed;
	private int characterLife;
	private bool characterCanMove;

	public Character(string name, int id, int life, float movementSpeed, bool canMove){
		characterName = name;
		characterId = id;
		characterLife = life;
		characterMovementSpeed = movementSpeed;
		characterCanMove = canMove;
	}

	public Character(){

	}

	public void TakeDamage(int damage){
		characterLife -= damage;
	}

	public bool CharacterCanMove {
		get {
			return characterCanMove;
		}
		set {
			characterCanMove = value;
		}
	}

	public int CharacterLife2 {
		get {
			return characterLife;
		}
		set {
			characterLife = value;
		}
	}

	public float CharacterMovementSpeed2 {
		get {
			return characterMovementSpeed;
		}
		set {
			characterMovementSpeed = value;
		}
	}

	public string CharacterName2 {
		get {
			return characterName;
		}
		set {
			characterName = value;
		}
	}

	public int CharacterId2 {
		get {
			return characterId;
		}
		set {
			characterId = value;
		}
	}
}
