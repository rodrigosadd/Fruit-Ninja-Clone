using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Rigidbody rbody;
    public float impulseForce;
    private GameObject _currentExplosion;
    private float _countdown;

    void Awake()
    {
        rbody = GetComponent<Rigidbody>();          
    }

    void Update()
    {
        CountdownDeactivateObject();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Cut")
        {
            GameManager.instance.isEndGame = true;
            _countdown = 0;
            gameObject.SetActive(false);
            GameObject explosion = GameManager.GetPool().TryToGetExplosion();
            explosion.transform.position = transform.position;
            explosion.transform.rotation = transform.rotation;  
            _currentExplosion = explosion;      
            AudioManager.instance.Play("Explosion");
        }
    }

    void CountdownDeactivateObject()
    {
        if(_countdown < 1)
        {
            _countdown += Time.deltaTime / 3f;
        }
        else
        {
            _countdown = 0;
            gameObject.SetActive(false);
        }
    }
}