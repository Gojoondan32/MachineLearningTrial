using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GridDebugObject : MonoBehaviour
{
    [SerializeField] private TextMeshPro textMeshPro;
    [SerializeField] private Color color1, color2;
    [SerializeField] private Image image;
    private GridObject gridObject;
    public void SetGridObject(GridObject gridObject, bool isOffset){
        this.gridObject = gridObject;
        color1.a = 1;
        color2.a = 1;
        image.color = isOffset ? color1 : color2;
    }

    private void Update(){
        textMeshPro.text = gridObject.ToString();
    }
}
