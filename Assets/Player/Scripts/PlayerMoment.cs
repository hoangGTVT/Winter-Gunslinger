using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerAnimation;

public class PlayerMoment : MonoBehaviour
{
    PlayerControls controls;
    public static float  dir = 0;
    
    public static float moveSpeed = 5f;
    public static float JumForce = 10f;
    private int numberOfJump = 0;
    [SerializeField] private LayerMask jumpableGround;
    private void Awake()
    {
        controls= new PlayerControls();
        controls.Enable();
        controls.Land.Move.performed += ctx =>
        {
            dir = ctx.ReadValue<float>();
            Debug.Log("A");
        };
        controls.Land.Jump.performed += ctx => Jump();
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerAnimation.rb.velocity = new Vector2(PlayerMoment.dir * PlayerMoment.moveSpeed, PlayerAnimation.rb.velocity.y);
        //Vector3 move = new Vector3(dir, 0,0);
        // transform.parent.position += move * moveSpeed * Time.deltaTime;
        
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
        }
        else if (numberOfJump == 1)
        {
            PlayerAnimation.rb.velocity = new Vector2(PlayerAnimation.rb.velocity.x, JumForce);
            numberOfJump++;
        }
    }


}
