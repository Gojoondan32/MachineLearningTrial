using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformObject
{
    private PlatformSystem platformSystem;
    private PlatformPosition platformPosition;
    private Obstacle obstacle;

    public PlatformObject(PlatformSystem platformSystem, PlatformPosition platformPosition){
        this.platformSystem = platformSystem;
        this.platformPosition = platformPosition;
    }
}
