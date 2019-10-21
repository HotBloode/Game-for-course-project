using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerBuild : BaseBuilding
{

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

    }
   
    void destroyObj()
    {       
        Destroy(gameObject);
    }

    void UpLevel()
    {
        if (level == maxlevel) return;
        if (stockInspect.CurrentCountResources < Price)
        {
            return;
        }
        stockInspect.MinusValue(Price);
        level++;
        //ManinngInSecond += ManinngInSecond * (level / (float)10.0);
        Price *= level;
        currentHP += startHP * (level / (float)10.0);
        life = currentHP;
    }

    void WriteInform()
    {
        GameObject.Find("HpText").GetComponent<Text>().text = "" + life;
        GameObject.Find("LevelText").GetComponent<Text>().text = "" + level;
        GameObject.Find("DopInform").GetComponent<Text>().text = ""+this.GetComponent<TowerAtack>().damae;
    }

    public void OnMouseDown()
    {
        ButtonControl b = GameObject.Find("ButtonInspector").GetComponent<ButtonControl>();
        b.funckCallUpdate(UpLevel);
        b.funckCallDestroy(destroyObj);
        b.PanelsButton1.SetActive(true);
        b.Panels.SetActive(false);
        b.PanelsButton.SetActive(false);
        b.CorectTextUpdate(Price);
        WriteInform();
    }
}
