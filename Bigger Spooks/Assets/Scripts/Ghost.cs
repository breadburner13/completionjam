using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public Furniture currFurniture;
    private float x_input;
    private float y_input;
    private GameManager gm;
    private SpriteRenderer ghostSR;
    private Vector3 mousepos;
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
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
        //transform.position = mousepos;
        this.transform.position = mousepos;
        move();
        if (Input.GetKeyDown("z"))
        {
            this.ghostSR.enabled = true;
            currFurniture.possessed = false;
            currFurniture = null;
        }
    }

    private void move()
    {
        if(currFurniture)
        {
            currFurniture.furnitureRB.velocity = new Vector2(x_input, y_input).normalized * currFurniture.speed;
        }
        //Debug.Log(gm.calculateScore());
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
    }
}
