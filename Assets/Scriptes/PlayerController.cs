using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed = 10f;
    public float jumpForce = 700f;
    bool facingRight = true;
    bool grounded = false;
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public Rigidbody2D rigidbody2D;
    public float move;
    bool inAir;
    [SerializeField]private GameObject woodByBack;
    // Use this for initialization
    void Start()
    {
        rigidbody2D=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        move = Input.GetAxis("Horizontal");
    }

    void Update()
    {
        if(MainScript.isPicked == true)
        {
            woodByBack.SetActive(true);
        }
        else
        {
            woodByBack.SetActive(false);
        }
        if (Input.GetKey(KeyCode.Space) && !inAir)
        {
            inAir = true;
            rigidbody2D.AddForce(new Vector2(0 , 600));
        }
        rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Water"))
            inAir = false;
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}