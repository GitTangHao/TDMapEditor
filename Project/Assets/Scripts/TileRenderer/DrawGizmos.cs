using UnityEngine;
using System.Collections;

public class DrawGizmos : MonoBehaviour
{
    void Start()
    {
     //   GLDraw.Init();
    }

    void OnPostRender()
    {
        //GLDraw.DrawSolidTiles(0, 0, 1, 1, 1, Color.red);
        //GLDraw.DrawTiledFrames(-50, -50, 100, 100, 1, Color.green);
    }

}
