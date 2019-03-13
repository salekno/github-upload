using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTiles : MonoBehaviour {

  public int xcoord;
  public int ycoord;
  public int movex;
  public int movey;
  public GameObject tile;
  
  
  // Use this for initialization
  void Start () {


    
		for(int i = 1; i < 5; i++)
    {
      for(int y = 1; y < 5; y++)
      {
        GameObject clone;
        clone = Instantiate(tile, new Vector2(xcoord, ycoord), Quaternion.identity);
        clone.transform.SetParent(this.transform.Find("" + i + "-x"), false);
        clone.name = "" + i + "-" + y;
        xcoord += movex;
      }
      ycoord -= movey;
      xcoord -= (4 * movex);
    }
  }
	
	// Update is called once per frame
	void Update () {
		
	}
}
