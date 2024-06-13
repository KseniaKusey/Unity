using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotrollController : MonoBehaviour
{
    private bool flipFlag = false;
    private bool stay = false;
    [SerializeField]
    private float speed;
    private Animator animator;
    private SpriteRenderer render;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!stay)
           transform.Translate(new Vector3(flipFlag ? speed : -speed, 0, 0) * Time.deltaTime);  
    }
    private void Flip()
    {
        render.flipX = flipFlag;
        flipFlag = !flipFlag;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!stay)
            StartCoroutine(StayDelay());
    }
    IEnumerator StayDelay()
    {
        stay = true;
        animator.SetTrigger("isIdle");
        yield return new WaitForSeconds(5);
        animator.SetTrigger("isRun");
        stay = false;
        Flip();

    }
}
