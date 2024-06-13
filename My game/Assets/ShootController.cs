using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour

{
    [SerializeField]
    private GameObject prefabbullet;
    private bool canShoot = true;
    private bool flipFlag;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        flipFlag = GameObject.Find("Player").GetComponent<MoveController>().FlipFlag;
        if (Input.GetKeyDown(KeyCode.F) && canShoot)
        {

            if (prefabbullet != null)
            {
                StartCoroutine(DelayBetweenShoot());
                Instantiate(prefabbullet, new Vector3(transform.position.x + (flipFlag ? 1 : -1), transform.position.y, transform.position.z), Quaternion.identity);
            }
        }
    }
    IEnumerator DelayBetweenShoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(1f);
        canShoot = true;
    }
}
