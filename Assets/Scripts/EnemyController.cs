using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : BaseCharacter{
    public PlayerCharacter TargetPlayer;
    [SerializeField] protected float attackDistance = 2;
    public float damagePerSekon;
    public float attackDuration;
    float currentAttackDuration;
    float distanceToPlayer;

    
    protected override void Start(){
        base.Start();
        FindTarget();
    }
    protected override void Update(){
        base.Update();
        TakeForceDamage();
    }

    public void TakeForceDamage(){
        if(distanceToPlayer < TargetPlayer.forceFieldRadius){
            float damage = TargetPlayer.forceFieldDamage *((TargetPlayer.forceFieldRadius - distanceToPlayer)/TargetPlayer.forceFieldRadius);
            ReceiveDamage(damage*Time.deltaTime);
        }
    }
    public void FindTarget(){
        if(TargetPlayer !=null) return;
        TargetPlayer = GameObject.FindObjectOfType<PlayerCharacter>();
    }

    public override void Move(){
        if(isDeath)return;
        if(TargetPlayer.isDeath){
            anim.SetTrigger("Idle");
        return;
        }
        Vector3 targetDirection = TargetPlayer.transform.position - this.transform.position;
        targetDirection = targetDirection.normalized;
        distanceToPlayer = Vector3.Distance(this.transform.position, TargetPlayer.transform.position );
        // Debug.Log("Distance : " + distance);
        if(distanceToPlayer > attackDistance){
            currentAttackDuration = attackDuration;
            // transform.Translate(targetDirection.normalized * Time.deltaTime * movementSpeed);
            charController.Move(targetDirection* movementSpeed * Time.deltaTime);
            transform.LookAt(TargetPlayer.transform);
            // transform.rotation = Quaternion.RotateTowards(
            //     transform.rotation, Quaternion.LookRotation(TargetPlayer.transform.position), Time.deltaTime*rotationSpeed
            // );
            anim.SetBool("isAttacking", false);
        }else{
            currentAttackDuration -= Time.deltaTime;
            anim.SetBool("isAttacking", true);
            if(currentAttackDuration <=0){
                TargetPlayer.ReceiveDamage(damagePerSekon);
                currentAttackDuration = attackDuration;
            }
            
        }

    }
    public override void ReceiveDamage(float damage){
        base.ReceiveDamage(damage);
    //     if(damage > 0){

    //     }
    }
}
