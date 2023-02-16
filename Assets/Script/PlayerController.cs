using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] [Range(0, 10)] int speed = 5;
    [SerializeField] [Range(0, 10)] float Jump = 5;
    [SerializeField] Rigidbody2D Body;
    [SerializeField] LayerMask GroundMask;




    // Start is called before the first frame update
    void Start()
    {

        Body = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        Vector2 PlayerMovement = Vector2.right * xMove * speed;
        PlayerMovement.y = Body.velocity.y;
        if (Input.GetButtonDown("Jump") && Physics2D.Raycast(transform.position, -transform.up, 1.2f, GroundMask))
        {
            PlayerMovement.y += Mathf.Sqrt(Jump * -2f * (-9.81f));
        }
        Debug.DrawRay(transform.position, -transform.up * 1.2f, Color.red);
        







        Body.velocity = PlayerMovement;
        

    }
}
