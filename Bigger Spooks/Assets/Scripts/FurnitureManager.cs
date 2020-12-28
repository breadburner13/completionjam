using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureManager : MonoBehaviour
{
    public Furniture[] furnitures = {};
    public Transform tracking;

    void Awake() 
    {
        tracking = FindObjectOfType<Ghost>().transform;
    }
    void Update()
    {
        Debug.Log(tracking.position);
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
