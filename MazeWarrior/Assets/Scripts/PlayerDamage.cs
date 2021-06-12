using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
  public float damageAmount = 2.0f;
  public LayerMask enemyLayer;
  public float attackRange = 0.5f;

  void Update(){
    Collider[] hits = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);
    if(hits.Length > 0){
      if(hits[0].gameObject.tag == "Enemy"){
        hits[0].gameObject.GetComponent<EnemyHealth>().ApplyDamage(damageAmount);
      }
    }

  }
}
