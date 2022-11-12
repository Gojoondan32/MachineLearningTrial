using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RewardType {
    mouseInWall, 
    catInWall, 
    catFindMouse, 
    mouseSurvive
}

public class EnvironmentManager : MonoBehaviour
{
    [SerializeField] private Mouse mouse;
    [SerializeField] private Cat cat;
    
    [Header("Visuals")]
    [SerializeField] private Material catWin;
    [SerializeField] private Material mouseWin;
    [SerializeField] private MeshRenderer floorMesh;

    public void DistributeRewards(RewardType rewardType){
        switch(rewardType){
            case RewardType.mouseInWall:
                mouse.SetReward(-1f);
                cat.SetReward(0f);
                EndCurrentEpisode(true);
                break;
            case RewardType.catInWall:
                cat.SetReward(-1f);
                mouse.SetReward(0f);
                EndCurrentEpisode(false);
                break;
            case RewardType.catFindMouse:
                cat.SetReward(1f);
                mouse.SetReward(-1f);
                EndCurrentEpisode(true);
                break;
            case RewardType.mouseSurvive: //Fix this reward system
                mouse.SetReward(1f);
                cat.SetReward(-1f);
                EndCurrentEpisode(false);
                break;
        }
        
    }

    private void SetFloorMaterial(bool catWin) => floorMesh.material = catWin ? this.catWin : mouseWin;

    private void EndCurrentEpisode(bool catWin){
        Debug.Log("Episode Ended");
        SetFloorMaterial(catWin);
        cat.EndEpisode();
        mouse.EndEpisode();
    }
}
