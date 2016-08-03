using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[DisallowMultipleComponent]
public class TiledMap : MonoBehaviour
{
    public static readonly int sTileAvailable = 0;
    public static readonly int sTileOccupied = 1;

    // default tile size.
    [ReadOnly]
    public int mTileSize = 24;

    [ReadOnly]
    public List<Tile> mTileList = new List<Tile>();
    public int[][] mTileArray;

    // map size.
    [ReadOnly]
    public int mSizeX;
    [ReadOnly]
    public int mSizeZ;

    public void InitMap(int a_sizeX, int a_sizeZ)
    {
        mSizeX = a_sizeX;
        mSizeZ = a_sizeZ;

        mTileArray = new int[a_sizeX][];

        for (int i = 0; i < a_sizeX; i++)
        {
            mTileArray[i] = new int[a_sizeZ];
        }

        mTileList.Clear();
    }

    public bool isTileAvailabe(int a_posX, int a_posZ)
    {
        if (a_posX >= mSizeX || a_posX < 0 || a_posZ >= mSizeZ || a_posZ < 0)
        {
            return false;
        }
        return mTileArray[a_posX][a_posZ] == sTileAvailable;
    }

    public bool isTileAvailabe(Tile a_tile)
    {
        int tPosX = a_tile.getPosX();
        int tPosZ = a_tile.getPosZ();
        for (int i = 0, imax = a_tile.getSizeX(); i < imax; i++)
        {
            for (int j = 0, jmax = a_tile.getSizeZ(); j < jmax; j++)
            {
                if (!isTileAvailabe(tPosX + i, tPosZ + j))
                {
                    return false;
                }
            }
        }
        return true;
    }

    public bool addTile(Tile a_tile)
    {
        if (isTileAvailabe(a_tile))
        {
            int tPosX = a_tile.getPosX();
            int tPosZ = a_tile.getPosZ();
            for (int i = 0, imax = a_tile.getSizeX(); i < imax; i++)
            {
                for (int j = 0, jmax = a_tile.getSizeZ(); j < jmax; j++)
                {
                    mTileArray[tPosX + i][tPosZ + j] = sTileOccupied;
                }
            }
            mTileList.Add(a_tile);
            return true;
        }
        return false;
    }

    public bool removeTile(Tile a_tile)
    {
        if (mTileList.Contains(a_tile))
        {
            int tPosX = a_tile.getPosX();
            int tPosZ = a_tile.getPosZ();
            for (int i = 0, imax = a_tile.getSizeX(); i < imax; i++)
            {
                for (int j = 0, jmax = a_tile.getSizeZ(); j < jmax; j++)
                {
                    mTileArray[tPosX + i][tPosZ + j] = sTileAvailable;
                }
            }
            return mTileList.Remove(a_tile);
        }
        return false;
    }

}
