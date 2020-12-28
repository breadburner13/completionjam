using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : MonoBehaviour
{
    // Start is called before the first frame update
    public bool possessed; 
    public float speed;
    public Rigidbody2D furnitureRB;
    void Awake() 
    {
        furnitureRB = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        
    }
}
