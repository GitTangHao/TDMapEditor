using UnityEngine;
using System.Collections;

public class UserInput : MonoBehaviour 
{
    Camera mCamera;

	void Start () 
    {
        mCamera = GetComponent<Camera>();
	}
	
	void OnPostRender () 
    {
        Ray tRay = mCamera.ScreenPointToRay(Input.mousePosition);

        float n = -tRay.origin.y / tRay.direction.y;
        Vector3 tPos = tRay.origin + tRay.direction * n;
        GLDraw.DrawSolidTiles((int)tPos.x, (int)tPos.z, 1, 1, 1, Color.blue);
	}

}
