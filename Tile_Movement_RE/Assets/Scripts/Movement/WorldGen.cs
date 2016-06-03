using UnityEngine;
using System.Collections;

public class WorldGen : MonoBehaviour {

	private int dimX, dimY; // Initializing our variables for holding the map size

	public GameObject grassTile;
	public GameObject waterTile;
	public GameObject mountainTile;

	public WorldGen(int dimX, int dimY) { // Constructor for worldGen taking in map sizes
		
		this.dimX = dimX; // Assigning the parameters for the constructor to local variables
		this.dimY = dimY;
	}

	public void offsetPlayer(Unit player) { // This method will randomize the parameter players position within dimX and dimY

		bool continueRandomize = true; // Creating our boolean flag to iterate through

		while (continueRandomize) { // While our boolean flag is true continue randomizing our co-ordinate

			int newX = Random.Range (0, dimX);
			int newY = Random.Range (0, dimY);

			Vector3 newVec = new Vector3 (newX, newY, 0);

			if (true) {

				continueRandomize = false; // This should check if the co-ordinate that it places the player in is valid; if it is set 
										   // continue randomize to false otherwise continue randomizing player position
				
			}
		}
			
		// Call movePosition(newVec) inside of player

	}
}
