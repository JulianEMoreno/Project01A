﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerShip : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 15f;
    [SerializeField] float _turnSpeed = 3f;

    Rigidbody _rb = null;



    private void Awake()
    {
        GetComponent<ParticleSystem>().Play();
        ParticleSystem.EmissionModule em = GetComponent<ParticleSystem>().emission;
        em.enabled = false;

        _rb = GetComponent<Rigidbody>();
    }
    [System.Obsolete]
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<ParticleSystem>().Play();
            ParticleSystem.EmissionModule em = GetComponent<ParticleSystem>().emission;
            em.enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            GetComponent<ParticleSystem>().Play();
            ParticleSystem.EmissionModule em = GetComponent<ParticleSystem>().emission;
            em.enabled = true;
        }
       if (Input.GetKeyUp(KeyCode.W))
        {
            GetComponent<ParticleSystem>().Play();
            ParticleSystem.EmissionModule em = GetComponent<ParticleSystem>().emission;
            em.enabled = false;
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            GetComponent<ParticleSystem>().Play();
            ParticleSystem.EmissionModule em = GetComponent<ParticleSystem>().emission;
            em.enabled = false;
        }
    }
    private void FixedUpdate()
    {
        MoveShip();
        TurnShip();
    }

    void MoveShip()
    {
       
        // S/Down = -1, W/Up = 1, None = 0. Scale by moveSpeed
        float moveAmountThisFrame = Input.GetAxisRaw("Vertical") * _moveSpeed;

        //combine our direction with our calculated amount
        Vector3 moveDirection = transform.forward * moveAmountThisFrame;

        //apply the movement to the physics object 
        _rb.AddForce(moveDirection);

    }

    void TurnShip()
    {
        // A/Left = -1, D/Right = 1, None = 0. Scale by turnSpeed
        float turnAmountThisFrame = Input.GetAxisRaw("Horizontal") * _turnSpeed;

        //Specify an axis to apply our turn amount (x,y,z) as a rotation
        Quaternion turnOffset = Quaternion.Euler(0, turnAmountThisFrame, 0);

        //apply the movement to the physics object 
        _rb.MoveRotation(_rb.rotation * turnOffset);

    }

    public void Kill()
    {
        Debug.Log("Player has been killed!");
        this.gameObject.SetActive(false);
    }
}
