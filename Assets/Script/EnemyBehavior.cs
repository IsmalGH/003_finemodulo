using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D Body;
    [SerializeField] Transform forward;
    [SerializeField] LayerMask GroundMask;
    int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        Body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 Movement = direction * speed * transform.right;
        if (Physics2D.OverlapCircle(forward.position, 0.05f, GroundMask))
        {
            direction = direction * -1;
        }
        Body.velocity = Movement;
    }
}
