using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum TypeOfValue {goal, save}
public class UIManager : MonoBehaviour
{
    #region Singelton
    public static UIManager Instance;
    private void Awake(){
        if(Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    #endregion
    
    [SerializeField] private Slider percentageSlider;
    [SerializeField] private TextMeshProUGUI saveScoreTxt;
    private int saveScore;
    [SerializeField] private TextMeshProUGUI goalScoreTxt;
    private int goalScore;

    public void UpdateGoalAndSaves(TypeOfValue typeOfValue){
        switch(typeOfValue){
            case TypeOfValue.goal:
                goalScore++;
                goalScoreTxt.text = goalScore.ToString();
                break;
            case TypeOfValue.save:
                saveScore++;
                saveScoreTxt.text = saveScore.ToString();
                break;
            default:
                Debug.LogError("An unknown type was passed in");
                break;

        }
        float total = saveScore + goalScore;
        float savePercentage = (saveScore / total) * 100;
        //Debug.Log(savePercentage);
        percentageSlider.value = savePercentage;
    }

}
