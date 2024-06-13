using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    private int numberCheck;
    private Vector3 spawnPos;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        numberCheck = 1;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap" || collision.gameObject.tag == "Enemy")
        {
            StartCoroutine(DieDelay());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Check")
        {
            if (numberCheck != Convert.ToInt16(collision.gameObject.name.Substring(gameObject.name.Length - 1)))
            {
                spawnPos = collision.transform.position;
                numberCheck = Convert.ToInt16(collision.gameObject.name.Substring(gameObject.name.Length - 1));
            }
        }
    }
    IEnumerator DieDelay()
    {
        animator.SetTrigger("IsDie");
        yield return new WaitForSeconds(0.3f);
        animator.SetTrigger("IsIdle");
        gameObject.transform.position = spawnPos;

    }
}
