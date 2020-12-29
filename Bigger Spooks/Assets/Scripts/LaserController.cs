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
    private Health health;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
        lineRenderer.useWorldSpace = true;
        fm = FindObjectOfType<FurnitureManager>();
        target = FindObjectOfType<Ghost>();
        originalSpeed = target.ghostSpeed;
        firing = false;
        health = GetComponent<Health>();
    }

    void Update()
    {
        if (firing && Time.time - fireStartTime >= attackLength || health.health <= 0)
        {
            firing = false;
            lineRenderer.enabled = false;
            fireStartTime = 0;
        }
        else if (firing) {
            RaycastHit2D hit = Physics2D.Raycast(transform.position + direction, direction, laserLength);
            if (hit.collider != null && hit.collider.CompareTag("Furniture"))
            {
                Furniture furniture = hit.collider.GetComponent<Furniture>();
                if (furniture.possessed)
                {
                    target.ghostSpeed = slowSpeed;
                }
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

    private void AbsorbTime()
    {
        firing = false;
        lineRenderer.enabled = false;
        fireStartTime = 0;
    }
}
