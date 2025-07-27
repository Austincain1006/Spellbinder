using UnityEngine;

public class UserInterface : MonoBehaviour
{
    [SerializeField] private GameObject winButton;
    [SerializeField] public MagicBoard magicBoard;
    [SerializeField] public BuyMenu buyMenu;
    [SerializeField] public MouseFollower mouseFollower;
    [SerializeField] private GameObject winScreen;


    void Start()
    {
        SetWinButtonVisible(false);
        ToggleBuyMenu();
        HideWinScreen();
    }

    

    public void SetWinButtonVisible(bool b)
    {
        winButton.gameObject.SetActive(b);
    }

    public void ToggleBuyMenu()
    {
        buyMenu.gameObject.SetActive(!buyMenu.isActiveAndEnabled);
        print("Show me the buy menu!");
    }

    public void ShowWinScreen()
    {
        winScreen.SetActive(true);
    }

    public void HideWinScreen()
    {
        winScreen.SetActive(false);
    }

}
