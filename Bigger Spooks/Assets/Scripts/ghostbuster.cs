using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBuster : MonoBehaviour
{
    public Ghost ghost;
    public bool possessed;

    #region movment vars
    [SerializeField]
    public float speed;
    public float distance;

    [SerializeField] 
    private FurnitureManager fm;
    public Rigidbody2D gbRB;
    #endregion

    public Health health;
    
    #region attack_vars

    [SerializeField] 
    private float attack_timer;
    public float cooldownTime;
    private float lastFireTime;
    public LaserController laser;
    #endregion

    #region unity_functions
    // Start is called before the first frame update
    void Start()
    {
        ghost = GameObject.FindGameObjectWithTag("Ghost").GetComponent<Ghost>();
        //get the transform of the ghost
        gbRB = GetComponent<Rigidbody2D>();
        attack_timer = 0;
        fm = FindObjectOfType<FurnitureManager>();
        laser = GetComponent<LaserController>();
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!possessed)
        {
            if(attack_timer <= 0)
            {
                move();
                if (Vector3.Distance(transform.position, fm.tracking.position) <= distance && 
                    Time.time - lastFireTime >= cooldownTime)
                {
                    laser.Fire();
                    lastFireTime = Time.time;
                    attack_timer = laser.attackLength;
                }
            }
            else
            {
                gbRB.velocity = Vector2.zero;
                attack_timer -= Time.deltaTime;
            }
        }
    }

    #endregion

    #region movement_func

    private void move()
    {
        if(!ghost.currGB)
        {
            Vector2 my_pos = new Vector2(this.transform.position.x, this.transform.position.y);
            Vector2 ghost_pos = new Vector2(fm.tracking.position.x, fm.tracking.position.y);
            Vector2 distance = ghost_pos - my_pos;
            gbRB.velocity = distance.normalized * speed;
            float angle = Mathf.Atan2(distance.y,distance.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }
    }
    #endregion

    void OnMouseDown() 
    {
        // Debug.Log("Kimi wa ne tashika ni ano toki watashi no soba ni ita Itsudatte itsudatte itsudatte sugu yoko de waratteita nakushitemo"); 
        // Debug.Log("Torimodosu kimi wo I will never leave you. If you wanna battle, then Ill take it to the streets Where theres no rules Take off the gloves ref,"); 
        // Debug.Log("please step down Gotta prove my skills so get down My lyrical dempsey roll about to smack down now Gotta shoot to kill and shoot the skill Dont you be afraid,");
        // Debug.Log("mans gotta do how it feels Six to seven to eight to nine ten I flip the script to make it to the top ten, go Dreamless dorm, ticking clock I walk away from the");
        // Debug.Log("soundless room Windless night, moonlight melts My ghostly shadow into the lukewarm gloom Nightly dance of bleeding swords Reminds me that I still live Every mans ");
        // Debug.Log("gotta fight the fear Im the first to admit it Sheer thoughts provoke the new era Become a big terror, but my only rival is my shadow Rewind then play it back and");
        // Debug.Log("fix my own error Get low to the ground, its getting better Like I told you before, double up and take more cheddar L to the J, say stay laced, heres my card, B Royal flush and Im the ace");
        ghost.possessGB(this);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Furniture"))
        {
            health.LoseHealth((int) other.rigidbody.velocity.magnitude);
        }
    }
    
}
