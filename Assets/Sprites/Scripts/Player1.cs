using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private const float Jumpspeed_ = 2.0f;
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
}
