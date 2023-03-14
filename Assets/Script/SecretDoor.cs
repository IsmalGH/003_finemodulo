using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretDoor : MonoBehaviour
{
    [SerializeField] GameObject Porta;
    private bool ActiveInteraction=false;
    private SpriteRenderer Colore;
    private BoxCollider2D collisore;
    // Start is called before the first frame update
    void Start()
    {
        Colore = Porta.GetComponent<SpriteRenderer>();
        collisore = Porta.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ActiveInteraction && Input.GetKeyDown(KeyCode.UpArrow))
        {
            Colore.color = Color.gray;
            collisore.enabled = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            ActiveInteraction = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            ActiveInteraction = false;
    }
}
