using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class LaserController : MonoBehaviour
{

    public float laserLength;
    public float attackLength;
    public float slowSpeed;
    public float recovery;

    private float originalSpeed;
    private bool firing;
    private float fireStartTime;
    private LineRenderer lineRenderer;
    private Transform objectHit;
    private Vector3 direction;
    private FurnitureManager fm;
    private Ghost target;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
        lineRenderer.useWorldSpace = true;
        fm = FindObjectOfType<FurnitureManager>();
        target = FindObjectOfType<Ghost>();
        originalSpeed = target.ghostSpeed;
        firing = false;
    }

    void Update()
    {
        if (firing && Time.time - fireStartTime >= attackLength)
        {
            firing = false;
            lineRenderer.enabled = false;
            fireStartTime = 0;
        }
        else if (firing) {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, laserLength);
            Debug.Log(hit.transform.position);
            if (hit.transform == fm.tracking)
            {
                target.ghostSpeed = slowSpeed;
            }
        }

        if (fireStartTime + attackLength >= recovery)
        {
            target.ghostSpeed = originalSpeed;
        }
    }

    public void Fire()
    {
        if (!firing)
        {
            direction = fm.tracking.position - transform.position;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, fm.tracking.position);
            lineRenderer.enabled = true;
            firing = true;
            fireStartTime = Time.time;   
        }
    }
}
