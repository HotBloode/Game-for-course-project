using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MineBuild : BaseBuilding {

    private float ManinngInSecond;
    // Use this for initialization
    
        public MineBuild()
    {
        ManinngInSecond = 100;
    }

    void Start()
    {



    }

    // Update is called once per frame
    void Update () {
        maning();

    }

    void UpLevel()
    {
        print("+");
        if (level == maxlevel) return;
        if (stockInspect.CurrentCountResources < Price)
        {
            return;
        }
        stockInspect.MinusValue(Price);
        level++;
        ManinngInSecond += ManinngInSecond * (level / (float)10.0);
        Price *= level;
        currentHP += startHP * (level / (float)10.0);
        life = currentHP;
    }
    void destroyObj()
    {
     
        Destroy(gameObject);
    }


    void maning()
    {
        float drop = ManinngInSecond * Time.deltaTime;
        stockInspect.AddValue(drop);
    }
    void WriteInform()
    {
        GameObject.Find("HpText").GetComponent<Text>().text = "" + life;
        GameObject.Find("LevelText").GetComponent<Text>().text = "" + level;
        GameObject.Find("DopInform").GetComponent<Text>().text = "" + ManinngInSecond+"p/s";
    }
    public void OnMouseDown()
    {
       
        ButtonControl b = GameObject.Find("ButtonInspector").GetComponent<ButtonControl>();
        b.funckCallUpdate( UpLevel);
        b.funckCallDestroy(destroyObj);
        b.PanelsButton1.SetActive(true);
        b.Panels.SetActive(false);
        b.PanelsButton.SetActive(false);
        b.CorectTextUpdate(Price);
        WriteInform();
    }
}
