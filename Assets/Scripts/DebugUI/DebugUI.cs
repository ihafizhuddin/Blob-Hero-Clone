using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doozy.Runtime.UIManager.Animators;

public class DebugUI : MonoBehaviour{
    public bool isShow = false;
    public UIContainerUIAnimator debugSkillPanelAnimator;
    
    public void showHideDebugPanel(){
        isShow = !isShow;
        if(isShow){
            //show panel
            debugSkillPanelAnimator.Show();
        }else{
            //hide panel
            debugSkillPanelAnimator.Hide();
        }
        
    }
}
