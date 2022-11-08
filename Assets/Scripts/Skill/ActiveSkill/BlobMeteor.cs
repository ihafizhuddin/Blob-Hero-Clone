using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobMeteor : ActiveSkill{
    [SerializeField] protected MeteorProjectile meteor;
    void Update(){
        if(Input.GetKeyDown(KeyCode.Return)){
            Action();
        }
    }
    public override void Action(){
        Vector3 newPosition = transform.position;
        newPosition.y = 10;
        MeteorProjectile newMeteor = Instantiate(meteor, newPosition, transform.rotation);
    }
}
