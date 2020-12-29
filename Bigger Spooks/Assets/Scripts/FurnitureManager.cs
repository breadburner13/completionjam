using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureManager : MonoBehaviour
{
    public Furniture[] furnitures = {};
    public Transform tracking;
    public Rigidbody2D trackingRB;

    void Awake() 
    {
        tracking = FindObjectOfType<Ghost>().transform;
        trackingRB = FindObjectOfType<Ghost>().GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        
    }

    public int calculateScore()
    {
        int sum = 0;
        foreach(Furniture f in furnitures)
        {
            sum += f.getScore();
        }
        return sum;
    }
}
