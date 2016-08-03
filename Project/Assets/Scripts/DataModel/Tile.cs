using UnityEngine;
using System.Collections;


[System.Serializable, DisallowMultipleComponent]
public abstract class Tile : MonoBehaviour
{
    // pointer to map.
    protected TiledMap mTiledMap;

    // able to build ?
    protected bool mIsBuiltable = false;

    // pos in map. from 0 to ...    
    [SerializeField, ReadOnly]
    protected int mPosX;
    [SerializeField, ReadOnly]
    protected int mPosZ;

    // size of the tile.
    [SerializeField, ReadOnly]
    protected int mSizeX = 1;
    [SerializeField, ReadOnly]
    protected int mSizeZ = 1;

    public int getPosX()
    {
        return mPosX;
    }

    public int getPosZ()
    {
        return mPosZ;
    }

    public int getSizeX()
    {
        return mSizeX;
    }

    public int getSizeZ()
    {
        return mSizeZ;
    }
}
