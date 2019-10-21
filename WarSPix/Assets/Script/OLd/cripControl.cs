using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cripControl : MonoBehaviour {
    float FindRadius = 10000f;
    float TimeShoot = 1f;
    GameObject bullet;
    iron_resources enemy;
    StockControl Stock_;


    Transform towerHead;
    int inventory;
    int maxSpaciousness;//максимальная вместительность  инвентаря
    float timerShoot = 0f;
    bool IsWork;// работает над ресурсом
    bool IsAWay;//без работы, в пути к источникам ресурсов 
    bool IsUnemployed;//ресурсы закончились, больше нечего добывать
    bool InComingStock;// перенос ресурсов в склад при полном инвентаре
    bool IsFull()
    {
        return inventory == maxSpaciousness;
    }
    int extractionInTTact;//сколько может взять за такт



    public void MoveHome(Transform positionparrent)
    {
        Vector3 vect = Stock_.transform.position - transform.position;
        //vect.y = 0;
        float _speed = Time.deltaTime * 15;
        transform.Translate(vect.normalized * _speed);


        float dist = Vector3.Distance(Stock_.transform.position, transform.position);
        if (dist < 1)
        {
            //print("ST:" + Stock_.transform.position);
            // print("M:" + transform.position);
            if (Stock_.IsFull())
            {
                FindEnemy(3);
                return;
            }
            Stock_.unloadingRes(ref inventory);



            InComingStock = false;
        }
    }
        // Use this for initialization
        private void Awake()
        {

            IsUnemployed = false;
            InComingStock = false;
            IsWork = false;
            IsAWay = true;
            enemy = null;
            Stock_ = null;
            maxSpaciousness = 18;
            extractionInTTact = 2;
            inventory = 0;
        }
        void Start() {

        }

        // Update is called once per frame
        void Update() {
            if (IsUnemployed) return;

            if (InComingStock)
            {
                GoToStock();
            }

            if (IsFull())
            {
                IsWork = false;
                InComingStock = true;
                FindEnemy(3);

                return;

            }

            if (!IsWork)
            {

                if (enemy == null)
                {
                    // Ищем противника
                    FindEnemy(1);
                }
                GoToPath();
                return;


            }


            //IsWork = false;
            bool inf = false;
            if (!enemy)
            {
                IsWork = false;
            }
            int dop = enemy.Production(extractionInTTact, ref inf);

            inventory += dop;
            Invoke("EnableGO", 10f);
            //print(inventory);
            if (inf)
            {
                if (enemy)
                    Destroy(enemy.gameObject);
                enemy = null;
                IsWork = false;
            }





        }


        //1- поиск железа, 2- поиск меди, 3- поиск хранилища        
        private void FindEnemy(int flag)
        {
            float min = FindRadius;
            float dist = 0;
            switch (flag)
            {
                case 1:
                    {
                        var enemies = GameObject.FindObjectsOfType<iron_resources>();
                        iron_resources minEnemy = null;
                        foreach (var e in enemies)
                        {
                            dist = Vector3.Distance(e.transform.position, transform.position);

                            if (dist <= min)
                            {
                                min = dist;
                                minEnemy = e;
                            }
                        }

                        enemy = minEnemy;
                        if (enemy == null)
                        {
                            IsWork = false;
                            IsUnemployed = true;
                        }

                        break;
                    }
                case 2:
                    {
                        var enemies = GameObject.FindObjectsOfType<iron_resources>();
                        break;
                    }
                case 3:
                    {
                        var stocks = GameObject.FindObjectsOfType<StockControl>();
                        StockControl minStock = null;
                        foreach (var e in stocks)
                        {
                            dist = Vector3.Distance(e.transform.position, transform.position);

                            if (dist <= min)
                            {
                                min = dist;
                                minStock = e;
                                //break;
                            }
                        }

                        Stock_ = minStock;
                        break;
                    }
            }



        }

        void GoToPath()//перемещение к цели
        {

            if (IsUnemployed) return;
            if (enemy == null) { FindEnemy(1); return; }
            Vector3 vect = enemy.transform.position - transform.position;
            //vect.y = 0;

            float _speed = Time.deltaTime * 15;
            transform.Translate(vect.normalized * _speed);


            float dist = Vector3.Distance(enemy.transform.position, transform.position);
            if (dist < 2)
            {
                IsWork = true;
            }
        }

        void GoToStock()//перемещение к цели
        {

            Vector3 vect = Stock_.transform.position - transform.position;
            //vect.y = 0;
            float _speed = Time.deltaTime * 15;
            transform.Translate(vect.normalized * _speed);


            float dist = Vector3.Distance(Stock_.transform.position, transform.position);
            if (dist < 1)
            {
                //print("ST:" + Stock_.transform.position);
                // print("M:" + transform.position);
                if (Stock_.IsFull())
                {
                    FindEnemy(3);
                    return;
                }
                Stock_.unloadingRes(ref inventory);



                InComingStock = false;
            }
        }
    }
