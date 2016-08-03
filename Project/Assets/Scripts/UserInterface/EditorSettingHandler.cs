using UnityEngine;
using System.Collections;

public class EditorSettingHandler : MonoBehaviour 
{
    public UIToggle mToggleDrawFrames;

    public void onDrawTiledFrames()
    {
        EditorSetting.sDrawTiledFrame = mToggleDrawFrames.value;
    }

    public void onSave()
    {
        EditorSetting.Save();
    }

    public void onCancel()
    {
        EditorSetting.Load();
    }

    public void refreshSettings()
    {
        mToggleDrawFrames.value = EditorSetting.sDrawTiledFrame;
    }
	
}
