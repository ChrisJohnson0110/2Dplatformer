using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : PlayerManager
{
    public InputController input = null;
    PlayerEffects playerEffects;

    //components
    public Rigidbody2D body;
    public Ground ground;

    [Header("Directional Settings")]
    [SerializeField, Range(0f, 100f)] public float maxSpeed = 4f;
    //[HideInInspector] public float fSpeedModifier = 0f;

    [SerializeField, Range(0f, 100f)] private float maxAcceleration = 35f;
    [SerializeField, Range(0f, 100f)] private float maxAirAcceleration = 20f;

    [Header("Jump Settings")]
    [SerializeField, Range(0f, 100f)] private float jumpHeight = 3f;
    //[HideInInspector] public float fJumpBlessingModifier = 0f;

    [SerializeField, Range(0f, 5)] private int maxAirJumps = 0;
    [SerializeField, Range(0f, 5f)] private float downwardMovementMultiplier = 3f;
    [SerializeField, Range(0f, 5f)] private float upwardMovementMultiplier = 1.7f;

    //flags
    public bool climbing;
    public bool swimming;
    public bool onGround;

    //directional variables
    private Vector2 direction;
    private Vector2 desiredVelocity;
    private Vector2 velocity;

    private float maxSpeedChange;
    private float acceleration;

    //jump variables
    private int numberOfJumps;
    private float defaultGravityScale;

    private bool desiredJump;
    private bool onGroundJump;


    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        ground = GetComponent<Ground>();
        defaultGravityScale = 1f;
        playerEffects = gameObject.GetComponent<PlayerEffects>();
        //values
        //maxSpeed = maxSpeedStarting;
    }

    public void HandleMovement()
    {
        direction.x = input.RetrieveMoveInput();

        if (climbing == true)
        {
            Climbing();
        }
        else if (swimming == true)
        {
            Swimming();
        }
        else
        {
            Moving();
        }
    }

    public void MoveCheck()
    {
        desiredVelocity = new Vector2(direction.x, 0f) * Mathf.Max((maxSpeed + playerEffects.speedModifierEndValue) - ground.GetFriction(), 0f);

        onGroundJump = ground.GetOnGround();
        velocity = body.velocity;

        acceleration = onGroundJump ? maxAcceleration : maxAirAcceleration;
        maxSpeedChange = acceleration * Time.deltaTime;
        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);

        body.velocity = velocity;
    }

    //check for jump action possible
    public void JumpCheck()
    {
        desiredJump |= input.RetrieveJumpInput();

        onGroundJump = ground.GetOnGround();
        velocity = body.velocity;

        //if touching ground this jump is first jump
        if (onGroundJump)
        {
            numberOfJumps = 0;
        }

        //if jump button pressed
        if (desiredJump)
        {
            desiredJump = false;
            JumpAction();
        }

        if (body.velocity.y > 0)
        {
            body.gravityScale = upwardMovementMultiplier;
        }
        else if (body.velocity.y < 0)
        {
            body.gravityScale = downwardMovementMultiplier;
        }
        else if (body.velocity.y == 0)
        {
            body.gravityScale = defaultGravityScale;
        }

        body.velocity = velocity;
    }

    //execute jump
    private void JumpAction()
    {
        if (onGroundJump || numberOfJumps < maxAirJumps)
        {
            numberOfJumps += 1;
            velocity.y = 0;

            float jumpSpeed = Mathf.Sqrt(-2f * Physics2D.gravity.y * (jumpHeight + playerEffects.jumpModifierEndValue));
            if (velocity.y > 0f)
            {
                jumpSpeed = Mathf.Max(jumpSpeed - velocity.y, 0f);
            }

            velocity.y += jumpSpeed;
        }
    }

    /// <summary>
    /// movement control for climbing
    /// </summary>
    void Climbing()
    {
        //freeze ridgidbody
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;

        //need to only move if not touching another obj than ladder

        if (gameObject.GetComponent<Rigidbody2D>().IsTouchingLayers(6) == false)
        {
            //movement on ladder
            transform.position += new Vector3((input.RetrieveMoveInput() * 0.005f),
                (input.RetrieveVerticalInput() * 0.005f),
                0);
        }

        //if jump // cancel climb
        if (input.RetrieveJumpInput() == true)
        {
            climbing = false;

            numberOfJumps = 0;
            JumpAction();
            
        }
    }

    /// <summary>
    /// movement control for normal above ground movement
    /// </summary>
    void Moving()
    {
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

        MoveCheck();
        JumpCheck();
    }



    /// <summary>
    /// movement control for swimming
    /// </summary>
    void Swimming()
    {
        Debug.Log("swimming");
    }
}
