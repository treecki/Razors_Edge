using UnityEngine;
using System.Collections;

public class CtreateNewEquipment : MonoBehaviour {

	private BaseEquipment newEquipment;
	private string[] itemNames = new string[]{ "Common", "Great", "Deadly", "Alex" };
	private string[] itemDescription = new string[]{"An item found often", "A rarer item with stronger abilities", "An item that has killed many in battle", "A spaz coder"};
	private int randItem = Random.Range (0, 4);

	// Use this for initialization
	void Start () {
	
	}

	private void CreateEquipment(){
		newEquipment = new BaseEquipment();
		newEquipment.ItemName = itemNames [randItem] + " Item";
		newEquipment.ItemDescription = itemDescription [randItem] + " Item";
		newEquipment.ItemID = Random.Range(1, 101);
		ChooseItemType();
		newEquipment.Strength = Random.Range(1,21);
		newEquipment.Intelligence = Random.Range(1,21);
		newEquipment.Speed = Random.Range(1,21);
		newEquipment.Agility = Random.Range(1,21);
		newEquipment.Endurance = Random.Range(1,21);
		newEquipment.Luck = Random.Range(1,21);
	}

		private void ChooseItemType(){
		int randomTemp = Random.Range (1, 6);
		if(randomTemp == 1){
			newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.HEAD;
		}else if(randomTemp == 2){
			newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.CHEST;
		}else if(randomTemp == 3){
			newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.FEET;
		}else if(randomTemp == 4){
			newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.LEGS;
		}else if(randomTemp == 5){
			newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.JEWELRY;
		}
	}

}
