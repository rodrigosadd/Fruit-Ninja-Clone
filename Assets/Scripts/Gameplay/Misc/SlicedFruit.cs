using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlicedFruit : MonoBehaviour
{   
    public Rigidbody rbodyLeft;
    public Rigidbody rbodyRight;
    public Transform StartPositionRbodyLeft;
    public Transform StartPositionRbodyRight;
    private float _countdown;


    void Update()
    {
        CountdownDeactivateObject();
    }

    public void ResetValues()
    {
        rbodyLeft.transform.position = StartPositionRbodyLeft.position;
        rbodyRight.transform.position = StartPositionRbodyRight.position;
        rbodyLeft.velocity = Vector3.zero;
        rbodyRight.velocity = Vector3.zero;
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
