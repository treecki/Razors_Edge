using UnityEngine;
using System.Collections;

public class BaseFood : BaseItem {

	private int foodHealth;
	public enum FoodTypes{
		RAW,
		COOKED,
		LIQUID,
		POISON
	}
	private FoodTypes foodType;

	public FoodTypes FoodType{
		get{return foodType;}
		set{foodType = value;}
	}

	public int FoodHealth{
		get{return foodHealth;}
		set{foodHealth = value;}
	}
}
