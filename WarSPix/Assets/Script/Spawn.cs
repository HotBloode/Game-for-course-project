using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{

    public GameObject Enemy;
    private float spawn;//Время между спавнами
    private float tmp;//Буфуер для изменения времени
    private float time=1;//Шаг уменьшения времени между волнами
    private int i = 0;//Счётчик монстров в одной волне 
    public bool isLeft;

    private int startNumberEnemy = 1;//Начальное колличество врагов
    private int stepNumberEnemy = 1;//Шаг увеличения колличества врагов
    private int maxNumberEnemy = 9;//Максимальное колличество врагов

    private float spawnPause;//Счётчик времени между спавнами монстров одной волны
    private float spawnPauseTmp=2;//Время между спавнами монстров одной волны
    Vector3 left = new Vector3(0,0,1);//Координаты спавна монстров слева
    Vector3 right = new Vector3(0,0,1);//Координаты спавна монстров справа

    private IEnumerator Mywait(int time)
    {
        yield return new WaitForSeconds(time);
        //Make all "нечто"
    }
    void Start()
    {
        spawn = 15;
        tmp = 15;
        spawnPause = 2;
    }


    void Update()
    {
        if (spawn > 0)
        {
            string inf;
            if (spawn >= 10)
            {
                inf = "Время до следующей волны: 00:" + (int)spawn;
            }
            else
            {
                inf = "Время до следующей волны: 00:0" + (int)spawn;
            }
            GameObject.Find("WaveInfo").GetComponent<Text>().text = inf;
            spawn -= Time.deltaTime;//Spawn Time - 1 sec           
        }
        else
        {
            if (i != startNumberEnemy)
            {
                GameObject g;
                Mywait(10000);
                g = Instantiate(Enemy, new Vector3(transform.position.x, transform.position.y, transform.position.z+1), transform.rotation);
                g.GetComponent<Enemy>().Myway = isLeft;
                Mywait(1000);
                g = Instantiate(Enemy, new Vector3(transform.position.x, transform.position.y, transform.position.z +1), transform.rotation);
                g.GetComponent<Enemy>().Myway = isLeft;
                i++;
                spawnPause -= Time.deltaTime;
                spawnPause = spawnPauseTmp;
            }
            else
            {
                if (startNumberEnemy < maxNumberEnemy)
                {
                    startNumberEnemy += stepNumberEnemy;
                }
                i = 0;
                spawn = tmp - time;
                tmp = spawn;
            }
        }
    }
    
}