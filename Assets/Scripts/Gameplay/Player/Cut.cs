using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cut : MonoBehaviour
{
    public Collider cutCollider;
    private TrailRenderer _currentTrail;
    private Rigidbody _rbody;
    private bool _isCutting;

    void Start()
    {
        _rbody = GetComponent<Rigidbody>();
        cutCollider = GetComponent<Collider>();
    }

    void Update()
    {
        if(!GameManager.instance.isEndGame)
        {   
            Inputs();
            CutCheck();
        }
    }

    void Inputs()
    {
        if (Input.touchCount > 0 && !_isCutting)
        {
            InitializeCutting();
        }
        else if(Input.touchCount <= 0 && _isCutting)
        {
            FinishCutting();
        }
    }

    void CutCheck()
    {
        if (_isCutting)
        {
            UpdateCut();
        }
    }

    void UpdateCut()
    {
        Touch currentTouch = Input.GetTouch(0); 

        Vector3 newPosition = Camera.main.ScreenToWorldPoint(currentTouch.position);
        newPosition.z = 0f;
        _rbody.position = newPosition;
        _currentTrail.transform.position = newPosition;
    }

    void InitializeCutting()
    {
        _isCutting = true;
        cutCollider.enabled = true;        
        TrailRenderer trail = GameManager.GetPool().TryToGetTrail();
        trail.transform.position = transform.position;
        trail.transform.rotation = transform.rotation;
        _currentTrail = trail;
    }

    void FinishCutting()
    {
        _isCutting = false;
        cutCollider.enabled = false;
        _currentTrail.gameObject.SetActive(false);
    }
}
