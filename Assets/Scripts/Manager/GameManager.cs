using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Doozy.Runtime.UIManager.Animators;
using TMPro;

public class GameManager : MonoBehaviour{
    public static GameManager get;

    public PlayerCharacter player;
    Vector3 playerStartPos;

    [Header("Player HUD")]
    public StateBar hpStateKn;
    public StateBar hpStateKr;
    //
    public StateBar newHPBar;
    public StateBar newXPBar;
    public TextMeshProUGUI levelTMP;
    public TextMeshProUGUI expTMP;

    [Header("Player Stats")]
    public int playerLevel = 1;
    public int currentExp = 0;
    public int baseNextExp = 25;
    public int nextExpToLevelUp = 25;
    public float score;
    public float gold;

    [Header("Pause Resume Game")]
    public bool isPlaying;
    public UIContainerUIAnimator pauseSimpleContAnimat;
    public bool pauseIsShow;

    [Header("Start Menu")]
    public UIContainerUIAnimator startMenuSimpleContAnimat;
    public bool startMenuIsShow;

    [Header("Game Over")]
    public UIContainerUIAnimator gameOverSimpleContAnimat;
    public bool gameOverIsShow;
    

    void Awake(){
        get = this;
    }

    // Start is called before the first frame update
    void Start(){
        FindPlayer();
        hpStateKn.maxValue = player.maxHP;
        hpStateKr.maxValue = player.maxHP;
        OpenStartMenu();
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void OpenStartMenu(){
        //Instant Show start menu
        startMenuSimpleContAnimat.Show();
        //Pause game
        Time.timeScale = 0;
    }

    public void StartGame(){
        //Hide start menu Panel
        startMenuSimpleContAnimat.Hide();
        //Start Game
        Time.timeScale = 1;
        updateNewHPBar();
        updateExpBar();
    }
    public void GameOver(){
        //pause game
        Time.timeScale = 0;
        //Show game over panel
        gameOverSimpleContAnimat.Show();
        gameOverIsShow = true;
    }
    public void ExitGame(){
        Application.Quit();
    }
    public void ReloadScene(){
        // Scene scene = SceneManager.GetActiveScene();
        // SceneManager.LoadScene(scene.name);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void RestartGame(){
        //Clean object pooler
        ObjectPool.ins.CleanObjectPool();
        //Reset player stats
        playerLevel = 1;
        currentExp = 0;
        nextExpToLevelUp = baseNextExp;
        score = 0;
        gold = 0;
        player.OnRespawn();
        updateHPBar();
        updateNewHPBar();
        updateExpBar();
        levelTMP.text = "level : " + playerLevel;
        //Reset skill level
        SkillManager.inst.ResetSkill();
        //Reset position
        ResetPlayerPosition();
        //Resume Game
        Time.timeScale = 1;
        EnemySpawner.enemyCount = 0;
        //Hide pause panel
        if(pauseIsShow){
            pauseSimpleContAnimat.Hide();
            pauseIsShow = false;
        }
        //Hide gameover panel
        if(gameOverIsShow){
            gameOverSimpleContAnimat.Hide();
            gameOverIsShow = false;
        }

    }


    public void PauseResume(bool play){
        isPlaying = play;
        if(isPlaying){
            //Resume
            pauseSimpleContAnimat.Hide();
            Time.timeScale = 1;
            pauseIsShow = false;
        }else{
            //Pause
            pauseSimpleContAnimat.Show();
            Time.timeScale = 0;
            pauseIsShow = true;
        }
    }
    public void PauseResume(){
        isPlaying = !isPlaying;
        if(isPlaying){
            //Resume
            pauseSimpleContAnimat.Hide();
            Time.timeScale = 1;
            pauseIsShow = false;
        }else{
            //Pause
            pauseSimpleContAnimat.Show();
            Time.timeScale = 0;
            pauseIsShow = true;
        }
    }

    public void FindPlayer(){
        if(player !=null) return;
        player = GameObject.FindObjectOfType<PlayerCharacter>();
        playerStartPos = player.transform.position;
    }

    public void ResetPlayerPosition(){
        player.transform.position = playerStartPos;
    }

    public void updateHPBar(){
        hpStateKn.currentValue = player.HP;
        hpStateKr.currentValue = player.HP;
        hpStateKn.setCurValScaled();
        hpStateKr.setCurValScaled();
    }

    public void updateNewHPBar(){
        newHPBar.currentValue = player.HP;
        newHPBar.maxValue =player.maxHP;
        newHPBar.setCurValScaled();
    }

    public void addExp(int exp){
        currentExp += exp;
        expTMP.text = currentExp + "/" + nextExpToLevelUp;
        updateExpBar();
        if(currentExp >= nextExpToLevelUp){
            // Debug.Log("C");
            currentExp -= nextExpToLevelUp;
            nextExpToLevelUp = nextExpToLevelUp + (nextExpToLevelUp/2);
            SkillManager.inst.showOfferedSkillPanel();
            playerLevel++;
            levelTMP.text = "level : " + playerLevel;
        }
        updateExpBar();
        expTMP.text = currentExp + "/" + nextExpToLevelUp;
        
    }

    public void updateExpBar(){
        newXPBar.currentValue = currentExp;
        newXPBar.maxValue = nextExpToLevelUp;
        newXPBar.setCurValScaled();
    }

    // public void OnPlayerLevelUp(){

    // }
}
