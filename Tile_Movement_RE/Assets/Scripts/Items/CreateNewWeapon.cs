using UnityEngine;
using System.Collections;

public class CreateNewWeapon : MonoBehaviour {

	private BaseWeapon newWeapon;
	private int randWep = Random.Range(1,101);
	//private string[] weaponsNames = new string[6] { "Weapon Name" };

	public void CreateWeapon(){

		newWeapon = new BaseWeapon ();

		//Assign a name to the weapon
		newWeapon.ItemName = "W" + randWep;
		//create a weapon description
		newWeapon.ItemDescription = "Test";
		//weapon id
		newWeapon.ItemID = randWep;
		//stats
		newWeapon.Strength = Random.Range(1,21);
		newWeapon.Intelligence = Random.Range(1,21);
		newWeapon.Speed = Random.Range(1,21);
		newWeapon.Agility = Random.Range(1,21);
		newWeapon.Endurance = Random.Range(1,21);
		newWeapon.Luck = Random.Range(1,21);
		//choose type of weapon
	}
	public void ChooseWeaponType(){
		int randomTemp = Random.Range (1, 7);
		if (randomTemp == 1) {
			newWeapon.WeaponType = BaseWeapon.WeaponTypes.SWORD;
		}
		if (randomTemp == 2) {
			newWeapon.WeaponType = BaseWeapon.WeaponTypes.BOW;
		}
		if (randomTemp == 3) {
			newWeapon.WeaponType = BaseWeapon.WeaponTypes.SHIELD;
		}
		if (randomTemp == 4) {
			newWeapon.WeaponType = BaseWeapon.WeaponTypes.STAFF;
		}
		if (randomTemp == 5) {
			newWeapon.WeaponType = BaseWeapon.WeaponTypes.DAGGER;
		}
		else{
			newWeapon.WeaponType = BaseWeapon.WeaponTypes.POLEARM;
		}
	}
}
