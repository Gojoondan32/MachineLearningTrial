using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSystem
{
    private int width, height, rowSpace;
    private PlatformObject[,] platformObjectArray;
    public PlatformSystem(int width, int height, int rowSpace){
        this.width = width;
        this.height = height;
        this.rowSpace = rowSpace;

        platformObjectArray = new PlatformObject[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                PlatformPosition platformPosition = new PlatformPosition(x, z);
                platformObjectArray[x, z] = new PlatformObject(this, platformPosition);
            }
        }
    }
}
