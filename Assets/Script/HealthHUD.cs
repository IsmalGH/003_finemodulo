using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthHUD : MonoBehaviour
{
    [SerializeField] PlayerController Controller;
    [SerializeField] Image Heart1, Heart2, Heart3;
    float timer=0;
    bool allRed=true;



    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        switch (Controller.ActualLife)
        {
            case 3:
                if (timer < 0.1f && !allRed)
                    timer += Time.deltaTime;
                else
                {
                    timer = 0;
                    Heart3.color = Color.red;
                    Heart2.color = Color.red;
                    Heart1.color = Color.red;
                    allRed = true;
                }
                break;
            case 2:
                Heart3.color = Color.white;
                break;
            case 1:
                Heart2.color = Color.white;
                break;
            case 0:
                Heart1.color = Color.white;
                allRed = false;
                break;
        }
    }
}
