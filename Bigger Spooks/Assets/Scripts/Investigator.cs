using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Investigator : MonoBehaviour
{
    #region movment_vars
    private Rigidbody2D InvestRB;
    [SerializeField]
    private float move_speed;
    [SerializeField]
    private FurnitureManager Fmanager;
    [SerializeField]
    [Tooltip("the direction the investigator enters from")]
    private Vector3 door_vect;
    private bool start_exit;
    private bool exiting;
    private bool entering;
    [SerializeField]
    private GameObject door;
    #endregion

    #region attack_vars
    private float attack_timer;
    [SerializeField]
    private float attack_length;
    private bool attacking;
    [SerializeField]
    private Image flash;
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
        if (Fmanager.tracking.transform.CompareTag("Furniture"))
        {
            Vector3 target = Fmanager.tracking.position;
            Vector2 direction = target - transform.position;
            InvestRB.velocity = direction.normalized * move_speed;
            float angle = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }
        else
        {
            InvestRB.velocity = Vector2.zero;
        }
    }
    private void exit()
    {
        if (Vector3.Distance(door.transform.position, transform.position) <= .5)
        {
            start_exit = false;
        }

        if (start_exit && Vector3.Distance(door.transform.position, transform.position) > .5)
        {
            Vector2 direction =  door.transform.position - transform.position;
            InvestRB.velocity = direction.normalized * move_speed;
            return;
        }

        if(Vector3.Distance(transform.position, door.transform.position - door_vect) < .5 && !start_exit)
        {
            exiting = false;
            entering = true;
        }
        
        InvestRB.velocity = -(door_vect.normalized) * move_speed;
    }

    private void enter()
    {
        if (Vector3.Distance(transform.position, door.transform.position + door_vect) < 1)
        {
            entering = false;
            attacking = false;
        }
        InvestRB.velocity = door_vect.normalized * move_speed;
    }
    #endregion

    #region attack_func
    IEnumerator attack()
    {
        Debug.Log("attacked");
        attacking = true;
        attack_timer = attack_length;
        flash.color = new Color(flash.color.r, flash.color.g, flash.color.b, 255f);
        InvestRB.velocity = Vector2.zero;
        start_exit = true;
        exiting = true;
        float alpha = flash.color.a;
        float timer = 0;
        while(alpha > 0)
        {
            Debug.Log("flashing");

            flash.color = Color.Lerp(flash.color, new Color(flash.color.r, flash.color.g, flash.color.b, 0), timer/15);
            alpha = flash.color.a;
            timer += Time.deltaTime;
            yield return null;
        }
        Debug.Log("no flash");
        yield return null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!attacking && collision.transform.CompareTag("Furniture"))
        {
            Furniture fur = collision.transform.GetComponent<Furniture>();
            if (fur.possessed)
            {
                StartCoroutine(attack());
            }
        }
    }
    #endregion
}
