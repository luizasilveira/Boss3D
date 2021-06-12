using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyB : MonoBehaviour
{
  private bool gotKey;
  public bool GotKey { get { return gotKey; } }

  void OnTriggerEnter(Collider col){
    if(col.tag == "Player"){
      gotKey = true;
      Destroy(gameObject);
    }
  }

}
