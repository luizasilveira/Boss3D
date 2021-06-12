using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    public float damageAmount = 0.5f;
    public float attackRange = 0.5f;
    public LayerMask playerLayer;

    void Update(){
      Collider[] hits = Physics.OverlapSphere(transform.position, attackRange, playerLayer);
      if(hits.Length > 0){
        if(hits[0].gameObject.tag == "Player"){
          hits[0].gameObject.GetComponent<PlayerHealth>().ApplyDamage(damageAmount);
        }
      }
    }
}
