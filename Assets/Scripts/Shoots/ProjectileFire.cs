using System;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFire : MonoBehaviour
{
    public float timeToDestroy = 4f;
    public string tagToLook = "Enemy";
    public int damage = 3;

    public Vector2 dir;

    public Action OnHitTarget;


    private void Update()
    {
        transform.position += new Vector3(dir.x, dir.y, 0) * Time.deltaTime;
    }

    public void StartProjectileFire()
    {
        Invoke(nameof(FinishUsage), timeToDestroy);
    }

    private void FinishUsage()
    {
        gameObject.SetActive(false);
        OnHitTarget = null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == tagToLook)
        {
            Destroy(collision.gameObject);
            OnHitTarget?.Invoke();
            FinishUsage();
        }
    }

}

