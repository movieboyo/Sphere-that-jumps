using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackTime;
    public float startTimeAttack;

    public Transform attackLocation;
    public float attackRange;
    public LayerMask Enemy;

   
    void Update()
    {
        if( attackTime <= 0 && Input.GetKey(KeyCode.Mouse0))
        {
            
              
                Collider2D[] damage = Physics2D.OverlapCircleAll( attackLocation.position, attackRange, Enemy );

                for (int i = 0; i < damage.Length; i++)
                {
                    Destroy( damage[i].gameObject );
                }
            
            attackTime = startTimeAttack;
            
        }  
        
         else
        {
            attackTime -= Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackLocation.position, attackRange);
    }
}
