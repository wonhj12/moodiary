using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Language : MonoBehaviour
{
    public string[] languageList;
    int languageIndex;

    [Header("Calendar")]
    public Text[] days;
    public Text homeC;
    public Text settingsC;
    public string[] yearStr;
    public string[] cultureStr;
    public DatesCreator datesCreator;

    [Header("Settings")]
    public Text settingTitle;
    public Text colorSetting;
    public Text languageText;
    public Text languageName;
    public Text appSetting;
    public Text appVersion;
    public Text reset;
    public Text homeS;
    public Text settingsS;

    [Header("Reset")]
    public Text resetText;
    public Text resetCancel;
    public Text resetYes;

    void Awake()
    {
        if (!PlayerPrefs.HasKey("language"))
        {
            for (int i = 0; i < languageList.Length; i++)
            {
                if (Application.systemLanguage.ToString() == languageList[i])
                {
                    Debug.Log(Application.systemLanguage);
                    PlayerPrefs.SetInt("language", i);
                }
            }
        }

        languageIndex = PlayerPrefs.GetInt("language");
        ChangeLanguage();
    }

    void ChangeLanguage()
    {
        if (languageIndex == 0)
        {
            // Calendar
            days[0].text = "일";
            days[1].text = "월";
            days[2].text = "화";
            days[3].text = "수";
            days[4].text = "목";
            days[5].text = "금";
            days[6].text = "토";
            homeC.text = "홈";
            settingsC.text = "설정";

            // Settings
            settingTitle.text = "설정";
            colorSetting.text = "색 설정";
            languageText.text = "언어";
            languageName.text = "한국어";
            appSetting.text = "앱 설정";
            appVersion.text = "앱 버전";
            reset.text = "초기화";
            homeS.text = "홈";
            settingsS.text = "설정";

            // Reset
            resetText.text = "초기화 하시겠습니까?";
            resetCancel.text = "취소";
            resetYes.text = "확인";
        }
        else
        {
            // Calendar
            days[0].text = "Sun";
            days[1].text = "Mon";
            days[2].text = "Tue";
            days[3].text = "Wed";
            days[4].text = "Thu";
            days[5].text = "Fri";
            days[6].text = "Sat";
            homeC.text = "Home";
            settingsC.text = "Settings";

            // Settings
            settingTitle.text = "Settings";
            colorSetting.text = "Color Settings";
            languageText.text = "Language";
            languageName.text = "English";
            appSetting.text = "App Settings";
            appVersion.text = "App Version";
            reset.text = "Reset";
            homeS.text = "Home";
            settingsS.text = "Settings";

            // Reset
            resetText.text = "Reset Data?";
            resetCancel.text = "Cancel";
            resetYes.text = "Confirm";
        }

        // Dates
        datesCreator.cultureStr = cultureStr[languageIndex];
        datesCreator.yearStr = yearStr[languageIndex];
    }

    public void NextLanguage()
    {
        languageIndex++;
        if (languageIndex >= languageList.Length)
            languageIndex = 0;
        PlayerPrefs.SetInt("language", languageIndex);
        ChangeLanguage();
    }
}
