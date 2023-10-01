using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : FindObject
{
    
    public Waepon waepon1;
    public PlayerLife playerLife;
    public PlayerMoment playerMoment;
    public static Rigidbody2D rb;
    private Animator animator;
    public static SpriteRenderer sp;
    public static BoxCollider2D coll;
    PlayerControls controls;
    [SerializeField]  bool h_shoot = false;
    [SerializeField] public float h_ShootingDelay = 0;
    
    public bool h_IsRight = true;
    private  enum MovementState { idle, fly, jump,shoot,throws,run,attack}

   
    private void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();

        controls.Land.Shoot.performed += ctx => 
        {
            if (h_ShootingDelay <= 0)
            {
                h_shoot = true;
            }
             

        };
        

    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
       


    }

    // Update is called once per frame
    void Update()
    {
        ShootingDelay();


    }
    protected void ShootingDelay()
    {
        if (h_ShootingDelay>0)
        {
            h_ShootingDelay -= Time.deltaTime;
        }
    }
    public void FixedUpdate()
    {
        UpdateAnimation();
        IsRotate();
       
    }
    private void UpdateAnimation()
    {
        MovementState state;

        if (playerMoment.h_IsFly == false)
        {
            if (PlayerMoment.Dir == 0)
            {

                state = MovementState.idle;
            }
            else
            {

                state = MovementState.run;


            }

            if (rb.velocity.y > .1f)
            {

                state = MovementState.jump;


            }
            else if (rb.velocity.y < -.1f)
            {
                state = MovementState.jump;
            }
        }
        else
        {
            state = MovementState.fly;
        }
            

        
        

        if (h_shoot == true && h_ShootingDelay<=0)
        {
            state = MovementState.shoot;
            Shooting();
            h_ShootingDelay = 0.5f;
        }
        

       
        animator.SetInteger("State", (int)state);


    }

    
    private void IsRotate()
    {
        if(PlayerMoment.Dir>0 && !h_IsRight)
        {
            Filp();
        }else if(PlayerMoment.Dir<0 && h_IsRight)
        {
            Filp();
        }
    }
    public void Filp()
    {
        h_IsRight= !h_IsRight;
        transform.Rotate(0, 180, 0);
    }
    public void Shooting()
    {
        
         h_shoot = false;
       
        
         waepon1.Shoot();
        
       
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Dead"))
        {
            playerLife.PlayerDead();
        }

    }
}
