using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        CharacterController Character = other.GetComponent<CharacterController>();
        if (other.tag == "Character")
        {   
            if(Character != null)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (Character.Diamonds[i] == 0)
                    {
                        Character.Diamonds[i] = 15;
                        Character.ScoreValue += 15;
                      if (i == 4 ||i == 9 )
                      {
                            Character.Characters["Lives"]++;
                      }
                      break;
                    }
                }
            Destroy(this.gameObject);
            }
        }
    }
}
