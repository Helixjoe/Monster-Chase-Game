using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;
    private float movementX;
    [SerializeField]
    private SpriteRenderer sr;
    private Animator anim;
    private Rigidbody2D myBody;
    private string WALK_ANIMATION = "Walk";
    private string JUMP_ANIMATION = "Jump";
    private string GROUND_TAG = "Ground";
    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        WalkAnimation();
         PlayerJump();
    }

    // private void FixedUpdate(){
       
    // }
    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX,0f,0f) * Time.deltaTime * moveForce;
    }

    void WalkAnimation(){
        //moves right
        if(movementX > 0){
            anim.SetBool(WALK_ANIMATION,true);
            sr.flipX = false;
        }
        //moves left
        else if(movementX < 0){
            anim.SetBool(WALK_ANIMATION,true);
              sr.flipX = true;
        }
        else{
            anim.SetBool(WALK_ANIMATION,false);
            sr.flipX = false;
        }
    }

    void PlayerJump(){
        if(Input.GetButtonDown("Jump") && isGrounded){
            myBody.AddForce(new Vector2(0f,jumpForce),ForceMode2D.Impulse);
            isGrounded = false;
            anim.SetBool(JUMP_ANIMATION,true);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(GROUND_TAG))
        {
           isGrounded = true;
           anim.SetBool(JUMP_ANIMATION,false);
        }
    }
}
