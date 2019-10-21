using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public delegate void MyFunck();
public class ButtonControl : MonoBehaviour {
    

    public GameObject PrefabTower;
    public GameObject PrefabMine;
    public GameObject PrefabStock;
    public GameObject PrefabWall;
    public GameObject Selectedprefab;

    public GameObject Panels;
    public GameObject PanelsButton;
    public GameObject PanelsButton1;

    MyFunck FunckCallUpdate;
    MyFunck FunckCallDestroy;

    MyFunck informWr;

    public void funckCallUpdate(MyFunck value)
    {
        FunckCallUpdate = value;
    }

    public void funckCallDestroy(MyFunck value)
    {
        FunckCallDestroy = value;
    }

    private Transform PositionClickOfCreate;//позиция нажатого спрайта для создания;
	// Use this for initialization
	void Start () {
      
        PositionClickOfCreate = null;
        Panels.SetActive(false);
        PanelsButton.SetActive(false);
        PanelsButton1.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
        int min = DateTime.Now.Minute;
        if (min < 10)
        {
            GameObject.Find("TimeNow").GetComponent<Text>().text = DateTime.Now.Hour + ":0" + DateTime.Now.Minute;
        }
        else
        {
            GameObject.Find("TimeNow").GetComponent<Text>().text = DateTime.Now.Hour + ":" + DateTime.Now.Minute;
        }
        

    }
    public void Uplevel()
    {
        
        FunckCallUpdate.Invoke();
        PanelsButton1.SetActive(false);
    }

    public void DestroyBuilding()
    {
        if (FunckCallDestroy != null)
            FunckCallDestroy.Invoke();
        PanelsButton1.SetActive(false);
    }


    public void CorectTextUpdate(int price)
    {
        GameObject.Find("UpdateText").GetComponent<Text>().text = "Up: " + price + "gold";
    }


    public void positionClickOfCreate(Transform position)
    {
        PositionClickOfCreate = position;
    }

    public void ClicBuyTower()
    {

        if (PrefabTower.GetComponent<TowerBuild>().Price>= FindObjectOfType<StocksInspector>().CurrentCountResources) return;
        FindObjectOfType<StocksInspector>().MinusValue(PrefabTower.GetComponent<TowerBuild>().Price);

        GameObject g = Instantiate(PrefabTower, new Vector3(PositionClickOfCreate.transform.position.x, PositionClickOfCreate.transform.position.y+ 1, 2), PositionClickOfCreate.transform.rotation);
        PositionClickOfCreate.GetComponent<CellGround>().IsBusy(false);
        PositionClickOfCreate = null;
        Panels.SetActive(false);
        PanelsButton.SetActive(false);
        PanelsButton1.SetActive(false);

    }

    public void ClicBuyWall()
    {
        if (PrefabWall.GetComponent<WallBild>().Price >= FindObjectOfType<StocksInspector>().CurrentCountResources) return;
        FindObjectOfType<StocksInspector>().MinusValue(PrefabWall.GetComponent<WallBild>().Price);

        GameObject g = Instantiate(PrefabWall, new Vector3(PositionClickOfCreate.transform.position.x, PositionClickOfCreate.transform.position.y, 2), PositionClickOfCreate.transform.rotation);
        PositionClickOfCreate.GetComponent<CellGround>().IsBusy(false);
        PositionClickOfCreate = null;
        Panels.SetActive(false);
        PanelsButton.SetActive(false);
        PanelsButton1.SetActive(false);
    }

    public void ClicBuyMine()
    {
        if (PrefabMine.GetComponent<MineBuild>().Price >= FindObjectOfType<StocksInspector>().CurrentCountResources) return;
        FindObjectOfType<StocksInspector>().MinusValue(PrefabMine.GetComponent<MineBuild>().Price);

        GameObject g = Instantiate(PrefabMine, new Vector3(PositionClickOfCreate.transform.position.x, PositionClickOfCreate.transform.position.y + 0.5F, 2), PositionClickOfCreate.transform.rotation);
        PositionClickOfCreate.GetComponent<CellGround>().IsBusy(false);
        PositionClickOfCreate = null;
        Panels.SetActive(false);
        PanelsButton.SetActive(false);
        PanelsButton1.SetActive(false);
    }

    public void ClicBuyStock()
    {
        if (PrefabStock.GetComponent<StockBuild>().Price >= FindObjectOfType<StocksInspector>().CurrentCountResources) return;
        FindObjectOfType<StocksInspector>().MinusValue(PrefabStock.GetComponent<StockBuild>().Price);

        GameObject g = Instantiate(PrefabStock, new Vector3(PositionClickOfCreate.transform.position.x, PositionClickOfCreate.transform.position.y, 2), PositionClickOfCreate.transform.rotation);
        PositionClickOfCreate.GetComponent<CellGround>().IsBusy(false);
        PositionClickOfCreate = null;
        Panels.SetActive(false);
        PanelsButton.SetActive(false);
        PanelsButton1.SetActive(false);
    }

   
}
