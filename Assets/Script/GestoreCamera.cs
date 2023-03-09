using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestoreCamera : MonoBehaviour
{
    [SerializeField] public GameObject Camera;
    [SerializeField] public bool state;
    [SerializeField] PlayerController Player;
    [SerializeField] Transform Spawn1,Spawn2;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
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
                Player.transform.position = Spawn1.position;
            else
                Player.transform.position = Spawn2.position;
            state = !state;
            if (timer < 0.5f)
            {
                timer += Time.deltaTime;
                Player.Body.velocity = Vector2.zero;
            }
            else
                timer = 0;
            
        }

    }
}
