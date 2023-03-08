using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{

    [SerializeField] PlayerAttack Attack;
    [SerializeField] PlayerController Controller;
    [SerializeField] GameObject Porta1, porta2;
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
            Attack.haveSword = true;
            gameObject.SetActive(false);
            Porta1.SetActive(true);
            porta2.SetActive(false);
            Controller.actualSpawn = transform;
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
