using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	private GameObject player;
	private Animator anim;
	private Rigidbody rig;
	public GameObject damagePoint;
	private PlayerHealth playerHealth;
	private float moveSpeed = 10f;
	private float enemy_watch_treshold = 40f;
	private float enemy_Attack_treshold = 6f;

	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");
		rig = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator>();
	}

  void FixedUpdate(){
		EnemyMovement();
  }

  void EnemyMovement(){
    Vector3 direction = player.transform.position - transform.position;
    float distance = direction.magnitude;
    direction.Normalize();
    Vector3 velocity = direction * moveSpeed;

		if (rig != null)
		{
	    if(distance > enemy_Attack_treshold && distance < enemy_watch_treshold){

	      rig.velocity = new Vector3(velocity.x, rig.velocity.y, velocity.z);
				if(anim.GetCurrentAnimatorStateInfo(0).IsName("Attack")){
					anim.SetTrigger("Stop");
				}
				anim.SetTrigger("Run");
	      transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));

	    }else if(distance < enemy_Attack_treshold){
				if(anim.GetCurrentAnimatorStateInfo(0).IsName("Run")){
					anim.SetTrigger("Stop");
				}
				anim.SetTrigger("Attack");
	      transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));

	    }else{
	      rig.velocity = new Vector3(0f,0f,0f);
				if(anim.GetCurrentAnimatorStateInfo(0).IsName("Run") || anim.GetCurrentAnimatorStateInfo(0).IsName("Attack")){
					anim.SetTrigger("Stop");
				}
	    }
		}
  }

  void ActivateDamagePoint(){
		damagePoint.SetActive(true);
  }

	void DeactivateDamagePoint(){
		damagePoint.SetActive(false);
	}

}
