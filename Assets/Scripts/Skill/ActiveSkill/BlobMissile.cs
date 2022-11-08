using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobMissile : ActiveSkill{
    [SerializeField]protected Transform skillTarget;
    [SerializeField]protected int enemyToHit;
    [SerializeField]protected float misileSpeed;
    [SerializeField]protected HomingProjectile projectile;
    [SerializeField]protected LayerMask enemyLayer;

    // [SerializeField]
    // 
    protected override void Update(){
        base.Update();
    }
    public override void Action(){
        //Get closest enemy
        Collider[] hitColliders = Physics.OverlapSphere(player.position, Mathf.Infinity, enemyLayer);
        float minDistance = Mathf.Infinity;
        foreach (Collider col in hitColliders){
            float distance = Vector3.Distance(player.position, col.transform.position);
            if(distance < minDistance){
                minDistance = distance;
                skillTarget = col.transform;
            }
        }
        if(skillTarget == null)return;
        //Instantiate misile
        HomingProjectile misile = Instantiate(projectile, transform.position, transform.rotation);
        // misile.projectileSpeed = misileSpeed;
        misile.target = skillTarget;
        
    }


}
