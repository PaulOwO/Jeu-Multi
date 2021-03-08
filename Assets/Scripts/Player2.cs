using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    [SerializeField] Rigidbody2D Bodyplayer_;
    private const float MoveSpeed_ = 1.0f;
    private const float Deadzone_ = 0.1f;
    private const float Jumpspeed_ = 2.0f;
    private const int Jumpcountmax_ = 1;
    private int Jumpcountcurrent_ = 0;
    void Start()
    {
        Bodyplayer_ = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("JUMP2"))
        {
            if (Jumpcountcurrent_ > 0)
            {
                Jump();
            }
        }
    }

    private void FixedUpdate()
    {
        Bodyplayer_.velocity = new Vector2(Input.GetAxis("Vertical") * MoveSpeed_, Bodyplayer_.velocity.y);
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
}
