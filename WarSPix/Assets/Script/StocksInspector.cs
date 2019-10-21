using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StocksInspector : MonoBehaviour {

    float MaxCountResources;
    public float CurrentCountResources;

    Text Balance;

    public void ChangeMaxValue(float value)
    {
        MaxCountResources += value;
    }

    public void AddValue(float value)
    {
        if(CurrentCountResources+ value > MaxCountResources)
        {
            CurrentCountResources = MaxCountResources;
        }
        else
        {
            CurrentCountResources += value;
        }
       
    }

    public void MinusValue(float value)
    {
        if(CurrentCountResources - value >=0)
        {
            CurrentCountResources -= value;
        }
        
    }


    // Use this for initialization
    void Start () {
        Balance = GameObject.Find("BalanceGold").GetComponent<Text>();
        CurrentCountResources = 100;
        MaxCountResources = CurrentCountResources;
    }
	
	// Update is called once per frame
	void Update () {
        Balance.text = CurrentCountResources + "/" + MaxCountResources;

    }
}
