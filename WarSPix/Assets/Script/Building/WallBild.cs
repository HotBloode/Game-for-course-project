using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBild : BaseBuilding
{
    private float distanse = 0.2f;// Дистанция на которую отбрасывает

    void Start()
    {


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
        Price *= level;
        currentHP += startHP * (level / (float)10.0);
        life = currentHP;
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
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("123");
        Enemy enemy = collision.GetComponent<Enemy>();
        //   Rigidbody2D rigidbody = enemy.GetComponent<Rigidbody2D>();
        //if (collision.gameObject.tag == "Enemy")
        //{
        if (enemy)
        {
            if (GameObject.FindObjectOfType<Basis>().transform.position.x > enemy.transform.position.x)
            {
                enemy.transform.position = new Vector3(enemy.transform.position.x - distanse, enemy.transform.position.y, enemy.transform.position.z);
                SetDamage(20);
            }
            else if (GameObject.FindObjectOfType<Basis>().transform.position.x < enemy.transform.position.x)
            {
                enemy.transform.position = new Vector3(enemy.transform.position.x + distanse, enemy.transform.position.y, enemy.transform.position.z);
                SetDamage(20);
            }
            //enemy.GetComponent<Rigidbody2D>().AddForce(transform.right * 3.0f, ForceMode2D.Impulse);
        }
    }
}
