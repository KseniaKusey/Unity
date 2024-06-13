using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckController : MonoBehaviour
{
    private bool isTake;
    public bool IsTake { get => isTake; set  { if (!value) isTake = value; } }
    // Start is called before the first frame update
    void Start()
    {
        isTake = true; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            isTake = true;
            CheckController[] massCheks = GameObject.Find("CHECKPOINTS").GetComponentsInChildren<CheckController>();
            foreach (CheckController script in massCheks)
            {
                script.IsTake = false;
            }
        }
    }
}
