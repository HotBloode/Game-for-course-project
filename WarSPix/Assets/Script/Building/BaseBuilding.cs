using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBuilding : MonoBehaviour {

    public int level { get; protected set; }//уровень здания
    public int maxlevel { get; protected set; }//максимально возможное количество уровней
    public float startHP { get; protected set; }// начальное хп
    public float currentHP { get; protected set; }// хп на текущем уровне
    public float life { get; protected set; }//состояние хп в текущий момент
    public int Price { get; protected set; }
    public int PriceUp { get; private set; }
    GameObject Select;
    GameObject deleted;
    protected StocksInspector stockInspect;

    private void Awake()
    {
        stockInspect = GameObject.Find("StockInspect").GetComponent<StocksInspector>();
        Select = FindObjectOfType<ButtonControl>().Selectedprefab;
    }
    public BaseBuilding()
    {       
        Price = 10;        
        level = 1;
        Price *= level;
        startHP = 1000;
        maxlevel = 100;
        currentHP = startHP;
        currentHP += startHP * (level / (float)10.0);
        life = currentHP;
    }

   



    public void SetDamage(float value)
    {
        life -= value;

        if (life <= 0)
            Destroy(gameObject);
    }
    
    private void OnMouseOver()
    {

        if (deleted == null)
            deleted = Instantiate(Select, new Vector3(transform.position.x, transform.position.y, 2), transform.rotation);
    }
    private void OnMouseExit()
    {
        print('-');
        Destroy(deleted.gameObject);
        deleted = null;
    }
}
