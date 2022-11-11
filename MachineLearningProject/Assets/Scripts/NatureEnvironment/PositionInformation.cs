using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType {
    cheese, 
    mouse, 
    cat
}

public class PositionInformation : MonoBehaviour
{
    public static PositionInformation Instance;
    private void Awake(){
        if(Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    [SerializeField] private Transform cheese;
    [SerializeField] private Transform mouse;
    [SerializeField] private Transform cat;
    
    public Vector3 GetObjectPosition(ObjectType objectType){
        switch(objectType){
            case ObjectType.cheese:
                return cheese.position;
            case ObjectType.mouse:
                return mouse.position;
            case ObjectType.cat:
                return cat.position;
            default:
                Debug.Log("Not a valid object type");
                return Vector3.zero;
        }
    }

}
