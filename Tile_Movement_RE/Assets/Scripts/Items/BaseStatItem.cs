using UnityEngine;
using System.Collections;

public class BaseStatItem : BaseItem {

	private int strength;
	private int intelligence;
	private int speed;
	private int endurance;
	private int agility;
	private int luck;

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
