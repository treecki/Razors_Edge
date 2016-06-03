using UnityEngine;
using System.Collections;

public class BaseCharacterClass{

	private string characterClassName;
	private string characterClassDescription;

	//Stats
	private int strength;
	private int intelligence;
	private int speed;
	private int endurance;
	private int agility;
	private int luck;

	public string CharacterClassName{
		get{return characterClassName;}
		set{characterClassName = value;}
	}
	public string CharacterClassDescription{
		get{return characterClassDescription;}
		set{characterClassDescription = value;}
	}
	public int Strength{
		get{return strength;}
		set{strength = value;}
	}
	public int Intelligence{
		get{return intelligence;}
		set{intelligence = value;}
	}
	public int Speed{
		get{return speed;}
		set{speed = value;}
	}
	public int Endurance{
		get{return endurance;}
		set{endurance = value;}
	}
	public int Agility{
		get{return agility;}
		set{agility = value;}
	}
	public int Luck{
		get{return luck;}
		set{luck = value;}
	}

}
