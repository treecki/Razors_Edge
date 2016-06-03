using UnityEngine;
using System.Collections;

public class BaseTool : BaseItem {

	public enum ToolTypes{
		RAW_MATERIAL,
		CRAFTING,
		TRAPS
	}
	private ToolTypes toolType;

	public ToolTypes ToolType{
		get{return toolType;}
		set{toolType = value;}
	}
}
