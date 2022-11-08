using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingProjectile : BaseProjectile{
    [SerializeField]protected Transform axisPosition;
    [SerializeField]protected float rotationSpeed;
    [SerializeField]protected float distanceRadius;

    [SerializeField]protected Vector3 position;
    [SerializeField]protected Vector3 pivot;
    [SerializeField]protected GameObject orb;
    [SerializeField]protected GameObject[] orbs;
    // Start is called before the first frame update
    // void Start(){
        
    // }

    // Update is called once per frame
    void Update(){
        // position = axisPosition.position + pivot;
        // transform.position = position
        // transform.RotateAround(axisPosition.position, Vector3.up, rotationSpeed * Time.deltaTime);
        // base.Update();
        Orbiting();
    }
    // void LateUpdate(){

    // }
    void Orbiting(){
        // transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime,0));
        //  if(axisPosition != null){
             // Keep us at orbitDistance from target
            //  transform.position = axisPosition.position + (transform.position - axisPosition.position).normalized * distanceRadius;
            //  transform.RotateAround(axisPosition.position, Vector3.up, rotationSpeed * Time.deltaTime);
        //  }
    }
    void instantiateOrb(){

    }
}
