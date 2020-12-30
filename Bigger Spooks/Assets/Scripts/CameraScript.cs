using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Ghost ghost;
    private float x_input;
    private float y_input;
    void moveGhost()
    {
        x_input = Input.GetAxisRaw("Horizontal");
        y_input = Input.GetAxisRaw("Vertical");
        Vector2 direction = new Vector2(x_input, y_input).normalized * Time.deltaTime * 10;
        transform.position += new Vector3(direction.x, direction.y, 0);
    }
    
    void moveFurniture() 
    {
        transform.position = new Vector3(ghost.currFurniture.transform.position.x, ghost.currFurniture.transform.position.y, -10);
    }

    void moveGB()
    {
        transform.position = new Vector3(ghost.currGB.transform.position.x, ghost.currGB.transform.position.y, -10);
    }

    void Update() 
    {
        if(ghost.currFurniture)
        {
            moveFurniture();
        }
        else if(ghost.currGB)
        {
            moveGB();
        }
        else
        {
            moveGhost();
        }
    }
}
