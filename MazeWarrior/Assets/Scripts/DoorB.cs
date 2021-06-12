using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorB : MonoBehaviour
{
  private Animator anim;
  public KeyB keyB;

  void Awake(){
    anim = GetComponent<Animator>();
  }

  void Update(){
    if(keyB.GotKey){
      anim.SetBool("isOpening",true);
    }
  }
}
