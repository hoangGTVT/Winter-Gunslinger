using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerAnimation;

public class PlayerMoment : FindObject
{
    PlayerControls controls;
    protected static float  dir = 0;
    public static float Dir { get { return dir; } }
    public PlayerLife playerLife;

    protected static float moveSpeed = 5f;
    protected static float JumForce = 10f;
    [SerializeField] private int numberOfJump = 0;
   
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] public bool h_IsFly = false;
    
    
    private void Awake()
    {
        controls= new PlayerControls();
        controls.Enable();
        controls.Land.Move.performed += ctx =>
        {
            dir = ctx.ReadValue<float>();
           
        };
        controls.Land.Jump.performed += ctx => {
            GameObject gameObject= base.FindObjectWithTag("Player01");
            if (gameObject != null) { Jump(); }
        }; 
        controls.Land.Fly.performed += ctx => {
            GameObject gameObject = base.FindObjectWithTag("Player01");
            if (gameObject != null) { Fly(); ; }
        }; 
            
        




    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
       
        IsFly();    

    }
    private void FixedUpdate()
    {
        PlayerMove();
    }

    public void PlayerMove()
    {
        PlayerAnimation.rb.velocity = new Vector2(PlayerMoment.Dir * PlayerMoment.moveSpeed, PlayerAnimation.rb.velocity.y);
    }
    

    
    
    public bool IsGrounded()
    {
        return Physics2D.BoxCast(PlayerAnimation.coll.bounds.center, PlayerAnimation.coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
    public void Jump()
    {
        if (IsGrounded() )
        {
            numberOfJump = 0;
            PlayerAnimation.rb.velocity = new Vector2(PlayerAnimation.rb.velocity.x, JumForce);
            numberOfJump++;
            AudioManager.instance.Play("Jump");
           
        }
        else if (numberOfJump == 1)
        {
            PlayerAnimation.rb.velocity = new Vector2(PlayerAnimation.rb.velocity.x, JumForce);
            numberOfJump++;
          
        }
    }

    
     public void IsFly()
    {
        if (IsGrounded() )
        {
            h_IsFly = false;
        }
    }
    public void Fly()
    {
        if (playerLife.GetEnergy() > 0)
        {
            PlayerAnimation.rb.AddForce(Vector3.up * 4, ForceMode2D.Impulse);
            h_IsFly = true;
            playerLife.GetEnergy1();
        }
        else
        {
            return;
        }
       
      
    }

    

    
    

    
}
