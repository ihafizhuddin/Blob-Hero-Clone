using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Doozy.Runtime.UIManager.Components;
using TMPro;

public class SkillButtonUI : MonoBehaviour{
    public UIButton button;
    public TextMeshProUGUI skillNameLabel;
    public Image skillImage;
    public BaseSkill SkillToInit;

    public void initSkill(){
        skillNameLabel.text = SkillToInit.skillName;
        skillImage.sprite = SkillToInit.skillImage;
        // Debug.Log("A");
        button.AddBehaviour(Doozy.Runtime.UIManager.UIBehaviour.Name.PointerClick).Event.AddListener(() => SkillManager.inst.AddSkill(SkillToInit));
        // Debug.Log("B");
    }
}
