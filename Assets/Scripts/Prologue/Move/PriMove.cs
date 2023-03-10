using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriMove : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    [SerializeField] public float maxSpeed = 3f;
    bool isLookingleft = false;
    public bool CanWalk = false;
    public bool isWalking =false;
    public bool isShaking= false;
    public static PriMove instance;
    public Animator animator;
    void Start() 
    {
        instance = this;
    }

    void Update()
    {
        float k = rigidbody2D.velocity.x;
            float h = Input.GetAxisRaw("Horizontal");  
            if(isShaking)
            {
                animator.CrossFade("Shaking",0);
            }

            if(isWalking)
            {
                print("isWalking");
                animator.CrossFade("PriWalk",0);
            }

            if(k==0 && !isShaking)
            {
                animator.CrossFade("PriIdle",0);
            }
            else
            {
                if(CanWalk) animator.CrossFade("PriWalk",0);
            }
            if(CanWalk) lookingLeftOrRight(h);
            if(CanWalk) rigidbody2D.AddForce(new Vector2(h*50,0), ForceMode2D.Impulse);
            if(rigidbody2D.velocity.x > maxSpeed)
            {
                rigidbody2D.velocity = new Vector2(maxSpeed, rigidbody2D.velocity.y);
            }
            else if(rigidbody2D.velocity.x < -maxSpeed)
            {
                rigidbody2D.velocity = new Vector2(-maxSpeed, rigidbody2D.velocity.y);
            }
    }

    void lookingLeftOrRight(float dir)
    {
        if(dir == -1)
        {
            isLookingleft = true;
            transform.localScale = new Vector3(-1, 1, 1);

        }
        else if(dir == 1)
        {
            isLookingleft = false;
           transform.localScale = new Vector3(1, 1, 1); 

        }
    }
}
