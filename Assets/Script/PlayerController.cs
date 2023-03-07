using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] [Range(0, 10)] int speed = 5;
    [SerializeField] [Range(0, 30)] float Jump = 5;
    [SerializeField] [Range(0, 1)] float AirTime = 1f;
    [SerializeField] Rigidbody2D Body;
    [SerializeField] LayerMask GroundMask,EnemyMask;
    [SerializeField] Transform GroundTouch,actualSpawn, temporarySpawn;
    [SerializeField] public int Life,ActualLife,InvulnerabilityTime;
    GameObject Spawn;
    bool isGrounded,isJumping,isInvulnerable;
    float AirTimeCounter,Y,timer=0;




    // Start is called before the first frame update
    void Start()
    {
        Spawn = GameObject.Find("FirstSpawn");
        Body = GetComponent<Rigidbody2D>();
        actualSpawn = Spawn.transform;
        ActualLife = Life;
        isInvulnerable = false;
    }

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        Vector2 PlayerMovement = new Vector2(xMove * speed, Body.velocity.y);
        isGrounded = Physics2D.OverlapBox(GroundTouch.position, new Vector2(0.98f, 0.1f),0, GroundMask);

        //Gestione del jump dinamico
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

        //Controllo Morte
        if (ActualLife == 0)
        {
            ActualLife = Life;
            transform.position = actualSpawn.position;
        }

        //Controllo invulnerabilità
        if (isInvulnerable && timer < InvulnerabilityTime)
        {
            timer += Time.deltaTime;
            if (timer >= InvulnerabilityTime)
            {
                isInvulnerable = false;
                timer = 0;
            }
                
        }
            
        //Assegnazione velocità
        Body.velocity = PlayerMovement;
        

    }
 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Enemy") && !isInvulnerable)
        {
            ActualLife--;
            Debug.Log("Contatto");
            isInvulnerable = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Enemy") && !isInvulnerable)
        {
            ActualLife--;
            Debug.Log("Contatto");
            isInvulnerable = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TempSpawn"))
        {
            temporarySpawn = collision.transform;
        }
        if (collision.CompareTag("Spike"))
        {
            ActualLife--;
            transform.position = temporarySpawn.position;
        }
    }

}
