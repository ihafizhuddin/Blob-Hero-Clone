// #define MOVEMENTv1
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : BaseCharacter{
    public float forceFieldRadius;
    public float forceFieldDuration;
    private float currentForceDuration;
    public float forceFieldDamage;
    void OnDrawGizmosSelected(){
        Gizmos.color = new Color(1,0,0,0.5f);
        Gizmos.DrawSphere(transform.position, forceFieldRadius);
    }
    protected override void Update(){
        base.Update();
        // BasicForceFieldDamage();
    }
    protected void BasicForceFieldDamage(){
        if(currentForceDuration > 0){
            currentForceDuration -= Time.deltaTime;
            return;
        }
        currentForceDuration = forceFieldDuration;
        Collider[] enemyToDamage = Physics.OverlapSphere(transform.position, forceFieldRadius);
        // enemyToDamage.GetComponent<EnemyHealthect>().TakeDamage(damage);
        foreach (var enemy in enemyToDamage){
            
            // hitCollider.SendMessage("AddDamage");

        }
        
    }
    public override void Move(){
        if(isDeath)return;
#if MOVEMENTv1
        Vector3 rotation = new Vector3(0, Input.GetAxis("Horizontal")* rotationSpeed * Time.deltaTime, 0);
        Vector3 move = new Vector3(0,0, Input.GetAxis("Vertical")* Time.deltaTime);
        charController.Move(move*movementSpeed);
        transform.Rotate(rotation);
#endif
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // if(horizontalInput != 0 || verticalInput != 0){
        //     anim.SetBool("isMoving", true);
        // }else{
        //     anim.SetBool("isMoving", false);
        // }
        if(Input.GetMouseButtonDown(0)){
            anim.SetBool("isAttacking", true);

        }else{
            anim.SetBool("isAttacking", false);

        }

        // anim.SetFloat("Horizontal", horizontalInput);
        // anim.SetFloat("Vertical", verticalInput);

        Vector3 movDirection = new Vector3(horizontalInput, 0 , verticalInput);
        charController.Move(movDirection* movementSpeed * Time.deltaTime);
        
        if(movDirection != Vector3.zero){
            Quaternion toRotation = Quaternion.LookRotation(movDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            anim.SetBool("isMoving", true);
        }else{
            anim.SetBool("isMoving", false);
        }
    }

    

    public override void ReceiveDamage(float damage){
        base.ReceiveDamage(damage);
        // if(isDeath)return;
        // if(healthPoint <=0){
        //     anim.SetTrigger("Death");
        //     isDeath = true;
        // }

        // healthPoint -= damage;
        // Debug.Log("Receive Damage : " + damage);
    }

}
