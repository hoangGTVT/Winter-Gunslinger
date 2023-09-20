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
    public  enum MovementState { idle, shoot, attack,run,hit,fall}
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
        if (Input.GetKeyDown(KeyCode.K)){
            MovementState state;

            state = MovementState.shoot;

            animator.SetInteger("State", (int)state);
        }
    }
    private void UpdateAnimation()
    {
        MovementState state;
        if (PlayerMoment.dir > 0f)
        {
            state = MovementState.run;
            PlayerAnimation.sp.flipX = false;
           
        }
        else if (PlayerMoment.dir < 0f)
        {
            PlayerAnimation.sp.flipX = true;
            state = MovementState.run;
        }
        else
        {
            state = MovementState.idle;
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
            shoot = false;
        }
        animator.SetInteger("State", (int)state);


    }
   
}
