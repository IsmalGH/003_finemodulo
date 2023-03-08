using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCam2 : MonoBehaviour
{
    [SerializeField] GameObject Camera;
    [SerializeField] PlayerController Controller;
    [SerializeField] GestoreCamera Gestore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            Camera.SetActive(true);
            Controller.actualSpawn = transform;
            Gestore.state = false;
        }


    }

}
