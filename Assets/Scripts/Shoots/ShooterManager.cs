using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterManager : MonoBehaviour
{
    public ProjectileFire prefabProjectile;

    public Transform positionToFire;

    public float timeBetweenShoot = .2f;
    public Transform playerSideReference;

    private Coroutine _currentCoroutine;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            _currentCoroutine = StartCoroutine(StartFire());
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            if (_currentCoroutine != null) StopCoroutine(_currentCoroutine);
        }
    }

    IEnumerator StartFire()
    {
        while(true)
        {
            Shoot();
            yield return new WaitForSeconds(timeBetweenShoot);
        }
    }
    public void Shoot()
    {
        var projectile = Instantiate(prefabProjectile);
        projectile.transform.position = positionToFire.position;
        projectile.side = playerSideReference.transform.localScale.x;
    }
}

