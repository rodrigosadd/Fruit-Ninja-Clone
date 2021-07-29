using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionParticle : MonoBehaviour
{
    private float _countdown;

    void Update()
    {
        CountdownDeactivateExplosion();
    }

    void CountdownDeactivateExplosion()
    { 
        if(_countdown < 1)
        {
            _countdown += Time.deltaTime / 1f;
        }
        else
        {
            _countdown = 0;
            gameObject.SetActive(false);
        }
    }
}
