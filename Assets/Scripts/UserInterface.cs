using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    [SerializeField] private GameObject winButton;

    void Start()
    {
        SetWinButtonVisible(false);
    }

    public void DisplayWinScreen()
    {
        Debug.Log($"CONGRATULATIONS, YOU WON! :D");
    }

    public void SetWinButtonVisible(bool b)
    {
        winButton.gameObject.SetActive(b);
    }
}
