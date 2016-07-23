using UnityEngine;
using System.Collections;


public class Tile 
{
    // pointer to map.
    protected TiledMap mTiledMaP;

    // pos in map. from 0 to ...    
    protected int mPosX;
    protected int mPosY;


    protected Tile(TiledMap a_tiledMap)
    {
        mTiledMaP = a_tiledMap;
    }
}
