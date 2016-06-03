using UnityEngine;
using System.Collections;

public class BaseWeapon : BaseStatItem {

	public enum WeaponTypes{
		SWORD,
		STAFF,
		DAGGER,
		BOW,
		SHIELD,
		POLEARM
	}
	private WeaponTypes weaponType;

	public WeaponTypes WeaponType{
		get{return weaponType;}
		set{weaponType = value;}
	}
}
