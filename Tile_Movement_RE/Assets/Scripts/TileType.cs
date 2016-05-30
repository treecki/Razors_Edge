using UnityEngine;
using System.Collections;

[System.Serializable]
public class TileType {

	public string name;
	public GameObject tileVisualPrefab;
	public float movementCost = 1;
	public bool isWalkable = true;
	public int percentChance = 0;

}
