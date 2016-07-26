using UnityEngine;
using System.Collections;


public abstract class Tile 
{
    // pointer to map.
    protected TiledMap mTiledMaP;

    // able to build ?
    protected bool mIsBuiltable = false;

    // pos in map. from 0 to ...    
    protected int mPosX;
    protected int mPosZ;


    protected Tile(TiledMap a_tiledMap)
    {
        mTiledMaP = a_tiledMap;
    }
}
