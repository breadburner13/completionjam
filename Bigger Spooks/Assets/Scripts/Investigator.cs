using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Investigator : MonoBehaviour
{
    #region movment_vars
    private Rigidbody2D InvestRB;
    private float move_speed;
    [SerializeField]
    private FurnitureManager Fmanager;
    [SerializeField]
    private Vector2 door_vect;
    #endregion

    #region attack_vars
    private float attack_timer;
    [SerializeField]
    private float attack_length;
    private bool exiting;
    private bool entering;
    private bool attacking;
    #endregion

    #region Unity_funcs
    // Start is called before the first frame update
    void Start()
    {
        InvestRB = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!attacking)
        {
            move();
        }
        else if(attack_timer > 0)
        {
            attack_timer -= Time.deltaTime;
        } else if (exiting)
        {
            exit();
        }
        
    }
    #endregion

    #region Move_funcs
    private void move()
    {
        Vector3 target = Fmanager.tracking.position;
        Vector2 direction = target - transform.position;
        InvestRB.velocity = direction.normalized * move_speed;
    }
    private void exit()
    {

    }

    private void enter()
    {

    }
    #endregion
}
