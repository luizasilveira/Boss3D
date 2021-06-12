using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100.0f;
    private Enemy enemyScript;
    private Animator anim;
    private AudioSource m_AudioSource;
    [SerializeField] private AudioClip  enemyDeadSound;

    void Awake()
    {
        enemyScript = GetComponent<Enemy>();
        anim = GetComponent<Animator>();
        m_AudioSource = GetComponent<AudioSource>();
    }

    public void ApplyDamage(float damage){
      health -= damage;
      if(health < 0){
        health = 0;
      }
      if(health == 0){
        enemyScript.enabled = false;
        m_AudioSource.clip = enemyDeadSound;
        m_AudioSource.Play();
        anim.SetTrigger("Dead");
        Invoke("DeactivateEnemy",2f);
      }
    }

    void DeactivateEnemy(){
        gameObject.SetActive(false);
    }

}
