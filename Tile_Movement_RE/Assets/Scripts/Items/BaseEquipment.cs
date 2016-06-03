using UnityEngine;
using System.Collections;

public class BaseEquipment : BaseStatItem {

	public enum EquipmentTypes{
		HEAD,
		CHEST,
		LEGS,
		FEET,
		JEWELRY
	}
	private EquipmentTypes equipmentType;

	public EquipmentTypes EquipmentType{
		get{return equipmentType;}
		set{equipmentType = value;}
	}
}
