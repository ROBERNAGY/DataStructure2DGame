using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saved : MonoBehaviour
{
    public Transform NewPoint;
    private void OnTriggerEnter2D(Collider2D other)
    {
        CharacterController Character = other.GetComponent<CharacterController>();
        if (other.tag == "Character")
        {
            Character.Startpoint.position = NewPoint.transform.position;
        }

    }
}

