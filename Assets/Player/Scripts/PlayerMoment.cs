using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerAnimation;

public class PlayerMoment : MonoBehaviour
{
    PlayerControls controls;
    protected static float  dir = 0;
    public static float Dir { get { return dir; } }


    protected static float moveSpeed = 5f;
    protected static float JumForce = 10f;
    private int numberOfJump = 0;
    [SerializeField] private LayerMask jumpableGround;
    private void Awake()
    {
        controls= new PlayerControls();
        controls.Enable();
        controls.Land.Move.performed += ctx =>
        {
            dir = ctx.ReadValue<float>();
           
        };
        controls.Land.Jump.performed += ctx => Jump();
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
        
    }
    private void FixedUpdate()
    {
         PlayerAnimation.rb.velocity = new Vector2(PlayerMoment.Dir * PlayerMoment.moveSpeed, PlayerAnimation.rb.velocity.y);
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(PlayerAnimation.coll.bounds.center, PlayerAnimation.coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
    public void Jump()
    {
        if (IsGrounded())
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
            AudioManager.instance.Play("Jump");
        }
    }

    
}
