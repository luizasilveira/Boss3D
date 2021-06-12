using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    private Player playerScript;
    private Animator anim;
    public Slider vidaPlayer;
    private bool killed;
    public bool Killed { get { return killed; } }
    public bool win;
    public bool Win { get { return win; } }

    private AudioSource m_AudioSource;
    [SerializeField] private AudioClip  playerDeadSound;

    void Awake()
    {
        playerScript = GetComponent<Player>();
        anim = GetComponent<Animator>();
        m_AudioSource = GetComponent<AudioSource>();
    }

    public void ApplyDamage(float damage){
      vidaPlayer.value -= damage;
      if(vidaPlayer.value < 0){
        vidaPlayer.value = 0;
        killed = true;
      }
      if(vidaPlayer.value == 0){
        playerScript.enabled = false;
        m_AudioSource.clip = playerDeadSound;
        m_AudioSource.Play();
        killed = true;
        anim.Play("Dead");
      }
      if(killed){
        	vidaPlayer.value = 100;
      }
    }

    private void OnCollisionEnter(Collision col)
    {
         if (col.gameObject.tag == "treasure")
         {
             win = true;
             Debug.Log(win);
         }
    }
}
