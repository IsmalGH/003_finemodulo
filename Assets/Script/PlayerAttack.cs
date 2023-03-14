using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] float Range, Damage;
    [SerializeField] LayerMask AttackLayer;
    [SerializeField] GameObject AttackPos;
    [SerializeField] GameObject Messaggio;
    public bool haveSword = false;
    private RaycastHit2D[] hits;
    private float AnimTimer,textTimer;
    bool isAttacking=false;

    // Start is called before the first frame update
    void Start()
    {
        AnimTimer = 0;
        AttackPos.transform.SetParent(transform);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.RightArrow))
            AttackPos.transform.localPosition = new Vector2(1, 0);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            AttackPos.transform.localPosition = new Vector2(-1, 0);
        if (Input.GetKeyDown(KeyCode.UpArrow))
            AttackPos.transform.localPosition = new Vector2(0, 1);
        if (Input.GetKeyDown(KeyCode.DownArrow))
            AttackPos.transform.localPosition = new Vector2(0, -1);


        if (haveSword && Input.GetKeyDown(KeyCode.X))
        {
            Attack();
            AttackPos.SetActive(true);
            isAttacking = true;
        }
        if(isAttacking)
        {
            if(AnimTimer <= 0.1f)
                AnimTimer += Time.deltaTime;
            else
            {
                isAttacking = false;
                AttackPos.SetActive(false);
                AnimTimer = 0;
            }

        }

        if (haveSword && textTimer <= 3f)
        {
            Messaggio.SetActive(true);
            textTimer += Time.deltaTime;
        }
        else if (textTimer >= 3f)
            Messaggio.SetActive(false);

            

    }

    void Attack()
    {

        hits = Physics2D.CircleCastAll(AttackPos.transform.position, Range, transform.right, 0, AttackLayer);

        for (int i=0; i< hits.Length; i++)
        {
            EnemyHealth Life = hits[i].collider.gameObject.GetComponent<EnemyHealth>();
            Life.CurrentHealt -= Damage;
        }
        
    }
}
