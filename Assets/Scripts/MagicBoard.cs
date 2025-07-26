using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MagicBoard : MonoBehaviour
{
    [SerializeField] private MouseFollower mouseFollower;
    [SerializeField] private TileManager tileManager;

    // Update Mousefollower Icon and Tilemanager Icon when Player Selects a New Magic Type
    public void MagicButton()
    {
        var pressedButton = EventSystem.current.currentSelectedGameObject;
        Sprite selectedSprite = pressedButton.GetComponent<Button>().image.sprite;

        mouseFollower.ChangeSprite(selectedSprite);
        tileManager.UpdateSelectedMagic(selectedSprite, pressedButton.name);
    }
}
