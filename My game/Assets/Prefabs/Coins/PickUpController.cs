using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    private int score = 0;
    [SerializeField]
    private TMP_Text textMeshPro;
    private void Start()
    {
      textMeshPro.text += score;
    }
    private void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coins")
        {
            score++;
            Destroy(collision.gameObject);
            textMeshPro.text = textMeshPro.text.Substring(0,textMeshPro.text.Length - 1) + score;
        }
    }
}
