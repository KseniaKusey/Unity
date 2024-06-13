using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    [Range(0, 15f)]
    private float bulletSpeed;
    private bool bulletRight;
    private Camera playerCamera;
    // Start is called before the first frame update
    void Start()
    {
        playerCamera = Camera.main;
        bulletRight = GameObject.Find("Player").GetComponent<MoveController>().FlipFlag;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(bulletSpeed);
        var tmp = new Vector3((bulletRight ? bulletSpeed : -bulletSpeed) * Time.deltaTime, 0, 0);
        Debug.Log(tmp);
        transform.Translate(tmp);
        if (playerCamera != null)
        {
            if (playerCamera.WorldToViewportPoint(transform.position).x < 0 || playerCamera.WorldToViewportPoint(transform.position).x > 1)
                Destroy(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }


    //transform.SetPositionAndRotation(new Vector3(2.0f, -2.0f, 0.0f), transform.rotation);
    //transform.Translate(new Vector3((bulletRight ? bulletSpeed : -bulletSpeed) * Time.deltaTime, transform.position.y, transform.position.z)); 


    /*Debug.Log("!" + playerCamera.ScreenToWorldPoint(transform.position));
    Debug.Log("?" + playerCamera.ScreenToViewportPoint(transform.position));
    Debug.Log("&" + playerCamera.WorldToScreenPoint(transform.position));
    Debug.Log(bulletSpeed);
    var tmp = new Vector3((bulletRight ? bulletSpeed : -bulletSpeed) * Time.deltaTime, 0, 0);
    Debug.Log(tmp);
    transform.Translate(tmp);*/

}

