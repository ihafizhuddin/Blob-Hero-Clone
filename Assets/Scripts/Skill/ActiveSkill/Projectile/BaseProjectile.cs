using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProjectile : MonoBehaviour{
    [SerializeField]protected float projectileSpeed;
    [SerializeField]protected float projectileDamage;
    // // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    // // Update is called once per frame
    protected virtual void Update(){
        // base.Update();
    }
    protected virtual void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Enemy"){
            col.gameObject.GetComponent<EnemyController>().ReceiveDamage(projectileDamage);
        }
    }

        
}
