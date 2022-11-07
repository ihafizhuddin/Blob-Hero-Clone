using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{
    public static GameManager get;

    public PlayerCharacter player;
    public bool isPlaying;
    public float score;
    public float gold;
    public float exp;

    void Awake(){
        get = this;
    }

    // Start is called before the first frame update
    void Start(){
        FindPlayer();
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void FindPlayer(){
        if(player !=null) return;
        player = GameObject.FindObjectOfType<PlayerCharacter>();
    }
}
