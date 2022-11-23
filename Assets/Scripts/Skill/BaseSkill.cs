using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSkill : MonoBehaviour{
    [SerializeField]protected Transform player;
    [SerializeField]protected int level = 1;
    public string skillName;
    public Sprite skillImage;
    // Start is called before the first frame update
    protected virtual void Start(){
        player= this.transform;
    }
    public virtual void OnLevelUp(){
        level++;
    }
    public virtual void OnLevelReset(){
        int level = 0;
    }

    // Update is called once per frame
    protected virtual void Update(){
        
    }
}
