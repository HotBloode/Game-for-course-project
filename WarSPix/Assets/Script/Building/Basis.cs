using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Basis : BaseBuilding
{
    private bool IsGameOver;
    Text HPBase;
    GameObject panelGameObject;
    // Use this for initialization
    void Start () {
        IsGameOver = false;
        panelGameObject = GameObject.Find("GameOverPanel");
        HPBase = GameObject.Find("HPPointBase").GetComponent<Text>();
        panelGameObject.SetActive(false);
    }
    void WriteInform()
    {
        GameObject.Find("HpText").GetComponent<Text>().text = ""+life;
        GameObject.Find("LevelText").GetComponent<Text>().text = ""+level;
        GameObject.Find("DopInform").GetComponent<Text>().text = "None";
    }

    private IEnumerator Mywait(int time)
    {
        yield return new WaitForSeconds(time);
        //Make all "нечто"
    }

    private void OnDestroy()
    {
        life = 0;
        panelGameObject.SetActive(true);
        Mywait(3000);
        Mywait(3000);
        Mywait(3000);
        SceneManager.UnloadSceneAsync(1);
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update () {
        HPBase.text = ""+life+"/"+currentHP;
        if (life <= 0)
        {
           
            Destroy(this.gameObject);
            
            //Application.loa(1);
        }
    }


    void UpLevel()
    {
        if (level == maxlevel) return;
        if(stockInspect.CurrentCountResources< Price)
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



    public void OnMouseDown()
    {

        ButtonControl b = GameObject.Find("ButtonInspector").GetComponent<ButtonControl>();
        b.funckCallUpdate(UpLevel);
        b.funckCallDestroy(null);
        b.PanelsButton1.SetActive(true);
        b.CorectTextUpdate(Price);
        WriteInform();
    }
}
