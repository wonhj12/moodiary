using UnityEngine;
using UnityEngine.UI;

public class StatusManager : MonoBehaviour
{
    // Date element
    public GameObject selectedDate;
    DateElement dateElement;

    // Settings
    public Setting setting;

    // UI
    public Image goodBtn;
    public Image badBtn;
    public Image circleImg;
    public Image squareImg;

    void Start()
    {
        RefreshStatus();
    }

    // Good btn
    public void SelectGood()
    {
        if (selectedDate != null)
        {
            Good();

            // Set status
            dateElement = selectedDate.GetComponent<DateElement>();
            if (dateElement.status == 1)
                dateElement.SetStatus(0);   // If status is good remove status
            else
                dateElement.SetStatus(1);   // If status is 0 or 2 set to 1
            dateElement.SaveStatus();
        }
    }

    // Bad btn
    public void SelectBad()
    {
        if (selectedDate != null)
        {
            Bad();

            // Set status
            dateElement = selectedDate.GetComponent<DateElement>();
            if (dateElement.status == 2)
                dateElement.SetStatus(0);   // If status is bad remove status
            else
                dateElement.SetStatus(2);   // If status is 0 or 1 set to 2
            dateElement.SaveStatus();
        }
    }

    void Good()
    {
        // Set btn
        goodBtn.enabled = true;
        badBtn.enabled = false;
        circleImg.color = Color.white;
        squareImg.color = new Color32(117, 117, 117, 255);  // #757575
    }

    void Bad()
    {
        // Set btn
        badBtn.enabled = true;
        goodBtn.enabled = false;
        squareImg.color = Color.white;
        circleImg.color = new Color32(117, 117, 117, 255);  // #757575
    }


    public void RefreshStatus()
    {
        // Initialize btn colors
        goodBtn.color = setting.statusColors[1];
        badBtn.color = setting.statusColors[2];

        if (selectedDate != null)
        {
            if (selectedDate.GetComponent<DateElement>().status < 2)
                Good();
            else
                Bad();
        }
    }
}
