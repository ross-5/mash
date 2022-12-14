using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Caracter2 : MonoBehaviour
{
    private Transform originalParent;

    public bool vulnerable = true;
    private bool readytoblock = true;
    private float movementX;

    private Rigidbody2D myBody;

    private SpriteRenderer sr;
    
    private Animator anim;
    private string WALK_ANIMATION = "Walk";

    private int isGrounded = 2;
    private string GROUND_TAG = "Ground";

    private float horizontalMove;
    Vector2 move;
    Vector2 value;

    public float runSpeed = 40f;

    private bool FacingRight = true;

    public int TimesJumped = 0;
    public int NumberOfJumps;

    public Transform attackPoint;
    public Transform dashPoint;

    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    //for shoot
    public Transform firePoint;
    public GameObject shuriken;
    [SerializeField]
    private GameObject FindBubble;
    [SerializeField]
    private GameObject PlayerNameText;

    private SpriteRenderer blockBubble;

    private string PlayerName;

    private void OnMove(InputValue value)
    {
        // Gets the value of the joystick and translate it into a vector 2.  
        move = value.Get<Vector2>();
    }
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        blockBubble = FindBubble.GetComponent<SpriteRenderer>();
        PlayerHandler.PlayerCount++;
        PlayerName = "P" + PlayerHandler.PlayerCount.ToString();
        gameObject.name = PlayerName;
        PlayerNameText.GetComponent<TextMeshProUGUI>().SetText(PlayerName);
        

    }

    //public float maxVelocity = 22f;
    // Start is called before the first frame update
    void Start()
    {
        blockBubble.enabled = false;
        originalParent = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        //PlayerMoveKeyboard();
        AnimatePlayer();
        
    }
    private void FixedUpdate()
    {
        if (FacingRight)
        {
            // Moves the player if facing right.
            Vector3 movement = new Vector3(move.x, 0, 0) * runSpeed * Time.deltaTime;
            transform.Translate(movement);
        }
        else
        {
            // Moves the player if facing left.
            Vector3 movement = new Vector3(-move.x, 0, 0) * runSpeed * Time.deltaTime;
            transform.Translate(movement);

        }

        horizontalMove = move.x;

        if (horizontalMove > 0 && !FacingRight)
        {
            Flip();
        }
        else if (horizontalMove < 0 && FacingRight)
        {
            Flip();
        }
    }
    private void Flip()
    {
        // Flips the player.
        FacingRight = !FacingRight;

        transform.Rotate(0, 180, 0);
    }
    void AnimatePlayer()
    {
        if (isGrounded == 2)
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

        if (move.x > 0)
        {
            //sr.flipX = false;
        }
        else if (move.x < 0)
        {
            //sr.flipX = true;
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
        if (isGrounded == 2)
        {
            if (move.x != 0)
            {
                anim.SetBool(WALK_ANIMATION, true);
            }
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }

    private void OnAttack1()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Dash") || anim.GetCurrentAnimatorStateInfo(0).IsName("Attack1") || anim.GetCurrentAnimatorStateInfo(0).IsName("Shoot") || blockBubble.enabled == true)
        {

        }
        else
        {

            anim.SetTrigger("Attacking1");


        }
    }
    private void OnBlock()
    {
        if (readytoblock == true)
        {
            blockBubble.enabled = true;
            vulnerable = false;
            StartCoroutine(BlockDelay());
        }
        
    }
    IEnumerator BlockDelay()
    {
        readytoblock = false;
        yield return new WaitForSeconds(0.35f);
        blockBubble.enabled = false;
        vulnerable = true;
        yield return new WaitForSeconds(1f);
        readytoblock= true;
    }
    public void Attack1Damage()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Health>().TakeDamage(10);
            Debug.Log("We hit" + enemy.name);
            if (FacingRight)
            {
                enemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(6f, 8f), ForceMode2D.Impulse);
            }
            else
            {
                enemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(-6f, 8f), ForceMode2D.Impulse);

            }
        }
    }

    public void DashDamage()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(dashPoint.position, attackRange*2, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
           
            enemy.GetComponent<Health>().TakeDamage(10);
            //Vector3 movementEnemy = new Vector3(400, 0, 0) * runSpeed * Time.deltaTime;
            //enemy.transform.Translate(movementEnemy);
            if (FacingRight)
            {
                enemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(4f, 8f), ForceMode2D.Impulse);
            }
            else
            {
                enemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(-4f, 8f), ForceMode2D.Impulse);

            }
            
            Debug.Log("We hit" + enemy.name);
            
        }
        Vector3 movement = new Vector3((System.Math.Abs(dashPoint.position.x - attackPoint.position.x)+.25f), 0, 0);
        transform.Translate(movement);
        sr.color = new Color(255, 255, 255, 255);
    }
    private void OnJump()
    {
        // Let the player jump and checkes how many times he jumped.
        if (TimesJumped < NumberOfJumps)
        {
            TimesJumped += 1;
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 10f), ForceMode2D.Impulse);
        }
    }
    private void OnDash()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Dash")||anim.GetCurrentAnimatorStateInfo(0).IsName("Attack1") || anim.GetCurrentAnimatorStateInfo(0).IsName("Shoot") || blockBubble.enabled == true)
        {

        }
        else
        {
            sr.color = new Color(0, 234, 255, 255);

            anim.SetTrigger("Dashing");


        }
    }
    private void OnShoot()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Dash") || anim.GetCurrentAnimatorStateInfo(0).IsName("Attack1") || anim.GetCurrentAnimatorStateInfo(0).IsName("Shoot") || blockBubble.enabled == true)
        {
        }
        else
        {
            anim.SetTrigger("Shooting");
        }
    }
    public void ShootDamage()
    {
        Instantiate(shuriken,firePoint.position, firePoint.rotation);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = 2;
            TimesJumped = 0;
        }
    }
    
    private void OnDrawGizmos()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void SetParent(Transform newParent)
    {
        originalParent = transform.parent;
        transform.parent = newParent;
    }
    public void ResetParent()
    {
        transform.parent = originalParent;
    }
}
