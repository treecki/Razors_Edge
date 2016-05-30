using UnityEngine;
using System.Collections;

public class ClickableTile : MonoBehaviour {

	// Change dated May 28th
	//Alex is a bitch

	public int tileX;
	public int tileY;
	public TileMap map;

	void OnMouseUp(){
		Debug.Log ("Click");

		map.GeneratePathTo (tileX, tileY);
	}
}
