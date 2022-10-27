using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caracter2 : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;

    private float movementX;

    private Rigidbody2D myBody;

    private SpriteRenderer sr;
    private Animator anim;
    private string WALK_ANIMATION = "Walk";
    
    private int isGrounded = 2;
    private string GROUND_TAG = "Ground";
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

    }

    //public float maxVelocity = 22f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();
    }
    private void FixedUpdate()
    {

    }

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;

    }
    void AnimatePlayer()
    {
        if(isGrounded == 2)
        {
            anim.SetBool("OnGround", true);
        }

     
        if (myBody.velocity.y > 0f)
        {
            anim.SetBool("IsJumping", true);
        }
        else if (myBody.velocity.y < 0f)
        {
            anim.SetBool("isFalling", true);
        }
        else
        {
            anim.SetBool("IsJumping", false);
            anim.SetBool("isFalling", false);
        }
        if (movementX > 0)
        {
            sr.flipX = false;
        }
        else if (movementX < 0)
        {
            sr.flipX = true;
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
        if (isGrounded == 2)
        {
            if (movementX != 0)
            {
                anim.SetBool(WALK_ANIMATION, true);
            }
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }
    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded > 0)
        {
            myBody.velocity = Vector2.zero;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isGrounded--;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = 2;
        }
    }
}
