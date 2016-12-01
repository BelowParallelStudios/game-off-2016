using UnityEngine;
using System.Collections;
using System.Collections.Generic; //needed to use Lists

public class TileScript : MonoBehaviour {

	public GameObject hiddenTile;
	public GameObject revealedTile;

	private Transform boardHolder;

	private List <Vector3> gridPositions = new List <Vector3> ();

	void GridSetUp()
	{
		gridPositions.Clear ();

		for (int x = 1; x < 4; x++) 
		{
			for (int y = 1; y < 4; y++) 
			{
				gridPositions.Add(new Vector3(x,y,0));
			}
		}
	}

	void PlaceTiles()
	{
		boardHolder = new GameObject ("Board").transform;

			for (int x = 0; x < 5; x++)
			{
				for (int y = 0; y < 5; y++)
				{
				GameObject hiddenInstance = Instantiate(hiddenTile, new Vector3(x,y,0), Quaternion.identity, boardHolder) as GameObject;
				GameObject revealedInstance = Instantiate(revealedTile, new Vector3(x,y,0), Quaternion.identity, boardHolder) as GameObject;
				}
			}
	}

	void Start()
	{
		PlaceTiles ();
	}
    
    



}
