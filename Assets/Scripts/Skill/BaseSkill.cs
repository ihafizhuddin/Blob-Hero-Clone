using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSkill : MonoBehaviour{
    [SerializeField]protected Transform player;
    // Start is called before the first frame update
    protected virtual void Start(){
        player= this.transform;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }
}
