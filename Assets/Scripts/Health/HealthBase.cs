using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public Action OnKill;
    public int startLife = 6;

    public bool destroyOnKill = false;

    public float delayToKill = 0f;

    private float _currentLife;
    private bool _isDead = false;

    public ParticleSystem deathVFX;
    


    private void Awake()
    {
        Init();
      
    }

    private void Init()
    {
        _isDead = false;
        _currentLife = startLife;
    }

    public void Damage(int damage)
    {
        if (_isDead) return;
        _currentLife -= damage;

        if(_currentLife <=0)
        {
            Kill();
        }

    }

    private void Kill()
    {
        _isDead = true;

        if(destroyOnKill)
        {
            Destroy(gameObject, delayToKill);
            
        }
        OnKill?.Invoke();

        PlayDeathVFX();
    }

    private void PlayDeathVFX()
    {
        if (deathVFX != null) deathVFX.Play();
    }

}
