using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour{
    public EnemyController[] enemyToSpawn;
    public float distanceToPlayer = 0;
    public float minimumDistanceForSpawn;
    public Transform[] spawnPos;
    
    
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        distanceToPlayer = Vector3.Distance(GameManager.get.player.transform.position, transform.position);
        if(distanceToPlayer <= minimumDistanceForSpawn){
            return;
        }else if( distanceToPlayer <= minimumDistanceForSpawn*2){
            //Spawn frenzy
        }else{
            //regular spawn
        }
        
    }

    void SpawnEnemy(){

    }
    

}
