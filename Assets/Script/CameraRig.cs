using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRig : MonoBehaviour
{

    [SerializeField] Transform player;
    [SerializeField] float t;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position= Vector2.Lerp(transform.position, player.position, t * Time.deltaTime);
            

    }
}
