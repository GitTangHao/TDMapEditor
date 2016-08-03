using UnityEngine;
using System.Collections;

public class GLDraw
{
    static Material sLineMat;

    public static void Init()
    {
        if (sLineMat == null)
        {
            sLineMat = new Material("Shader \"Lines/Colored Blended\" {" +
                                    "SubShader { Pass { " +
                                    "    Blend SrcAlpha OneMinusSrcAlpha " +
                                    "    ZTest Off " +
                                    "    ZWrite Off Cull Off Fog { Mode Off } " +
                                    "    BindChannels {" +
                                    "      Bind \"vertex\", vertex Bind \"color\", color }" +
                                    "} } }");
            sLineMat.hideFlags = HideFlags.HideAndDontSave;
            sLineMat.shader.hideFlags = HideFlags.HideAndDontSave;
        }   
    }

    public static void DrawTiledFrames(int a_startX, int a_startZ, int a_widthX, int a_widthZ, int a_tileSize, Color a_color)
    {        
        if (a_widthX <= 0 || a_widthZ <= 0 || a_tileSize <= 0)
        {
            Debug.LogError("Invalid draw parameters.");
            return;
        }

        sLineMat.SetPass(0);
        
        GL.PushMatrix();

        GL.Begin(GL.LINES);
        GL.Color(a_color);

        for (int i = 0; i <= a_widthZ; i++)
        {
            for (int j = 0; j < a_widthX; j++)
            {
                GL.Vertex3(a_startX + j * a_tileSize, 0, a_startZ + i * a_tileSize);
                GL.Vertex3(a_startX + (j+1) * a_tileSize, 0, a_startZ + i * a_tileSize);
            }
        }

        for (int i = 0; i <= a_widthX; i++)
        {
            for (int j = 0; j < a_widthZ; j++)
            {
                GL.Vertex3(a_startX + i * a_tileSize, 0, a_startZ + j * a_tileSize);
                GL.Vertex3(a_startX + i * a_tileSize, 0, a_startZ + (j+1) * a_tileSize);
            }
        }

        GL.End();

        GL.PopMatrix();
    }

    public static void DrawSolidTiles(int a_startX, int a_startZ, int a_widthX, int a_widthZ, int a_tileSize, Color a_color)
    {
        if (a_widthX <= 0 || a_widthZ <= 0 || a_tileSize <= 0)
        {
            Debug.LogError("Invalid draw parameters.");
            return;
        }

        sLineMat.SetPass(0);

        GL.PushMatrix();

        GL.Begin(GL.TRIANGLE_STRIP);
        GL.Color(a_color);


        for (int i = a_startZ, imax = a_startZ + a_widthZ; i < imax; i++)
        {
            for (int j = a_startX, jmax = a_startX + a_widthX + 1; j < jmax; j++)
            {
                GL.Vertex3(j * a_tileSize, 0, (i+1) * a_tileSize);
                GL.Vertex3(j * a_tileSize, 0, i * a_tileSize);
            }
        }

        GL.End();

        GL.PopMatrix();
    }
}
