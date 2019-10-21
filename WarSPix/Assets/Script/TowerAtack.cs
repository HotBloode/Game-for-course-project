using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAtack : MonoBehaviour {
    private float FindRadius = 10.0f;//Радиус атаки
    Enemy enemy = null;//Враг

    public float damae = 5;//Дамаг вышки                      
    public float time = 1f;  
    private float timer = 0f;
    public GameObject bullet;

    private void Shoot()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = time;
            GameObject obj = (GameObject)Instantiate(bullet, transform.position, transform.rotation);
            Bullet b = obj.GetComponent<Bullet>();
            b.Enemy = enemy;
        }
    }
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (enemy==null)
        {
            FindEnemy();
        }
        else
        {
            Shoot();

            float dist = Vector3.Distance(enemy.transform.position, transform.position);
            if (dist > FindRadius)
                enemy = null;
        }
    }
    private void FindEnemy()
    {       
        var enemies = GameObject.FindObjectsOfType<Enemy>();//Собираем всех врагов на карте на карте
        float min = FindRadius;
        Enemy minEnemy = null;//Юнит, дистанция до которого минимальна

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
}
