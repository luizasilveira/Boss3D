using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // public GameObject player, playButton;
    private Animator anim;
    public KeyA keyA;


    void Awake(){
      anim = GetComponent<Animator>();
    }

    void Update(){
      if(keyA.GotKey){
        anim.SetBool("isOpening",true);
      }
    }
}
