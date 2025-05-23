using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    public Dictionary<string, int> Characters = new Dictionary<string, int>();
    public string name = "Character";

    public GameObject Heart1, Heart2, Heart3, Heart4;

    public int[] Diamonds = new int[10];
    Rigidbody2D rb;
    public float Maxspeed= 5f;
    bool FacingRight = false;
    SpriteRenderer CR;
    Animator anim;

    public int ScoreValue = 0;
    public Text score;
    public Text Health;
    public bool Trapped = false;
    public bool Win = false;
    public Transform Startpoint;
    public GameObject Gameover;
    public GameObject levelComplete;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public int extraJumps;
    public int Jumps;
    public float JumpForce;
    public float dashSpeed = 200f;
    public GameObject Character;

 
    public AudioSource AttackSound;
    public AudioSource Jump;

    void Start()
    {
        Characters.Add(name, ScoreValue);
        Characters.Add("Health", 100);
        Characters.Add("Lives", 2);
 
        Heart1.gameObject.SetActive(true);
        Heart2.gameObject.SetActive(true);
        Heart3.gameObject.SetActive(false);
        Heart4.gameObject.SetActive(false);

        rb = GetComponent<Rigidbody2D>();
        CR = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        score.GetComponent<Text>();
        Health.GetComponent<Text>();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        float move = Input.GetAxis("Horizontal");
        if (move > 0 && !FacingRight)
        {
            Flip();
        }
       else if (move < 0 && FacingRight)
       {
            Flip();
       }

        //Dash
       else if (Input.GetKeyDown(KeyCode.E))
       {
            Character.transform.position = new Vector2(Character.transform.position.x + dashSpeed*Time.deltaTime, Character.transform.position.y);
            Flip();
       }
       else if (Input.GetKeyDown(KeyCode.Q))
       {
            Character.transform.position = new Vector2(Character.transform.position.x - dashSpeed*Time.deltaTime, Character.transform.position.y);
            Flip();
       }
        //Dash

        rb.velocity = new Vector2(move * Maxspeed, rb.velocity.y);
        anim.SetFloat("Run", Mathf.Abs(move)); 
        
    }
    private void Update()
    {
        Characters[name] = ScoreValue;

        if (Trapped && Characters["Lives"] != 0)
        {
            
            transform.position = Startpoint.position;
            Characters["Health"] = 100;
            

            Trapped = !Trapped;
        }
        if (Win)
        {
            levelComplete.SetActive(true);
            Time.timeScale = 0f;
        }  
        
        score.text = name + " " + Characters[name];
        Health.text = "Health " + Characters["Health"];

        switch (Characters["Lives"])
        {
            case 4:
                Heart1.gameObject.SetActive(true);
                Heart2.gameObject.SetActive(true);
                Heart3.gameObject.SetActive(true);
                Heart4.gameObject.SetActive(true);
                Time.timeScale = 1f;
                break;
            case 3:
                Heart1.gameObject.SetActive(true);
                Heart2.gameObject.SetActive(true);
                Heart3.gameObject.SetActive(true);
                Heart4.gameObject.SetActive(false);
                Time.timeScale = 1f;
                break;
            case 2:
                Heart1.gameObject.SetActive(true);
                Heart2.gameObject.SetActive(true);
                Heart3.gameObject.SetActive(false);
                Heart4.gameObject.SetActive(false);
                Time.timeScale = 1f;
                break;
            case 1:
                Heart1.gameObject.SetActive(true);
                Heart2.gameObject.SetActive(false);
                Heart3.gameObject.SetActive(false);
                Heart4.gameObject.SetActive(false);
                Time.timeScale = 1f;
                break;
            case 0:
                Heart1.gameObject.SetActive(false);
                Heart2.gameObject.SetActive(false);
                Heart3.gameObject.SetActive(false);
                Heart4.gameObject.SetActive(false);
                Gameover.SetActive(true);
                Time.timeScale = 0f;
                break;
        }


        if ( isGrounded == true)
        {
            extraJumps = Jumps;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps >0 )
        {
              rb.velocity = Vector2.up * JumpForce;
              extraJumps--;
              Jump.Play();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true)
        {
              rb.velocity = Vector2.up * JumpForce;
              Jump.Play();

        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
           

    }

    void Flip()
    {
        FacingRight = !FacingRight;
        CR.flipX = !CR.flipX;

    }
    
    void Attack()
    {
        anim.SetTrigger("Attack1");
        AttackSound.Play();
    }
}
