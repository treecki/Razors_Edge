using UnityEngine;
using System.Collections;

public class CreateNewFood : MonoBehaviour {

	private BaseFood newFood;
	private int randFoo = Random.Range(1,101);

	public void CreateFood(){

		newFood = new BaseFood ();

		newFood.ItemName = "Food" + randFoo;
		newFood.ItemDescription = "Tasty";
		newFood.ItemID = randFoo;
	}
	public void ChooseFoodType(){
		int randomTemp = Random.Range (1, 5);
		if (randomTemp == 1) {
			newFood.FoodType = BaseFood.FoodTypes.COOKED;
			newFood.FoodHealth = Random.Range (15, 21);
		}
		if (randomTemp == 2) {
			newFood.FoodType = BaseFood.FoodTypes.LIQUID;
			newFood.FoodHealth = Random.Range (10, 16);
		}
		if (randomTemp == 3) {
			newFood.FoodType = BaseFood.FoodTypes.POISON;
			newFood.FoodHealth = Random.Range (-11, -1);
		}
		else{
			newFood.FoodType = BaseFood.FoodTypes.RAW;
			newFood.FoodHealth = Random.Range (0, 10);
		}
	}

}
