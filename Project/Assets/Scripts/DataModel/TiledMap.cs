using UnityEngine;
using System.Collections;

public class TiledMap 
{
    int mTileSize = 24; // set default tile size.

    UITexture mBackgroud; // back ground texture. 

    Tile[][] mTileArray;


    public static TiledMap CreateMap(int a_sizeX, int a_sizeZ)
    {
        return new TiledMap(a_sizeX, a_sizeZ);
    }

    protected TiledMap(int a_sizeX, int a_sizeZ)
    {
        mTileArray = new Tile[a_sizeX][];

        for (int i = 0; i < a_sizeX; i++ )
        {
            mTileArray[i] = new Tile[a_sizeZ];
        }
    }

    public void setTileSize( int a_size )
    {
        mTileSize = a_size;
    }    

}
