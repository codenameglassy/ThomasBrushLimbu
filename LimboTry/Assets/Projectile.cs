using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float force;
    [SerializeField] float life = 3f;
    Transform crossHair;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        crossHair = GameObject.Find("CrossHair").transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(transform.right * force, ForceMode2D.Impulse);
        Destroy(gameObject, life);
    }

    
}
