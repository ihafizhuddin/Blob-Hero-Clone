using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorProjectile : BaseProjectile{
    [SerializeField] protected GameObject explosion;
    [SerializeField] Rigidbody rb;
    [SerializeField] Collider cl;

    // Start is called before the first frame update
    protected override void Start(){
        rb =  GetComponent<Rigidbody>();
        cl = GetComponent<Collider>();
    }

    // Update is called once per frame
    // void Update(){
        
    // }
    protected override void OnTriggerEnter(Collider col){
        base.OnTriggerEnter(col);
        // if(col.gameObject.tag == "Enemy"){
        //     //kill enemy
        //     Destroy(col.gameObject);
        // }
        if(col.gameObject.tag == "Ground"){
            //play explosion
            Instantiate(explosion, transform.position, transform.rotation, this.transform);
            Vector3 pulsePos = new Vector3(transform.position.x, col.gameObject.transform.position.y, transform.position.z);
            col.gameObject.GetComponent<SimpleSonarShader_Object>().StartSonarRing(pulsePos, 10);

        }

    }
    // void OnCollisionEnter(Collision col){
    //     if(col.gameObject.tag == "Ground"){
    //         col.gameObject.GetComponent<SimpleSonarShader_Object>().StartSonarRing(col.contacts[0].point, col.impulse.magnitude / 10.0f);
    //         // rb.isKinematic = true;
    //         // cl.enabled = false;
    //         cl.isTrigger = true;
    //     }

    // }

    void OnTriggerExit(Collider col){
        if(col.gameObject.tag == "Ground"){
            //destroy meteor
            Destroy(gameObject,3f);
        }

    }
}
