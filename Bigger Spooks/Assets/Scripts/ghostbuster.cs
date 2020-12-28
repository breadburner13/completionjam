using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostbuster : MonoBehaviour
{
    #region movment vars
    [SerializeField]
    private float speed;
    [SerializeField]
    private Transform ghost;
    private Rigidbody2D gbRB;
    #endregion

    #region attack_vars
    private bool attacking;
    [SerializeField]
    private float attack_length;
    private float attack_timer;
    #endregion

    #region unity_functions
    // Start is called before the first frame update
    void Start()
    {
        //get the transform of the ghost
        gbRB = GetComponent<Rigidbody2D>();
        attack_timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(attack_timer <= 0)
        {
            move();
        }
        else
        {
            attack_timer -= Time.deltaTime;
        }
    }

    #endregion

    #region movement_func

    private void move()
    {
        Vector2 my_pos = new Vector2(this.transform.position.x, this.transform.position.y);
        Vector2 ghost_pos = new Vector2(ghost.position.x, ghost.position.y);
        Vector2 distance = ghost_pos - my_pos;
        gbRB.velocity = distance.normalized * speed;
    }
    #endregion
}
