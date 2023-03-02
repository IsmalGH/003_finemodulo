using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D Body;
    [SerializeField] Transform forward,back;
    [SerializeField] LayerMask GroundMask;
    int direction = 1;
    bool GoingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        Body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 Movement = direction * speed * transform.right;
        if (Physics2D.OverlapCircle(forward.position, 0.05f,GroundMask) && GoingRight)
        {
            direction = direction * -1;
            GoingRight = false;
        }
        if (Physics2D.OverlapCircle(back.position, 0.05f,GroundMask) && !GoingRight)
        {
            direction = direction * -1;
            GoingRight = true;
        }
        Body.velocity = Movement;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(forward.position, 0.02f);
    }
}
