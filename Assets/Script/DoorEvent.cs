using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEvent : MonoBehaviour
{
    [SerializeField] GameObject Porta1, Porta2,Nemico;
    [SerializeField] PlayerController Player;
    private EnemyHealth Health;
    // Start is called before the first frame update
    void Start()
    {
        Health = Nemico.GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Health.CurrentHealt<=0)
        {
            Porta1.SetActive(true);
            Porta2.SetActive(false);
            Player.actualSpawn = transform;
        }
    }
}
