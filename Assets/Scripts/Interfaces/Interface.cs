using UnityEngine;
using System.Collections;

public interface IKill{
	void Kill();
}

public interface IDamageable<T>{
	void Damage(T damageTaken);
}
