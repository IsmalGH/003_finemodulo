using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{

    [SerializeField] PlayerController Controller;
    [SerializeField] bool ActiveInteraction = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ActiveInteraction && Input.GetKeyDown(KeyCode.UpArrow))
        {
            Controller.haveSword = true;
            Destroy(this.gameObject);
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
