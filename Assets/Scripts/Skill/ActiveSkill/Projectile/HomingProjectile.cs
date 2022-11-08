using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingProjectile : BaseProjectile{
    public Transform target;
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    void Update(){
        if(target == null)Destroy(gameObject);
        Vector3 direction = target.position - transform.position;
        direction.Normalize();
        direction.z = 0;
        //PR Rotate misilie agar bergerak maju bukan menyamping
        // Vector3 rightDir = direction;
        // Vector3 forwardDir = Vector3.Cross(rightDir, Vector3.right);
        // if (forwardDir.sqrMagnitude == Vector3.zero) {
        //     return;
        // }
        // transform.rotation = Quaternion.LookRotation(forwardDir);
        transform.position += (direction *Time.deltaTime * projectileSpeed);
        // transform.Translate(target.position * projectileSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Enemy"){
            //kill enemy
           Destroy(col.gameObject);
        Destroy(this.gameObject);
        }
        
    }
}
