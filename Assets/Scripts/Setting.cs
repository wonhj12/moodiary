using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Setting : MonoBehaviour
{
    [Header("Color settings")]
    public Color32[] statusColors = new Color32[3]; // 0 - default, 1 - good, 2 - bad

    [Header("Color area settings")]
    public GameObject[] possibleColors;
    public Image selectImg;
    public Image circleImg;
    public Image squareImg;
    public int goodIndex = 0;
    public int badIndex = 3;
    public bool status = true;  // true - good, false - bad

    [Header("App area settings")]
    public GameObject resetPanel;
    public Text versionTxt;

    void Awake()
    {
        RefreshSetting();

        // Version
        versionTxt.text = Application.version;
    }

    public void RefreshSetting()
    {
        // Load settings
        SettingData settingData = SaveSetting.SettingLoad();

        if (settingData != null)
        {
            goodIndex = settingData.goodIndex;
            badIndex = settingData.badIndex;
        }
        else
        {
            // Default
            goodIndex = 0;
            badIndex = 3;
        }

        statusColors[1] = possibleColors[goodIndex].GetComponent<Image>().color;    // change color
        statusColors[2] = possibleColors[badIndex].GetComponent<Image>().color;    // change color

        circleImg.transform.position = possibleColors[goodIndex].transform.position;
        squareImg.transform.position = possibleColors[badIndex].transform.position;
    }

    // Good btn
    public void SelectGood()
    {
        status = true;
        selectImg.transform.position = EventSystem.current.currentSelectedGameObject.transform.position;
    }

    // Bad btn
    public void SelectBad()
    {
        status = false;
        selectImg.transform.position = EventSystem.current.currentSelectedGameObject.transform.position;
    }

    // Color select settings
    public void SelectColor()
    {
        int temp = int.Parse(EventSystem.current.currentSelectedGameObject.name);

        if (status) // good
        {
            if (badIndex != temp)
            {
                goodIndex = temp;   // Change color index
                statusColors[1] = possibleColors[goodIndex].GetComponent<Image>().color;    // change color
                circleImg.transform.position = EventSystem.current.currentSelectedGameObject.transform.position;
            }
        }
        else    // bad
        {
            if (goodIndex != temp)
            {
                badIndex = temp;   // Change color index
                statusColors[2] = possibleColors[badIndex].GetComponent<Image>().color;    // change color
                squareImg.transform.position = EventSystem.current.currentSelectedGameObject.transform.position;
            }
        }

        SaveSetting.SettingSave(goodIndex, badIndex);
    }

    // App Settings
    public void ResetBtn()
    {
        resetPanel.SetActive(true);
    }

    public void ResetCancel()
    {
        resetPanel.SetActive(false);
    }

    public void ResetOK()
    {
        ResetData();
        resetPanel.SetActive(false);
    }

    void ResetData()
    {
        foreach (string file in Directory.GetFiles(Application.persistentDataPath))
        {
            FileInfo fileInfo = new FileInfo(file);
            fileInfo.Delete();
        }

        RefreshSetting();
    }
}
