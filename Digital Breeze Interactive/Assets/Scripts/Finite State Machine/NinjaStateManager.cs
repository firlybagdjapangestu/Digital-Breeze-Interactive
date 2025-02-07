using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaStateManager : MonoBehaviour
{
    public int hp;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public Rigidbody2D rb;
    public bool isGrounded;
    public float horizontal;
    public bool facingRight = true;

    public Animator animator;

    public NinjaState currentNinjaState;
    public IdleState idleState;
    public RunState runState;
    public JumpState jumpState;
    public AttackState attackState;
    public HurtState hurtState;
    public DieState dieState;

    // Start is called before the first frame update
    void Start()
    {
        idleState.InitializedComponent(this);
        runState.InitializedComponent(this);
        jumpState.InitializedComponent(this);
        attackState.InitializedComponent(this);
        hurtState.InitializedComponent(this);
        dieState.InitializedComponent(this);

        currentNinjaState = idleState;
        currentNinjaState.OnEnableState();
    }

    // Update is called once per frame
    void Update()
    {     
        HandleMovePlayer();
        CheckGroundStatus();
        HandleFlip();
        HandleJump();
        HandleAttack();
        currentNinjaState.UpdateState();
    }


    private void FixedUpdate()
    {
        currentNinjaState.FixedUpdateState();
    }

    public void SelectState(NinjaState _selectState)
    {
        currentNinjaState = _selectState;
        currentNinjaState.OnEnableState();
    }

    void HandleMovePlayer()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
    }


    void CheckGroundStatus()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            SelectState(jumpState);
        }
    }

    void HandleAttack()
    {
        if (Input.GetMouseButtonDown(0) && isGrounded && currentNinjaState != jumpState)
        {
            SelectState(attackState);
        }
    }

    void HandleFlip()
    {
        if ((horizontal > 0 && !facingRight) || (horizontal < 0 && facingRight))
        {
            facingRight = !facingRight;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            SelectState(hurtState);
            hurtState.OnTriggerEnter2DState(collision);
        }
    }
}
