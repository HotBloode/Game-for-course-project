using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class iron_resources : MonoBehaviour {

    public int id;
    int value;
    float production_time;

    // Use this for initialization
    void Start () {
        value = 4;// RandValue();
        production_time = 2;
    }
	
	// Update is called once per frame
	void Update () {
       // Production(2);
        //print(Input.GetAxis("Horizontal"));
    }

    int RandValue()
    {
        return Random.Range(50, 10000);
    }

 

    public int Production(int count, ref bool inf)
    {
        int dop = value - count;
        if (dop <= 0)
        {
           // print("id"+id) ;
            inf = true;            
           // DestroyObject(this);
            //Destroy(this);
            return count - dop;
        }
        
        value -= count;
  
  
        return dop;
    }

    public bool IsFull()
    {
        return value!=0;
    }


}
