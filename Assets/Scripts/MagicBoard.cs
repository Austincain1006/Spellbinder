using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MagicBoard : MonoBehaviour
{
    [SerializeField] private MouseFollower mouseFollower;

    public void MagicButton()
    {
        var pressedButton = EventSystem.current.currentSelectedGameObject;
        Debug.Log(pressedButton.name);
        //mouseFollower.GetComponent<SpriteRenderer>().sprite = pressedButton.GetComponent<Button>().image.sprite;

        mouseFollower.ChangeSprite(pressedButton.GetComponent<Button>().image.sprite);
        
        
    }
}
