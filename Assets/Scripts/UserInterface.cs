using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    [SerializeField] private GameObject winButton;
    [SerializeField] public MagicBoard magicBoard;
    [SerializeField] public BuyMenu buyMenu;
    [SerializeField] public MouseFollower mouseFollower;
    

    void Start()
    {
        SetWinButtonVisible(false);
        ToggleBuyMenu();
    }

    public void DisplayWinScreen()
    {
        Debug.Log($"CONGRATULATIONS, YOU WON! :D");
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

    
}
