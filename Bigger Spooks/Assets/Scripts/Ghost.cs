using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public Furniture currFurniture;
    private float x_input;
    private float y_input;
    void Start()
    {
        
    }

    void Update()
    {
        x_input = Input.GetAxisRaw("Horizontal");
        y_input = Input.GetAxisRaw("Vertical");
        move();
    }

    private void move()
    {
        if(currFurniture)
        {
            currFurniture.furnitureRB.velocity = new Vector2(x_input, y_input).normalized * currFurniture.speed;
        }
    }
}
