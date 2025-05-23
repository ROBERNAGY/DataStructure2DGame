using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    public override void Init()
    {
        base.Init();
    }
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        CharacterController Character = other.GetComponent<CharacterController>();
        if (other.tag == "Character")
        {
            Character.Characters["Health"] -= 50;
            if (Character.Characters["Health"] == 0)
            {
              Character.Trapped = true;
              Character.Characters["Lives"]--;
            }
        }
        if (other.tag == "Sw")
        {
            Speed = 0;
            anim.SetBool("Dead", true);
           Destroy(this.gameObject , 0.7f);       
        }
   
    }
}
