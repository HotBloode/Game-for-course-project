using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StockBuild : BaseBuilding
{

    float Value;//Вместительность хранилища

    // Use this for initialization
    void Start()
    {
        
        Value = 1000;
        // StocksInspector b = GameObject.Find("StockInspect").GetComponent<StocksInspector>();
        stockInspect.ChangeMaxValue(Value);

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
        
        float z = Value * (level / (float)10.0);
        stockInspect.ChangeMaxValue(z);
        Value += z;
        Price *= level;
        currentHP += startHP * (level / (float)10.0);
        life = currentHP;
    }

    private void OnDestroy()
    {
        stockInspect.ChangeMaxValue((-1) * Value);
    }
    void WriteInform()
    {
        GameObject.Find("HpText").GetComponent<Text>().text = "" + life;
        GameObject.Find("LevelText").GetComponent<Text>().text = "" + level;
        GameObject.Find("DopInform").GetComponent<Text>().text = "" + Value;
    }

    public void OnMouseDown()
    {
        print("-");
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
