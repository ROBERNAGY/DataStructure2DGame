using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        CharacterController Character = other.GetComponent<CharacterController>();
        if (other.tag == "Character")
        {
            Character.Trapped = true;
            Character.Characters["Lives"]--;
        }
    }    
}
