using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorProjectile : BaseProjectile{
    // Start is called before the first frame update
    // void Start(){
        
    // }

    // Update is called once per frame
    // void Update(){
        
    // }
     void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Enemy"){
            //kill enemy
            Destroy(col.gameObject);
        }
        if(col.gameObject.tag == "Ground"){
            //play explosion
        }
    }

    void OnTriggerExit(Collider col){
        if(col.gameObject.tag == "Ground"){
            //destroy meteor
            Destroy(gameObject);
        }

    }
}
