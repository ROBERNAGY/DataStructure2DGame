using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int Speed ;
    [SerializeField]
    protected int Health;
    [SerializeField]
    protected int Gems;
    [SerializeField]
    protected Transform PointA,PointB;

    protected Vector3 currentTarget;
    protected Animator anim;
    protected SpriteRenderer sprite;
    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        

    }
    private void Start()
    {
        Init();
    }
    public virtual void Update()
    {
        Movement();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        CharacterController Character = other.GetComponent<CharacterController>();
        if (other.tag == "Character")
        {
            Debug.Log("Hit: " + other.name);
        }
        else if (other.tag == "Sword")
        {
            Speed = 0;
            anim.SetBool("Dead", true);
            Destroy(this.gameObject, 0.7f);
        }
    }
    public virtual void Movement()
    {
        if (currentTarget == PointA.position)
        {
            sprite.flipX = true;
        }
        else 
        {
            sprite.flipX = false;
        }

        if (transform.position == PointA.position)
        {
            currentTarget = PointB.position;
           
        }
        else if (transform.position == PointB.position)
        {
            currentTarget = PointA.position;
         
        }
       
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, Speed * Time.deltaTime);
    }
}
