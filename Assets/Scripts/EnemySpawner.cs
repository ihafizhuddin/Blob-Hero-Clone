using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour{
    public static int enemyCount;
    public EnemyController[] enemyToSpawn;
    public float distanceToPlayer = 0;
    public float minimumDistanceForSpawn;
    public Transform[] spawnPos;
    public float spawnerCd;
    public float currentCd;
    
    
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        // if(GameManager.get.isPlaying && GameManager.get.player.isDeath)
        if(currentCd > 0){
            currentCd -= Time.deltaTime;
            return;
        }
        if(enemyCount > 100)return;
        currentCd = spawnerCd;
        distanceToPlayer = Vector3.Distance(GameManager.get.player.transform.position, transform.position);
        // Debug.Log("distance to player : "  + distanceToPlayer);
        if(distanceToPlayer <= minimumDistanceForSpawn){
            // Debug.Log("To close to Spawn");
            return;
        }else if( distanceToPlayer <= minimumDistanceForSpawn*2){
            //Spawn frenzy
            // Debug.Log("Spawn, Spawn, Spawn");
            SpawnEnemy();
            SpawnEnemy();
            SpawnEnemy(); 
            enemyCount += 3;
        }else{
            //regular spawn
            // Debug.Log("Just Spawn");
            SpawnEnemy(); 
            enemyCount++;
        }
        Debug.Log(enemyCount);
        
    }

    void SpawnEnemy(){
        int spawnPosIndex = Random.Range(0,spawnPos.Length);
        int spawnIndex = Random.Range(0,enemyToSpawn.Length);
        
        // EnemyController newEnemy = Instantiate(enemyToSpawn[spawnIndex], spawnPos[spawnPosIndex].position, transform.rotation);
        GameObject newEnemy = ObjectPool.ins.GetPooledObject(enemyToSpawn[spawnIndex].name);
        EnemyController enemy = newEnemy.GetComponent<EnemyController>();
        newEnemy.transform.position = spawnPos[spawnPosIndex].position;
        enemy.OnRespawn();
        newEnemy.SetActive(true);
        
        // Debug.Log("Spawn Enemy");
    }

    // public void SpawnPooled(EnemyCharacter en){
    //     if(GameManager.ins.player == null)return;

    //     var z = GameObject.Find(x => x.isDead && !x.gameObject.activeInHierarchy);
    //     if(z != null){
    //         z.enabled = true;
    //         z.isDead = false;
    //         z.transform.SetActive(true);
    //     }else{
    //         var spawned = instantiate(en);
    //         spawned.transform.position = SpawnedPos();
    //         spawnedEnemy.Addspawned();
    //     }
    // }
    

}
