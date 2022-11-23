using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobMissile : ActiveSkill{
    
    [SerializeField]protected Transform skillTarget;
    [SerializeField]protected Transform[] skillTargets;
    [SerializeField]protected float[] targetDistance;
    [SerializeField]protected int enemyToHit;
    [SerializeField]protected float misileSpeed;
    [SerializeField]protected LayerMask enemyLayer;
    [SerializeField]protected HomingProjectile projectile;


    // [SerializeField]
    // 
    
    protected override void Update(){
        base.Update();
    }
    public override void Action(){
        //Get closest enemy
        Collider[] hitColliders = Physics.OverlapSphere(player.position, Mathf.Infinity, enemyLayer);
        // Collider[] hitColliders = Physics.OverlapSphere(player.position, 50, enemyLayer);
        // hitCollider.OrderBy(distance => )
        skillTargets = new Transform[level];
        targetDistance = new float[level];
        float minDistance = Mathf.Infinity;
        // foreach (Collider col in hitColliders.OrderBy(sorted=> Vector3.Distance(player.position, col.transform.position)))
        // {
        //     // Debug.Log(sort);
        // }
        int spawnCount = 0;
        // int index = 0;
        foreach (Collider col in hitColliders){
            float distance = Vector3.Distance(player.position, col.transform.position);
            if(distance < minDistance){
                minDistance = distance;
                skillTarget = col.transform;
                // targetDistance[index] = distance;
                insertSorted(col.transform);

                // sortTargetTransform(col.transform, index);
                // if(index <= level){
                    // index++;

                // }
            }
        }
        // if(skillTarget == null)return;
        //Instantiate misile
        for (int i = 0; i < level; i++){
            Vector3 newPosition = transform.position;
            newPosition.y = -2.3f;
            // HomingProjectile misile = Instantiate(projectile, transform.position, transform.rotation);
            GameObject newMissile = ObjectPool.ins.GetPooledObject("Missile");
            newMissile.transform.position = transform.position;
            // newMissile.transform.position = Quaternion.Identity;
            newMissile.SetActive(true);
            HomingProjectile misile = newMissile.GetComponent<HomingProjectile>();
            // spawnCount++;
            // misile.projectileSpeed = misileSpeed;
            misile.target = skillTargets[i];
            
        }
        // Debug.Log("Spawn " + spawnCount + " missile");
        
    }
    public override void OnLevelUp(){
        base.OnLevelUp();

    }
    public override void OnLevelReset(){
        base.OnLevelReset();

    }
    public void insertSorted(Transform target){
        for(int i = 0 ; i < skillTargets.Length ; i++){
            int jumlah = skillTargets.Length;
            
            if(i == jumlah-1){//first input
                skillTargets[i] = target;
            }else{
                // if(skillTargets[jumlah-i -1]== null){
                //     skillTargets[jumlah-i-1] = target;

                // }else{
                    skillTargets[i] = skillTargets[i+1];

                // }
            }
        }

    }
    //  public void sortTargetTransform(Transform target, int index){
        // for(int i = 0 ; i < skillTargets.Length ; i++){
        //     int jumlah = skillTargets.Length;
            
        //     if(i == jumlah-1){//first input
        //         skillTargets[i] = target;
        //     }else{
        //         // if(skillTargets[jumlah-i -1]== null){
        //         //     skillTargets[jumlah-i-1] = target;

        //         // }else{
        //             skillTargets[i] = skillTargets[i-1];

        //         // }
        //     }
        // }
    //     skillTargets[index] = target;
    //  }


}
