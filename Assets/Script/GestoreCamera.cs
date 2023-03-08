using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestoreCamera : MonoBehaviour
{
    [SerializeField] public GameObject Camera;
    [SerializeField] public bool state;
    [SerializeField] Transform Player,Spawn1,Spawn2;

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
            Camera.SetActive(state); 
            if (!state)
                Player.position = Spawn1.position;
            else
                Player.position = Spawn2.position;
            state = !state;
        }

    }
}
