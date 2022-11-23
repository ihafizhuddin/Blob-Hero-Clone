using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doozy.Runtime.UIManager.Animators;

public class SkillManager : MonoBehaviour{
    public static SkillManager inst;
    public List<BaseSkill> availableSkills = new List<BaseSkill>();
    public List<BaseSkill> currentActiveSkills = new List<BaseSkill>();
    [SerializeField] PlayerCharacter player;

    [Header("Panel add skill")]
    public UIContainerUIAnimator container;
    public SkillButtonUI skillButtonPrefab;
    public Transform skillButtonSpawnTransform;

    

    void Awake(){
        if(inst == null){
            inst = this;

        }else{
            Destroy(this.gameObject);
        }
        // player = GameManager.get.player;
    }
    

    void Start(){
        // showOfferedSkillPanel();
    }
    public void AddSkill(BaseSkill skill){
        var find = currentActiveSkills.Find(x => x.skillName == skill.skillName);
        if(find != null){
            find.OnLevelUp();
        }else{
            // var skillClone = Instantiate(skill,player.transform);
            // currentActiveSkills.Add(skillClone);
            currentActiveSkills.Add(skill);
            // find.OnLevelUp();
            skill.OnLevelUp();
        }
        hideOfferedSkillPanel();
    }
    public void initOfferedSkill(){
        foreach (var sk in availableSkills){
            var btn = Instantiate(skillButtonPrefab, skillButtonSpawnTransform);
            btn.SkillToInit = sk;
            btn.initSkill();
        }
        // for (int i = 0; i < 3; i++){
        //     Debug.Log("power up " + i);
        //     var btn = Instantiate(skillButtonPrefab, skillButtonSpawnTransform);
        //     int randomSkillIndex = Random.Range(0,availableSkills.Count);
        //     BaseSkill sk = availableSkills[randomSkillIndex];
        //     btn.SkillToInit = sk;
        // }
    }
    public void showOfferedSkillPanel(){
        container.Show();
        Time.timeScale = 0;
        initOfferedSkill();
    }
    public void hideOfferedSkillPanel(){
        container.Hide();
        foreach (Transform child in skillButtonSpawnTransform) {
            GameObject.Destroy(child.gameObject);
        }
        Time.timeScale = 1;
    }
    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    void Update(){
        if(player == null){
            player = GameManager.get.player;

        }
    }
    public void ResetSkill(){
        foreach (var sk in currentActiveSkills){
            sk.OnLevelReset();
        }
    }
}
