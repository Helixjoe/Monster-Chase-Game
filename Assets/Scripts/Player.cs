using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    private float movementX;
    [SerializeField]
    private SpriteRenderer sr;
    private Animator anim;
    private string WALK_ANIMATION = "Walk";
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        WalkAnimation();
    }

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
}
