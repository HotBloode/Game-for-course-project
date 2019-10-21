using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellGround : MonoBehaviour {

    public int i;
    public int j;
    private bool isBusy;//заня
    GameObject Select;
    GameObject deleted;
    // Use this for initialization
    void Start()
    {
        //this.name = "ground" + i + "" + j;
        isBusy = true;
        Select = FindObjectOfType<ButtonControl>().Selectedprefab;
    }
    public void IsBusy(bool value)
    {
        isBusy = value;
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseDown()
    {
        ButtonControl b = GameObject.Find("ButtonInspector").GetComponent<ButtonControl>();
        b.positionClickOfCreate(this.transform);
        b.Panels.SetActive(true);
        b.PanelsButton.SetActive(true);
        b.PanelsButton1.SetActive(false);

        //print("+");
        //GetComponent<Renderer>().material.color = new Color(1, 1, 1);
    }

    private void OnMouseOver()
    {
        
        if(deleted==null)
            deleted = Instantiate(Select, new Vector3(transform.position.x, GetComponent<Collider2D>().transform.position.y, 2), transform.rotation);
    }
    private void OnMouseExit()
    {
        print('-');
        Destroy(deleted.gameObject);
        deleted = null;
    }
}
