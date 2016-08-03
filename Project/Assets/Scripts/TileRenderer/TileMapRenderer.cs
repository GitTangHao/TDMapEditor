using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
public class TileMapRenderer : MonoBehaviour 
{
    TiledMap mTiledMap;

	// Use this for initialization
	void Start () 
    {
        GLDraw.Init();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnPostRender()
    {
        if (mTiledMap == null)
        {
            return;
        }

        // Draw tile frames.
        GLDraw.DrawTiledFrames(0, 0, mTiledMap.mSizeX, mTiledMap.mSizeZ, 1, Color.green);

        foreach (Tile tTile in mTiledMap.mTileList)
        {
            
            
        }
    }
}
