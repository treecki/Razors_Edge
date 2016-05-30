using UnityEngine;
using System.Collections;

[System.Serializable]
public class TileType {

	// This is the code for individual tiles...


	public string name;
	public GameObject tileVisualPrefab;
	public float movementCost = 1;
	public bool isWalkable = true;

}
