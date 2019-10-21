using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockControl : BaseBuilding
{
   public int size { get; private set; }
    int startSize;
    public int value { get; private set; }

	// Use this for initialization
	void Start () {
        value = 0;
        startSize = 10;
        size = startSize * level;
    }
    public bool IsFull()
    {
        return value == size;
    }

    public void SetVal(int val)
    {
        value -= val;
    }

    public bool unloadingRes(ref int count)
    {
        if(value+count> size)
        {
            count = value + count - size;
            value = size;
            return false;
        }
        value += count;
        count = 0;
        return true;
    }

    public void UpLevel()
    {
        if (level == maxlevel)
        {
            return;
        }
        level++;
        currentHP = startHP;
        currentHP += (startHP * (level / (float)10.0));
        life = currentHP;
        size = startSize * level;

    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnMouseDown()
    {
        
    }
}
