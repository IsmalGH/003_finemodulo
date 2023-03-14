using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] [Range(0, 30)] float Jump = 5, DashForce, speed;
    [SerializeField] [Range(0, 1)] float DashLenght = 0.13f;
    [SerializeField] [Range(0, 1)] float AirTime = 1f;
    [SerializeField] public Rigidbody2D Body;
    [SerializeField] LayerMask GroundMask;
    [SerializeField] public Transform GroundTouch, actualSpawn, temporarySpawn;
    [SerializeField] public int Life, ActualLife, InvulnerabilityTime, DashLimit;
    [SerializeField] GameObject Messaggio;
    GameObject Spawn;
    bool isGrounded, isJumping, isInvulnerable,isDashing;
    public bool haveDash;
    int DashCounter,direction;
    float AirTimeCounter, Y, timer = 0,td=0,textTimer;

    // Start is called before the first frame update
    void Start()
    {
        Spawn = GameObject.Find("FirstSpawn");
        Body = GetComponent<Rigidbody2D>();
        actualSpawn = Spawn.transform;
        ActualLife = Life;
        isInvulnerable = false;
        isDashing = false;
        direction = 1;
    }

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        Vector2 PlayerMovement = new Vector2(xMove * speed, Body.velocity.y);
        isGrounded = Physics2D.OverlapBox(GroundTouch.position, new Vector2(0.98f, 0.1f), 0, GroundMask);

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

        if (xMove < 0)
            direction = -1;
        else if(xMove>0)
            direction = 1;

        if (isGrounded)
        {
            DashCounter = DashLimit;
        }



        if (Input.GetKeyDown(KeyCode.C) && DashCounter >0 && haveDash)
        {
            Body.velocity = new Vector2(Body.velocity.x, 0f);
            Body.AddForce(new Vector2(direction * DashForce * 5, 0f), ForceMode2D.Impulse);
            isDashing = true;
            DashCounter--;
        }


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


        //Assegnazione velocità e Gestione del tempo di dash
        if (!isDashing)
            Body.velocity = PlayerMovement;
        else if (td <= DashLenght)
        {
            Body.gravityScale = 0;
            td += Time.deltaTime;
        }
        else
        {
            Body.gravityScale = 6;
            isDashing = false;
            td = 0;
            DashCounter = 0;
        }
        
        
        if (haveDash && textTimer <= 3f)
        {
            Messaggio.SetActive(true);
            textTimer += Time.deltaTime;
        }
        else if (textTimer >= 3f)
            Messaggio.SetActive(false);


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
