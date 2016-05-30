using UnityEngine;
using System.Collections.Generic;

public class Unit : MonoBehaviour {

	public int tileX;
	public int tileY;
	public TileMap map;

	public List<Node> currentPath = null;

	void Update(){
		if (currentPath != null) {

			int currNode = 0;

			while (currNode < currentPath.Count-1) {

				Vector3 start = map.TileCoordToWorldCoord(currentPath[currNode].x, currentPath[currNode].y) + new Vector3(0, 0, -1f);
				Vector3 end = map.TileCoordToWorldCoord(currentPath[currNode+1].x, currentPath[currNode+1].y) + new Vector3(0, 0, -1f);

				Debug.DrawLine (start, end, Color.red);

				currNode++;

			}

		}
	}

	public void MoveNextTile(){
		if (currentPath == null)
			return;
		//Remove the old current/first node from path
		currentPath.RemoveAt (0);

		//Now grab the new first node and move us to that position
		transform.position = map.TileCoordToWorldCoord (currentPath [0].x, currentPath [0].y);
	}

}

