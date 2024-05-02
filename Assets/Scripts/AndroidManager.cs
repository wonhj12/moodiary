using UnityEngine;

public class AndroidManager : MonoBehaviour
{
    PageSwitch pageSwitch;

    void Start()
    {
        pageSwitch = GetComponent<PageSwitch>();
    }

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
            if (Input.GetKeyDown(KeyCode.Escape))
                if (pageSwitch.home)
                    Application.Quit();     // Back btn quit
                else
                    pageSwitch.HomeBtn();
    }
}
