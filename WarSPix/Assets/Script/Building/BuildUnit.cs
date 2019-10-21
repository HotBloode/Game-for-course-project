using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildUnit : BaseBuilding {

    public int startUnitCount { get; protected set; }//начальное количество допустимых юнитов
    public int currentUnitCount { get; protected set; }//текущее количество допустимых юнитов
    public int PriceUnite { get; protected set; }

    public BuildUnit()
    {
        startUnitCount = 20;
        currentUnitCount = startUnitCount;
    }

    public void UpLevel()
    {
        if (level == maxlevel)
        {
            return;
        }
        level++;
        Price *= level;
        currentHP = startHP;
        currentHP += (startHP * (level / (float)10.0));
        life = currentHP;
        float z=    (float)(currentUnitCount + startUnitCount * (level / (float)10.0));
        // print(currentUnitCount + startUnitCount *(level / (float)10.0));
        currentUnitCount = (int)z;
    }
    private void Awake()
    {

    }
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
