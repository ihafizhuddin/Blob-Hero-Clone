using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateBar : MonoBehaviour{
    public string stateName;
    public float maxValue;
    public float minValue = 0;
    public float currentValue;
    public float currentValueScaled;
    public Image stateBarImg;

    public void setMaxValue(float newMaxValue){
        maxValue = newMaxValue;
    }
    public void decreaseCurValue(float value){
        currentValue -= value;
        if(currentValue <= minValue){
            currentValue = 0;
        }
        setCurValScaled();

    }

    public void setCurValScaled(){
        currentValueScaled = currentValue/maxValue;
        stateBarImg.fillAmount = Mathf.Clamp(currentValueScaled, 0, 1f);
    }
    // Start is called before the first frame update
    void Start(){
        // stateBarImg = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
