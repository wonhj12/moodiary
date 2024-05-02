using UnityEngine;

public class PageSwitch : MonoBehaviour
{
    public Canvas calendarCanvas;
    public Canvas settingCanvas;

    public CalendarManager calendarManager;
    public StatusManager statusManager;
    public Setting setting;

    public bool home = true;    // true - home, false - settings

    public void HomeBtn()
    {
        home = true;

        calendarCanvas.enabled = true;
        settingCanvas.enabled = false;

        calendarManager.ChangeMonth(0);
        statusManager.RefreshStatus();
    }

    public void SettingBtn()
    {
        home = false;

        settingCanvas.enabled = true;
        calendarCanvas.enabled = false;

        setting.RefreshSetting();
    }
}
