using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : MonoBehaviour
{
    // Start is called before the first frame update
    public bool possessed; 
    public float speed;
    public float friction;
    public Ghost ghost;
    public Rigidbody2D furnitureRB;
    public Collider2D furnitureCD;
    private Vector3 startPos;
    void Awake() 
    {
        ghost = GameObject.FindGameObjectWithTag("Ghost").GetComponent<Ghost>();
        furnitureRB = GetComponent<Rigidbody2D>();
        furnitureCD = GetComponent<Collider2D>();
        furnitureRB.drag = friction;
        furnitureRB.angularDrag = friction;
        furnitureCD.density = friction/500;
        startPos = transform.position;
    }
    void Update()
    {
        
    }

    public int getScore()
    {
        return (int)Math.Round(Vector3.Distance(transform.position, startPos));
    }
    void OnMouseDown() 
    {
        // Debug.Log("Kimi wa ne tashika ni ano toki watashi no soba ni ita Itsudatte itsudatte itsudatte sugu yoko de waratteita nakushitemo"); 
        // Debug.Log("Torimodosu kimi wo I will never leave you. If you wanna battle, then Ill take it to the streets Where theres no rules Take off the gloves ref,"); 
        // Debug.Log("please step down Gotta prove my skills so get down My lyrical dempsey roll about to smack down now Gotta shoot to kill and shoot the skill Dont you be afraid,");
        // Debug.Log("mans gotta do how it feels Six to seven to eight to nine ten I flip the script to make it to the top ten, go Dreamless dorm, ticking clock I walk away from the");
        // Debug.Log("soundless room Windless night, moonlight melts My ghostly shadow into the lukewarm gloom Nightly dance of bleeding swords Reminds me that I still live Every mans ");
        // Debug.Log("gotta fight the fear Im the first to admit it Sheer thoughts provoke the new era Become a big terror, but my only rival is my shadow Rewind then play it back and");
        // Debug.Log("fix my own error Get low to the ground, its getting better Like I told you before, double up and take more cheddar L to the J, say stay laced, heres my card, B Royal flush and Im the ace");
        ghost.possess(this);
    }
}
