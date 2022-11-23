using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobMeteor : ActiveSkill{
    [SerializeField] protected MeteorProjectile meteor;
    [SerializeField] protected float upScale = 0.2f;
    
    
    void Update(){
        base.Update();
        // if(Input.GetKeyDown(KeyCode.Return)){
        //     Action();
        // }
    }
    public override void Action(){
        float scaleChange = 1 + upScale;
        Vector3 newScale = new Vector3(scaleChange, scaleChange, scaleChange);
        Vector3 newPosition = transform.position;
        newPosition.y = 10;
        MeteorProjectile newMeteor = Instantiate(meteor, newPosition, transform.rotation);
        newMeteor.transform.localScale += newScale;
    }
    public void OnLevelUp(){
        base.OnLevelUp();
        upScale = 0.2f * level;
    }
    public override void OnLevelReset(){
        base.OnLevelReset();
    }
}
