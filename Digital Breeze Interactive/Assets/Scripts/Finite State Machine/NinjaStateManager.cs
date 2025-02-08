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

    private bool onChangeState;
    public bool isDead;

    private bool isTouchscreenInput = false;

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
        currentNinjaState.EnterState();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) return;
        if (!isTouchscreenInput)
        {
            HandleMovePlayer();
        }
        CheckGroundStatus();
        HandleFlip();
        HandleJump();
        HandleAttack();
        if (onChangeState) return;
        currentNinjaState.UpdateState();
    }

    private void FixedUpdate()
    {
        if (onChangeState) return;
        currentNinjaState.FixedUpdateState();
    }

    public void SelectState(NinjaState _selectState)
    {
        onChangeState = true;
        currentNinjaState.ExitState();
        currentNinjaState = _selectState;
        currentNinjaState.EnterState();
        onChangeState = false;
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
        if (Input.GetMouseButtonDown(1) && isGrounded && horizontal == 0)
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

    public void TouchscreenMoveHandleDown(int moveX)
    {
        isTouchscreenInput = true;
        horizontal = moveX;
    }

    public void TouchscreenMoveHandleUp()
    {
        isTouchscreenInput = false;
        horizontal = 0;
    }

    public void TouchscreenJumpHandle()
    {
        if (isGrounded)
        {
            SelectState(jumpState);
        }
    }

    public void TouchscreenAttackHandle()
    {
        SelectState(attackState);
    }
}
