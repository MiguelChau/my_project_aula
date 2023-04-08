using System;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFire : MonoBehaviour
{
    public Vector3 direction;

    public float timeToDestroy = 2f;
    public float side = -1;
    public int damage = 3;

    

    private void Awake()
    {
        Destroy(gameObject, timeToDestroy);
    }

    private void Update()
    {
        transform.Translate(direction * Time.deltaTime * side);
    }
     private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.transform.GetComponent<EnemyBase>();

        if(enemy != null)
        {
            enemy.Damage(damage);
            Destroy(gameObject); 
        }
    }






}

