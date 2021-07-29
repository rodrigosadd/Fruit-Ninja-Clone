using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject slicedFruit;
    public Rigidbody rbody;
    public float impulseForce;
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
            GameManager.instance.points++;
            Vector3 direction = (other.transform.position - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);
            SlicedFruit slicedFruit = GameManager.GetPool().TryToGetSlicedFruit();
            slicedFruit.ResetValues();
            slicedFruit.transform.position = transform.position;
            slicedFruit.transform.rotation = rotation;
            _countdown = 0;
            gameObject.SetActive(false);
            AudioManager.instance.Play("Squelch");
        }
        else if(other.tag == "UncutFruits")
        {
            GameManager.GetUncutFruits().uncutFruits++;
            AudioManager.instance.Play("Impact");
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
