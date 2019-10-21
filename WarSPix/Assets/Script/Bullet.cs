using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float Speed = 25f;//скорость пули
    private float TimeLife = 1f;//время жизни
    public Enemy Enemy;
    public float Damage = 25f;//дамаг

    float timerLife = 0f;

    void Start()
    {
        timerLife = TimeLife;
    }

    void Update()
    {
        print("crate");
        timerLife -= Time.deltaTime;
        if (Enemy == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = Enemy.transform.position - transform.position;
        float _speed = Speed * Time.deltaTime;

        if (timerLife <= 0)
        {
            // Время жизни пули закончилось
            timerLife = TimeLife;
            Destroy(gameObject);
        }
        else if (dir.magnitude <= _speed)
        {
            // Пуля попадает в цель
            Enemy.SetDamage(Damage);
            Destroy(gameObject);
            return;
        }

        transform.position= Vector3.Lerp(transform.position,Enemy.transform.position, _speed);
    }
}
