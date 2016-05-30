using UnityEngine;
using System.Collections;

[System.Serializable]
public class TileType {
	//Alex is fat
	public string name;
	public GameObject tileVisualPrefab;
	public float movementCost = 1;
	public bool isWalkable = true;

}
