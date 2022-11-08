using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActiveSkill : BaseSkill{
    [SerializeField]protected float cooldown;
    protected float currentCooldown;
    
    // [SerializeField]protected Action skillCode;
    protected override void Update(){
        base.Update();
        if(currentCooldown <= 0){
            Action();
            currentCooldown = cooldown;
        }else{
            currentCooldown -= Time.deltaTime;

        }
    }
    
    public abstract void Action();
}
