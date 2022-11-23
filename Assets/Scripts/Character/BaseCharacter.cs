using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCharacter : MonoBehaviour{
    
    protected CharacterController charController;
    protected Animator anim;
    [Header("Player Stats")]
    [SerializeField] protected float rotationSpeed = 100;
    // [SerializeField]protected float health = 100;
    [SerializeField]protected float movementSpeed = 10;
    
    [SerializeField]public float maxHP = 100;
    [SerializeField]public float HP = 100;

    [SerializeField]protected float healthPoint = 100;
    [SerializeField]public bool isDeath = false;
    public abstract void Move();
    public virtual void ReceiveDamage(float damage){
        if(isDeath)return;
        healthPoint -= damage;
        if(healthPoint <= 0){
            anim.SetTrigger("Death");
            isDeath = true;
            OnDead();
        }
        HP = healthPoint;

        // Debug.Log("Receive Damage : " + damage);
    }
    // Start is called before the first frame update
    protected virtual void Start(){
        anim = GetComponent<Animator>();
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    protected virtual void Update(){
        Move();
    }
    protected virtual void OnDead(){
        anim.SetTrigger("Death");
        isDeath = true;
    }
    protected virtual void afterDead(){}
    // protected abstract void OnSpawn();
}
