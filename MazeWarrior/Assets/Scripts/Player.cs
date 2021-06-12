using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody rig;
    private Animator anim;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public GameObject damagePoint;
    private float rotationSpeed = 4f;
    private float moveHorizontal, moveVertical ;
    private float rotY = 0f;
    private bool isPlayerMoving;
    private bool keyS;
    private bool keyW;

    private AudioSource m_AudioSource;
    [SerializeField] private AudioClip attackSound;
    [SerializeField] private AudioClip[] runSound;

    void Awake(){
      anim = GetComponent<Animator>();
      m_AudioSource = GetComponent<AudioSource>();
    }

    void Start(){
      rotY = transform.localRotation.eulerAngles.y;
      DeactivateDamagePoint();
    }
    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
    }

    void FixedUpdate(){
      Move();
      Attack();
    }

    void PlayerMoveKeyboard(){
      if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)){
        moveVertical = 1;
        keyW = true;
      }

      if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow)){
        moveVertical = 0;
        keyW = false;
      }

    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        if(moveVertical != 0){
          if(keyW){
            rig.MovePosition((transform.position + transform.forward * moveSpeed));
          }
        }
        rotY += x * rotationSpeed;
        rig.rotation = Quaternion.Euler(0f, rotY, 0f);
    }

    void Attack(){
      if(Input.GetKeyDown(KeyCode.Space)){
        if(!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack") || !anim.GetCurrentAnimatorStateInfo(0).IsName("RunAttack") ){
          m_AudioSource.clip = attackSound;
          m_AudioSource.Play();
          anim.SetTrigger("Attack");
        }
      }
    }


    void AnimatePlayer(){
      if(moveVertical == 1)
      {
        if(!isPlayerMoving)
        {
          if(!anim.GetCurrentAnimatorStateInfo(0).IsName("Run"))
          {
            isPlayerMoving = true;
            anim.SetTrigger("Run");
            int n = Random.Range(1, runSound.Length);
            m_AudioSource.clip = runSound[n];
            m_AudioSource.PlayOneShot(m_AudioSource.clip);
            runSound[n] = runSound[0];
            runSound[0] = m_AudioSource.clip;

          }
        }
      }
      else
      {
        if(isPlayerMoving){
          if(anim.GetCurrentAnimatorStateInfo(0).IsName("Run")){
            isPlayerMoving = false;
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
