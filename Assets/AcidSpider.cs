using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidSpider : MonoBehaviour
{
    public GameObject AcidPref;

    private void Start()
    {
        
    }
    private void Update()
    {
        attack();
    }
    void attack()
    {
        Instantiate(AcidPref, transform.position, Quaternion.identity);
    }
}
