using UnityEngine;
using System.Collections;

public class ClickableTile : MonoBehaviour {

	// Change dated May 28th

	public int tileX;
	public int tileY;
	public TileMap map;

	void OnMouseUp(){
		Debug.Log ("Click");

		map.GeneratePathTo (tileX, tileY);
	}
}
