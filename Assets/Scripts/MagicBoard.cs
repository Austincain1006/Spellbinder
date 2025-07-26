using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MagicBoard : MonoBehaviour
{
    [SerializeField] private MouseFollower mouseFollower;
    [SerializeField] private TileManager tileManager;

    public void MagicButton()
    {
        var pressedButton = EventSystem.current.currentSelectedGameObject;
        Debug.Log(pressedButton.name);
        

        mouseFollower.ChangeSprite(pressedButton.GetComponent<Button>().image.sprite);
        tileManager.UpdateSelectedMagic(pressedButton.GetComponent<Button>().image.sprite, pressedButton.name);

    }
}
