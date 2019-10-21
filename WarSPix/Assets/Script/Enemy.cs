using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float MaxLife = 100f;
    public bool Myway;
    TowerBuild enemyTow = null;
    Basis enemyBuild = null;
    float speeds;
    Animator myAnim;

    private bool enemyTmp = false, enemyTawertTmp = false;

    //
    private float life;
    private float FindRadius = 999.0f;

    void Start()
    {
        speeds = 2.5F;
        life = MaxLife;
    }

    private void Awake()
    {
        myAnim = GetComponent<Animator>();
    }

    void Update()
    {
        myAnim.SetBool("isLeft", Myway);
        myAnim.SetBool("isRunAnimation", true);
        if (enemyTow == null && enemyBuild == null)
        {
            // Ищем противника
            FindEnemy();
        }
        else
        {
            if (enemyTawertTmp)
            {
                if (enemyTow == null)
                {
                    myAnim.SetBool("isRunAnimation", true);
                    enemyTawertTmp = false;
                    return;
                }


                // transform.position = Vector3.Lerp(transform.position, enemyTow.transform.position, speeds * Time.deltaTime);

                if (Vector3.Distance(enemyTow.transform.position, transform.position) > 1.5f)
                    transform.Translate((enemyTow.transform.position - transform.position).normalized * speeds * Time.deltaTime);
                else
                {
                    myAnim.SetBool("isRunAnimation", false);
                    DamageTower();
                }
                
            }
            else if (enemyBuild)
            {
                if (enemyBuild == null)
                {
                    myAnim.SetBool("isRunAnimation", true);
                    enemyTmp = false;
                    return;
                }

                if (Vector3.Distance(enemyBuild.transform.position, transform.position) > 1.5f)
                    transform.Translate((enemyBuild.transform.position - transform.position).normalized * speeds * Time.deltaTime);
                else
                {
                    myAnim.SetBool("isRunAnimation", false);
                    DamageBasis();
                }




            }
        }
    }

    //Дамаг по вышкам
    private void DamageTower()
    {
        if (Vector3.Distance(enemyTow.transform.position, transform.position) <= 1.5f)
        {            
            enemyTow.SetDamage(1);
        }
    }
    private void DamageBasis()
    {
        if (Vector3.Distance(enemyBuild.transform.position, transform.position) <= 1.5f)
        {
            enemyBuild.SetDamage(1);
        }
    }

    //Получение дамага и изменение НР
    public void SetDamage(float value)
    {
        life -= value;

        if (life <= 0)
            Destroy(gameObject);
    }

    //Поиск врага
    private void FindEnemy()
    {
        #region Tower
        //Поиск ближайшей вражеской вышки
        var enemiesTower = GameObject.FindObjectsOfType<TowerBuild>();
        float minTower = FindRadius;
        TowerBuild minEnemyTower = null;

        foreach (var e in enemiesTower)
        {
            float dist = Vector3.Distance(e.transform.position, transform.position);
            if (minTower > dist)
            {
                minTower = dist;
                minEnemyTower = e;
            }
        }
        #endregion

        #region Build
        var enemyBuild1 = GameObject.FindObjectsOfType<Basis>();
        float minBuild = FindRadius;
        Basis minEnemBuild1 = null;

        foreach (var e in enemyBuild1)
        {
            float dist = Vector3.Distance(e.transform.position, transform.position);
            if (minBuild > dist)
            {
                minBuild = dist;
                minEnemBuild1 = e;
            }
        }
        #endregion

        if (minTower < minBuild)
        {
            enemyTow = minEnemyTower;
            enemyTawertTmp = true;
        }
        else
        {
            enemyBuild = minEnemBuild1;
            enemyTmp = true;
        }
    }
}