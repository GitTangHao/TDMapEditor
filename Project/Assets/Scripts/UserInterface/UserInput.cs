using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Camera)), DisallowMultipleComponent]
public class UserInput : MonoBehaviour 
{

    float mMoveSpeed;

    Vector3 mTranslate = Vector3.zero;

    Vector3 mMousePos = Vector3.zero;
    Vector3 mDeltaPos = Vector3.zero;

    Camera mCamera;

	void Start () 
    {
        mCamera = GetComponent<Camera>();
        mMousePos = Input.mousePosition;
        mMoveSpeed = 2.5f;
	}


    void Update()
    {
        updateMouse();
        updateMove();
        updateRotate();
    }

    void updateMouse()
    {
        mDeltaPos = Input.mousePosition - mMousePos;
        mMousePos = Input.mousePosition;
    }

    void updateMove()
    {
        mTranslate.x = mTranslate.y = mTranslate.z = 0;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            mMoveSpeed += Time.deltaTime * 4.0f;
            if (mMoveSpeed > 15f)
            {
                mMoveSpeed = 15f;
            }
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            mMoveSpeed -= Time.deltaTime * 4.0f;
            if (mMoveSpeed < 0.5f)
            {
                mMoveSpeed = 0.5f;
            }
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            mTranslate.z += mMoveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            mTranslate.x -= mMoveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            mTranslate.z -= mMoveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            mTranslate.x += mMoveSpeed * Time.deltaTime;
        }
        transform.Translate(mTranslate, Space.Self);
    }

    void updateRotate()
    {
        // button values are 0 for left button, 1 for right button, 2 for the middle button.
        if (Input.GetMouseButton(1) && !Input.GetMouseButtonDown(1))
        {
            float tRotateZ = .0f;
            if (Input.GetKey(KeyCode.Q))
            {
                tRotateZ = 0.3f;
            }
            else if (Input.GetKey(KeyCode.E))
            {
                tRotateZ = -0.3f;
            }
            transform.Rotate(-0.2f * mDeltaPos.y, 0.2f * mDeltaPos.x, tRotateZ, Space.Self);
        }
    }
	
	void OnPostRender ()
    {
        Ray tRay = mCamera.ScreenPointToRay(Input.mousePosition);

        float n = -tRay.origin.y / tRay.direction.y;
        Vector3 tPos = tRay.origin + tRay.direction * n;

        tPos.x = tPos.x >= 0 ? (int)tPos.x : (int)(tPos.x - 1);
        tPos.z = tPos.z >= 0 ? (int)tPos.z : (int)(tPos.z - 1);

        GLDraw.DrawSolidTiles((int)tPos.x, (int)tPos.z, 1, 1, 1, Color.blue);
	}

}
