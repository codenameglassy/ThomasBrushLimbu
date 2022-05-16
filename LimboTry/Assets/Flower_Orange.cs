using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower_Orange : MonoBehaviour
{
    Animator animator;
    [SerializeField] GameObject flowerSpore;
    Transform SpawnPos;
    private void Start()
    {
        animator = GetComponent<Animator>();
        SpawnPos = gameObject.transform.Find("SpawnPos").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetTrigger("Sway");
            Instantiate(flowerSpore, SpawnPos.position, SpawnPos.rotation);
            FindObjectOfType<AudioManagerCS>().Play("Chime");
        }
    }
}
