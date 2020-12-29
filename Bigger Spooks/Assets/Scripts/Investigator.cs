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
    [Tooltip("the direction the investigator enters from")]
    private Vector3 door_vect;
    private bool start_exit;
    private bool exiting;
    private bool entering;
    private GameObject door;
    #endregion

    #region attack_vars
    private float attack_timer;
    [SerializeField]
    private float attack_length;
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
        else if (exiting)
        {
            exit();
        }
        else if(attack_timer > 0)
        {
            attack_timer -= Time.deltaTime;
        } else if (entering)
        {
            enter();
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
        if(start_exit && Vector3.Distance(door.transform.position, transform.position) > 1)
        {
            Vector2 direction =  door.transform.position - transform.position;
            InvestRB.velocity = direction.normalized * move_speed;
            if(Vector3.Distance(door.transform.position, transform.position) <= 1)
            {
                start_exit = false;
            }
        }
   
        if(transform.position == door.transform.position - door_vect)
        {
            exiting = false;
        }
        InvestRB.velocity = -(door_vect.normalized) * move_speed;
        entering = true;

    }

    private void enter()
    {
        if (transform.position == door.transform.position + door_vect)
        {
            entering = false;
        }
        InvestRB.velocity = door_vect.normalized * move_speed;
        entering = false;
    }
    #endregion

    #region attack_func
    IEnumerator attack()
    {
        start_exit = true;
        yield return null;
    }
    #endregion
}
