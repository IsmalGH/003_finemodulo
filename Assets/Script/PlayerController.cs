using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] [Range(0, 10)] int speed = 5;
    [SerializeField] [Range(0, 30)] float Jump = 5;
    [SerializeField] [Range(0, 1)] float AirTime = 1f;
    [SerializeField] Rigidbody2D Body;
    [SerializeField] LayerMask GroundMask;
    [SerializeField] Transform GroundTouch;
    bool isGrounded,isJumping;
    float AirTimeCounter,Y;




    // Start is called before the first frame update
    void Start()
    {

        Body = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        Vector2 PlayerMovement = new Vector2(xMove * speed, Body.velocity.y);
        isGrounded = Physics2D.OverlapBox(GroundTouch.position, new Vector2(0.98f, 0.1f),0, GroundMask);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Y = Mathf.Sqrt(Jump * 2f * 9.8f);
            AirTimeCounter = AirTime;
            PlayerMovement.y = Y;
            isJumping = true;
        }
        if (Input.GetButton("Jump") && AirTimeCounter > 0 && isJumping)
        {
            PlayerMovement.y = Y;
            AirTimeCounter -= Time.deltaTime;
        }
        else
            isJumping = false;
        if (Input.GetButtonUp("Jump"))
            isJumping = false;



        Body.velocity = PlayerMovement;
        

    }
}
