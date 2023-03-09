using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEvent : MonoBehaviour
{
    [SerializeField] EnemyHealth Health;
    [SerializeField] GameObject Porta1, Porta2;

    // Start is called before the first frame update
    void Start()
    {
        Health = gameObject.GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Health.CurrentHealt<=0)
        {
            Porta1.SetActive(true);
            Porta2.SetActive(false);
        }
    }
}
