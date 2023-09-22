using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public static Rigidbody2D rb;
    private Animator animator;
    public static SpriteRenderer sp;
    public static BoxCollider2D coll;
    PlayerControls controls;
    bool shoot = false;
   
    public bool h_IsRight = true;
    private  enum MovementState { idle, shoot, attack,run,hit,fall}

   
    private void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();

        controls.Land.Shoot.performed += ctx => 
        {
            shoot = true;  

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
        UpdateAnimation();
        IsRotate();
            
    }
    private void UpdateAnimation()
    {
        MovementState state;
        if (PlayerMoment.dir == 0f )
        {
       
            state = MovementState.idle;
        }
        else
        {
           
                 state = MovementState.run;
        }

        if (rb.velocity.y > .1f)
        {

            state = MovementState.hit;
            
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.fall;
        }

        if (shoot == true)
        {
            state = MovementState.shoot;
            Shooting();
        }

       
        animator.SetInteger("State", (int)state);


    }
    private void IsRotate()
    {
        if(PlayerMoment.dir>0 && !h_IsRight)
        {
            Filp();
        }else if(PlayerMoment.dir<0 && h_IsRight)
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
        Waepon waepon=GetComponent<Waepon>();
        shoot = false;
        waepon.Shoot();
    }

}
