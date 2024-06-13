using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MoveController : MonoBehaviour
{
   
    [SerializeField]
    private float speed;
    [SerializeField]
    private float powerJump;
    private bool flipFlag = true;
    private bool canJump = true;
    private bool enable = true;
    private Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public float radiusGroundCheck;
    private bool isGrounded;
    private SpriteRenderer render;
  
    

    public bool CanJump { get => canJump; }
    public bool FlipFlag { get => flipFlag; }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        //if(Input.GetKeyDown(KeyCode.D))//Однократное нажатие
        if(Input.GetKey(KeyCode.D))
            transform.Translate(new Vector2(speed * Time.deltaTime, 0));
        else if(Input.GetKey(KeyCode.A))
            transform.Translate(new Vector2(-speed * Time.deltaTime, 0));
        */
        if (enable)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, radiusGroundCheck, whatIsGround);
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                canJump = true;
                rb.AddForce(powerJump * Vector2.up, ForceMode2D.Impulse);
                //transform.Translate(powerJump * Vector2.up);//Vector2.up = new Vector2(0, 1);
            }
            if ((flipFlag && Input.GetAxis("Horizontal") < 0) || (!flipFlag && Input.GetAxis("Horizontal") > 0))
                Flip();
            transform.Translate(new Vector2(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0));//Перемещение по предопределенным осям "Horizotal"(left, right, a, d) или "Vertical"(Up, Down, w, s)
        }
    }

    private void Flip()
    {
        render.flipX = flipFlag;
        flipFlag = !flipFlag;
    }

    private void OnCollisionEnter(Collision collision)
    {
        canJump = false;
    }
    
    
    
}
