using UnityEngine;
using UnityEngine.UI;
public class ScreenChanger : MonoBehaviour
{
    [SerializeField] private Button homepagebtn;
    [SerializeField] private Button profilepagebtn;
    [SerializeField] private GameObject profilePage;
    [SerializeField] private GameObject homePage;
    public void OnClickHomePageBtn()
    {
        profilePage.SetActive(false);
        homePage.SetActive(true);
    }

    public void OnClickProfilePageBtn()
    {
        homePage.SetActive(false);
        profilePage.SetActive(true);
    }
    
}
