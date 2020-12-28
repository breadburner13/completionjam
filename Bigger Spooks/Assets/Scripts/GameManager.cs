using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Furniture[] furnitures = {};
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
