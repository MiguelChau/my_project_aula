using System;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFire : MonoBehaviour
{
    public float timeToDestroy = 4f;
    public string tagToLook = "Enemy";

    public Vector2 dir;

    public Action OnHitTarget;


    private void Update()
    {
        transform.Translate(dir * Time.deltaTime);
    }

    public void StartCarProjectileFire()
    {
        Invoke(nameof(FinishUsage), timeToDestroy);
    }

    private void FinishUsage()
    {
        gameObject.SetActive(false);
        OnHitTarget = null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == tagToLook)
        {
            Destroy(collision.gameObject);
            OnHitTarget?.Invoke();
            FinishUsage();
        }
    }

}

