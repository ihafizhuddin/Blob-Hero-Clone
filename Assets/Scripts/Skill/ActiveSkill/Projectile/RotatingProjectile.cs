using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingProjectile : BaseProjectile{
    [SerializeField]protected Transform axisPosition;
    [SerializeField]protected float rotationSpeed;
    // [SerializeField]protected float distanceRadius;

    // [SerializeField]protected Vector3 position;
    // [SerializeField]protected Vector3 pivot;
    // [SerializeField]protected GameObject orb;
    // [SerializeField]protected GameObject[] orbs;
    // Start is called before the first frame update
    // void Start(){
        
    // }

    // Update is called once per frame
    void Update(){
    }
    // void LateUpdate(){

    // }
    void Orbiting(){
    }
    protected override void OnTriggerEnter(Collider col){
        base.OnTriggerEnter(col);
        // if(col.gameObject.tag == "Enemy"){
            //kill enemy
            // Destroy(col.gameObject);
        // }
    }
}
