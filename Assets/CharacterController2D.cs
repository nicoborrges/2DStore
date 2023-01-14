using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    Rigidbody2D bodyrigid;
    [SerializeField] float speed = 2f;
    Vector2 motionVector; 
    public Vector2 lastMotionVector;
    Animator animator;
    void Awake()
    {
        bodyrigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Vertical");
        float vertical = Input.GetAxisRaw("Horizontal");

        motionVector = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
            );
        animator.SetFloat("Vertical", horizontal);
        animator.SetFloat("Horizontal", vertical);

        if(horizontal != 0 || vertical != 0)
        {
            lastMotionVector = new Vector2(
                horizontal,
                vertical
                ).normalized;

            animator.SetFloat("lastHorizontal", horizontal);
            animator.SetFloat("lastVertical", vertical);
        }
    }
    private void Move()
    {
        bodyrigid.velocity = motionVector * speed;
    }
    void FixedUpdate()
    {
        Move();
    }
}
