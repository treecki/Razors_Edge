using UnityEngine;
using System.Collections;

public class BaseBearClass : BaseCharacterClass {

	public BaseBearClass(){
		CharacterClassName = "Bear";
		CharacterClassDescription = "A class with a focus on strength.";

		//Stats Initialized for Bear
		Strength = 1;
		Speed = 1;
		Intelligence = 1;
		Endurance = 1;
		Agility = 1;
		Luck = 1;

	}
}
