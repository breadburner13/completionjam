﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public Furniture currFurniture;
    private float x_input;
    private float y_input;
    private FurnitureManager gm;
    private SpriteRenderer ghostSR;
    private Vector3 mousepos;
    public float ghostSpeed;
    public float ghostHealth;
    void Start()
    {
        gm = FindObjectOfType<FurnitureManager>();
        ghostSR = GetComponent<SpriteRenderer>();
        this.ghostSR.enabled = true;
        currFurniture = null;
    }

    void Update()
    {
        x_input = Input.GetAxisRaw("Horizontal");
        y_input = Input.GetAxisRaw("Vertical");
        mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousepos.z = 10;
        this.transform.position = mousepos;
        move();
        if (Input.GetKeyDown("z"))
        {
            this.ghostSR.enabled = true;
            currFurniture.possessed = false;
            currFurniture = null;
            gm.tracking = this.transform;
            gm.trackingRB = GetComponent<Rigidbody2D>();
        }
    }

    private void move()
    {
        if(currFurniture)
        {
            currFurniture.furnitureRB.velocity = new Vector2(x_input, y_input).normalized * currFurniture.speed * ghostSpeed;
            //Debug.Log(gm.calculateScore());
        }
    }

    public void possess(Furniture f)
    {
        this.ghostSR.enabled = false;
        if(currFurniture)
        {
            currFurniture.possessed = false;
        }
        currFurniture = f;
        f.possessed = true;
        gm.tracking = currFurniture.transform;
        gm.trackingRB = currFurniture.GetComponent<Rigidbody2D>();
    }

    public void takeDamage(float dmg)
    {
        ghostHealth -= dmg; 
        if (ghostHealth <= 0)
        {
            //show's over
        }
    }
}
