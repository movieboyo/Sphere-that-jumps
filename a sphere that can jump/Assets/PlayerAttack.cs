using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public transfrom attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;

    


    void Update()
    {
        if(timeBtwAttack <= 0 )
        {
            if(Input.GetKey(MouseButton.left))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for(i = 0; i < enimiesToDamage.Lenght; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }
            }
                    startTimeBtwAttack = 0.3;
                    timeBtwAttack = startTimeBtwAttack;
    
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
        }

        void OnDrawGizmoSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPos.position, attackRange);
        }

        
    }
}
