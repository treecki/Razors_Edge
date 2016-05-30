using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class TileMap : MonoBehaviour {

	public GameObject selectedUnit;
	public TileType[] tileTypes;

	int[,] tiles;
	Node[,] graph;

	int mapsizeX = 10;
	int mapsizeY = 10;

	void Start() {
		//Set up the selectedUnit's variables
		selectedUnit.GetComponent<Unit>().tileX = (int)selectedUnit.transform.position.x;
		selectedUnit.GetComponent<Unit>().tileY = (int)selectedUnit.transform.position.y;
		selectedUnit.GetComponent<Unit> ().map = this;

		//Allocate map tiles
		tiles = new int[mapsizeX, mapsizeY];

		//initialize our map tiles

		for (int x = 0; x < mapsizeX; x++) {
			for (int y = 0; y < mapsizeY; y++) {
				tiles[x, y] = 0;
			}
		}
		//U-Shaped Mountain Range
		tiles[4,4] = 2;
		tiles[4,5] = 2;
		tiles[4,6] = 2;
		tiles[5,4] = 2;
		tiles[6,4] = 2;
		tiles[7,4] = 2;
		tiles[8,4] = 2;
		tiles[8,5] = 2;
		tiles[8,6] = 2;

		//Water Area
		for (int x = 3; x <= 5; x++) {
			for (int y = 0; y < 4; y++) {
				tiles [x, y] = 1;
			}
		}

		//Spawn Prefabs
		GenerateMapVisuals();
		GeneratePathFindingGraph ();
	}
		

	void GenerateMapVisuals(){
		for (int x = 0; x < mapsizeX; x++) {
			for (int y = 0; y < mapsizeY; y++) {
				TileType tt = tileTypes [tiles [x, y]];
				GameObject go = (GameObject)Instantiate (tt.tileVisualPrefab, new Vector3 (x, y, 0), Quaternion.identity);

				ClickableTile ct = go.GetComponent<ClickableTile>();
				ct.tileX = x;
				ct.tileY = y;
				ct.map = this;
			}
		}
	}

	public float CostToEnterTile(int sourceX, int sourceY, int targetX, int targetY){
		TileType tt = tileTypes [tiles [targetX, targetY]];

		float cost = tt.movementCost;

		if (sourceX != targetX && sourceY != targetY) {
			//Makes preference to do straight lines instead of diagonal
			//Purely Cosmetic
			cost += 0.1f;
		}
		return cost;
	}


		void GeneratePathFindingGraph (){
			//initialize the array
			graph = new Node[mapsizeX, mapsizeY];

		//initialize a Node for each spot in the array
		for (int x = 0; x < mapsizeX; x++) {
			for (int y = 0; y < mapsizeY; y++) {
				graph [x, y] = new Node ();
				graph [x, y].x = x;
				graph [x, y].y = y;

			}
		}
	// Now that all nodes have been made, we will calculate their neighbors
	for (int x = 0; x < mapsizeX; x++) {
		for (int y = 0; y < mapsizeY; y++) {
				//4 Way Connection for Movement
/*					if(x > 0)
						graph[x,y].neighbours.Add(graph[x-1, y]);
					if(x < mapsizeX -1)
						graph[x,y].neighbours.Add(graph[x+1, y]);
					if(y > 0)
						graph[x,y].neighbours.Add(graph[x, y-1]);
					if(y < mapsizeY -1)
						graph[x,y].neighbours.Add(graph[x, y+1]);
*/				
				//8 way Connection for Movement
				//Try Left
				if (x > 0) {
					graph [x, y].neighbours.Add (graph [x - 1, y]);
					if(y > 0)
						graph[x,y].neighbours.Add(graph[x-1, y-1]);
					if(y < mapsizeY -1)
						graph[x,y].neighbours.Add(graph[x-1, y+1]);
				}
				//Try Right
				if (x < mapsizeX - 1) {
					graph [x, y].neighbours.Add (graph [x + 1, y]);
					if(y > 0)
						graph[x,y].neighbours.Add(graph[x+1, y-1]);
					if(y < mapsizeY -1)
						graph[x,y].neighbours.Add(graph[x+1, y+1]);
				}
			//Try Straight Up and Down
				if(y > 0)
					graph[x,y].neighbours.Add(graph[x, y-1]);
				if(y < mapsizeY -1)
					graph[x,y].neighbours.Add(graph[x, y+1]);
				}
			}
		}

	public Vector3 TileCoordToWorldCoord (int x, int y)
	{
		return new Vector3(x, y, 0);
	}
	public void GeneratePathTo(int x, int y){
		//Clear out Unit's old path
		selectedUnit.GetComponent<Unit> ().currentPath = null;

		Dictionary<Node, float> dist = new Dictionary<Node, float>();
		Dictionary<Node, Node> prev = new Dictionary<Node, Node>();

		//set up the list of nodes we haven't visited yet
		List<Node> unvisited = new List<Node> ();

		Node source = graph[selectedUnit.GetComponent<Unit>().tileX, selectedUnit.GetComponent<Unit>().tileY];

		Node target = graph[x, y];

		dist[source] = 0;
		prev[source] = null;

		//Initialize everything to have Infinity distance, since we don't know any better rn 
		//Also its possible that some nodes cannot be reached, which would make inifinty reasonable
		foreach(Node v in graph){
			if (v != source) {
				dist [v] = Mathf.Infinity;
				prev [v] = null;
			}

			unvisited.Add (v);
		}

		while (unvisited.Count > 0) {
			//u is the becomes the node with the smallest distance.
			Node u = null;

			foreach (Node possibleU in unvisited) {
				if (u == null ||  dist[possibleU] < dist[u]) {
					u = possibleU;
				}
			}

			if (u == target) {
				break; //Breaks the while loop if it hits destination
			}

			unvisited.Remove (u);

			foreach (Node v in u.neighbours) {
				//float alt = dist [u] + u.DistanceTo (v);
				float alt = dist [u] + CostToEnterTile(u.x, u.y, v.x, v.y);
				if (alt < dist [v]) {
					dist [v] = alt;
					prev [v] = u; 
				}
			}
		}

		if (prev [target] == null) {
			//failsafe if there is no possible target
			return;
		}

		List<Node> currentPath = new List<Node> ();

		Node curr = target;
		//step through the "prev" chain and add it to our path
		while (curr != null) {
			currentPath.Add (curr);
			curr = prev [curr];
		}

		//currentPath describes a route from our target to our source right now, so we will invert it

		currentPath.Reverse ();

		selectedUnit.GetComponent<Unit>().currentPath = currentPath;
	}
}
