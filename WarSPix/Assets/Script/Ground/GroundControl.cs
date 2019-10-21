using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundControl : MonoBehaviour {

    private GameObject[] CellGrounds;
    private GameObject[,] CellArray = new GameObject[8, 8];
    // Use this for initialization
    void Start () {
        //CellGrounds = GameObject.FindGameObjectsWithTag("CellsGr");
        //for(int i = 0, k = 0; i != 8; i++)
        //{
        //    for (int j = 0; j != 8; j++,k++)
        //    {
        //        CellArray[i, j] = CellGrounds[k];
        //        CellArray[i, j].name  = "ground" + i + "" + j;
        //    }
        //}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
