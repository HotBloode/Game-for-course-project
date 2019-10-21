using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Dyadya Jora
public class UnitPatrul : MonoBehaviour
{
    private float FindRadius = 5.0f;
    private float CubeRadius = 5.0f;
    private float SpeedPatrul = 31.0f;
    private float minX, maxX, minY, maxY;
    Enemy enemy = null;
    ///////
    private float posX, posY;
    private Vector3 mousePos; 
    private bool tmp = true;
    private bool IsPatrol;
    Vector3 a;
    Vector3 b;
    /// 
    public float MaxLife = 100f;
    private float life;

    void Start()
    {
        life = MaxLife;
        minX = transform.position.x - CubeRadius;
        maxX = transform.position.x + CubeRadius;
        minY = transform.position.y - CubeRadius;
        maxY = transform.position.y + CubeRadius;

        life = MaxLife;
    }

    void Update()
    {
        if (enemy == null)
        {
            // Ищем противника
            FindEnemy();
            Patrol();
           
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, enemy.transform.position, 3 * Time.deltaTime);
            Damage();
        }
    }

    public void SetDamage(float value)
    {
        life -= value;

        if (life <= 0)
            Destroy(gameObject);
    }
    void Patrol()
    {
        //if (!button)
        //{
        //    if (Input.GetKeyDown(KeyCode.Mouse0))
        //    {
        //        button = true;
        //        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //        posX = transform.position.x;
        //        posY = transform.position.y;
        //         a = new Vector3(mousePos.x, mousePos.y, 1);
        //         b = new Vector3(posX, posY, 1);
        //    }
        //}

        //    if (button)
        //    {
        //    if (one)
        //    {
        //перемещаем в новые координат 
        if (tmp)
        {
            a = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 1f);
            transform.position = Vector3.Lerp(transform.position, a, SpeedPatrul * Time.deltaTime);
            tmp = false;
        }
        else
        {
            transform.position = Vector3.Lerp(a, transform.position, SpeedPatrul * Time.deltaTime);
        }
        if (transform.position == a)
        {
            
            tmp = true;
        }
        //if (transform.position == a)
        //{
        //    tmp = true;
        //}

        //    if (transform.position == a)
        //    {
        //        one = false;
        //    }
        //}
        //else
        //{            
        //    transform.position = Vector3.Lerp(transform.position, b, 3 * Time.deltaTime);
        //    if (transform.position == b)
        //    {
        //        one = true;
        //    }
        //}            
        //}

    }
    private void FindEnemy()
    {
        var enemies = GameObject.FindObjectsOfType<Enemy>();
        float min = FindRadius;
        Enemy minEnemy = null;

        foreach (var e in enemies)
        {
            float dist = Vector3.Distance(e.transform.position, transform.position);
            if (min > dist)
            {
                min = dist;
                minEnemy = e;
            }
        }
        enemy = minEnemy;
    }
    private void Damage()
    {
        if (Vector3.Distance(enemy.transform.position, transform.position) <= 1.3f)
        {
            enemy.SetDamage(10);
        }
    }
}