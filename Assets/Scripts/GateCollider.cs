using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateCollider : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D Other)
    {
        CharacterController Character = Other.GetComponent<CharacterController>();
        if (Other.tag == "Character")
        {
            Character.Win = true;
        }
    }
}
