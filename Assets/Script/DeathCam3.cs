using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCam3 : MonoBehaviour
{
    [SerializeField] GameObject Camera,Camera2;
    [SerializeField] PlayerController Controller;

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
            Camera2.SetActive(false);
        }



    }
}
