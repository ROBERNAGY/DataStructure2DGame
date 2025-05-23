using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wapeon : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletpref;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shoot();
        }
    }
    public void shoot()
    {
        Instantiate(bulletpref, firepoint.position, firepoint.rotation);
    }
}

