using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPanel : MonoBehaviour
{
    public void OnstartButtonClick()
    {

        if (UIManager.HasInstance)
        {
            UIManager.Instance.ActiveMenuPanel(false);
            UIManager.Instance.ActiveLoadingPanel(true);
        }

        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlayBGM("bgmLevel1", 0.5f);
        }
    }

    public void OnSettingButtonClick()
    {
        if (UIManager.HasInstance)
        {
            UIManager.Instance.ActiveSettingPanel(true);
        }
    }
}
