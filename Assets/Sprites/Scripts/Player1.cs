using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player1 : MonoBehaviour
{
    private enum State
    {
        IDLE,
        WALK,
        JUMP
    }

    [SerializeField] Animator Playeranim_;
    [SerializeField] Rigidbody2D Bodyplayer_;
    [SerializeField] SpriteRenderer Playersprite_;
    private const float MoveSpeed_ = 1.0f;
    private const float Deadzone_ = 0.1f;
    private const float Jumpspeed_ = 5.0f;
    private const int Jumpcountmax_ = 1;
    private int Jumpcountcurrent_ = 0;
    private State Currentstate_;
    private bool Facingright_ = false;
    // Start is called before the first frame update
    void Start()
    {
        Bodyplayer_ = GetComponent<Rigidbody2D>();
        Playeranim_ = GetComponent<Animator>();
        Currentstate_ = State.IDLE;
    }

    private void Update()
    {
        if (Input.GetButtonDown("JUMP"))
        {
            if (Jumpcountcurrent_ >0)
            {
                Jump();
            }
        }    
    }

    private void FixedUpdate()
    {
        Bodyplayer_.velocity = new Vector2(Input.GetAxis("Horizontal") * MoveSpeed_, Bodyplayer_.velocity.y);
        if(Input.GetAxis("Horizontal") > Deadzone_ && Facingright_)
        {
            Flip();
        }
        if(Input.GetAxis("Horizontal") < -Deadzone_ && !Facingright_)
        {
            Flip();
        }

        switch (Currentstate_)
        {
            case State.IDLE:
                if(Mathf.Abs(Input.GetAxis("Horizontal")) > Deadzone_)
                {
                    ChangeState(State.WALK);
                }
                if (Input.GetButtonDown("JUMP"))
                {
                    ChangeState(State.JUMP);
                }
                break;
            case State.WALK:
                if(Input.GetAxis("Horizontal") > -Deadzone_ && Input.GetAxis("Horizontal") < Deadzone_)
                {
                    ChangeState(State.IDLE);
                }
                break;
            case State.JUMP:
                if (Input.GetAxis("Horizontal") > -Deadzone_ && Input.GetAxis("Horizontal") < Deadzone_)
                {
                    ChangeState(State.IDLE);
                }
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void Jump()
    {
        Jumpcountcurrent_--;
        Bodyplayer_.velocity = new Vector2(Bodyplayer_.velocity.x, Jumpspeed_);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Jumpcountcurrent_ = Jumpcountmax_;
    }

    private void Flip()
    {
        Playersprite_.flipX = !Playersprite_.flipX;
        Facingright_ = !Facingright_;
    }

    void ChangeState(State state)
    {
        switch (state)
        {
            case State.IDLE:
                Playeranim_.Play("Idle");
                break;
            case State.WALK:
                Playeranim_.Play("Walk");
                break;
            case State.JUMP:
                Playeranim_.Play("Jump");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
        Currentstate_ = state;
    }
}
