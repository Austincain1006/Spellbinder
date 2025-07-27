using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MagicBoard : MonoBehaviour
{
    [SerializeField] private MouseFollower mouseFollower;
    [SerializeField] private TileManager tileManager;
    //private ButtonScript[] magicButtons;
    public Dictionary<string, ButtonScript> magicButtons;


    void Start()
    {

        magicButtons = new Dictionary<string, ButtonScript>();
        print($"magicButton is {magicButtons}");
        foreach (var b in GetComponentsInChildren<ButtonScript>())
        {
            if (b != null)
            {
                print($"b in magicButtons is {b}, trying to access {b.magicImage.name}");
                magicButtons.Add(b.magicImage.name, b);
                print($"Added {b} to Magic Buttons dict");
                b.changeText("5");
            }
            
        }
    }

    // Update Mousefollower Icon and Tilemanager Icon when Player Selects a New Magic Type
    public void MagicButton()
    {
        var pressedButton = EventSystem.current.currentSelectedGameObject;
        Sprite selectedSprite = pressedButton.GetComponent<Button>().image.sprite;

        mouseFollower.ChangeSprite(selectedSprite);
        tileManager.UpdateSelectedMagic(selectedSprite, pressedButton.name);
    }

    public ButtonScript[] getButtons()
    {
        return GetComponentsInChildren<ButtonScript>();
    }

    public void updateButtonText(string buttonName, string value)
    {
        magicButtons[buttonName].changeText(value);
    }
}
