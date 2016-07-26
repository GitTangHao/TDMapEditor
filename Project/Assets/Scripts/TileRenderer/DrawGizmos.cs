using UnityEngine;
using System.Collections;

public class DrawGizmos : MonoBehaviour
{
    void Start()
    {
        GLDraw.Init();
    }

    void OnPostRender()
    {
        GLDraw.DrawSolidTiles(2, 1, 1, 1, 1, Color.red);
        GLDraw.DrawTiledFrames(0, 0, 30, 30, 1, Color.green);
    }

}
