using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float Health;
    public float CurrentHealt;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealt = Health;

    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHealt <= 0)
            Destroy(this.gameObject);
    }
}
