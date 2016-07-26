using UnityEngine;
using System.Collections;

public class TileBuild : Tile 
{
	protected TileBuild(TiledMap a_tiledMap) : base(a_tiledMap)
    {
        mIsBuiltable = true;
    }
}
