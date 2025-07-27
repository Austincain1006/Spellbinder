using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MagicBoard : MonoBehaviour
{
    [SerializeField] private MouseFollower mouseFollower;
    [SerializeField] private TileManager tileManager;
    private ButtonScript[] magicButtons;


    void Start()
    {
        magicButtons = GetComponentsInChildren<ButtonScript>();
        foreach (var b in magicButtons)
        {
            print($"I have this: {b.name}");
            b.changeText("5");
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


}
