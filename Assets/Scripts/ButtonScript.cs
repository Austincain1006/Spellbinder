using System;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ButtonScript : MonoBehaviour
{
    private MagicInspector magicInspector;
    private UnityEngine.UI.Image magicImage;
    private TextMeshProUGUI textObject;

    void Start()
    {
        textObject = GetComponentInChildren<TextMeshProUGUI>();
        Debug.Log($"TEXTOBJECT IS {textObject}");
        magicInspector = GameObject.FindGameObjectWithTag("InspectorTag").GetComponent<MagicInspector>();
        magicImage = GetComponent<UnityEngine.UI.Image>();
        Debug.Log(magicInspector);
    }

    public void OnMouseOverButton()
    {
        //Debug.Log($"Mouse over button {this.name}!");
        magicInspector.SetProduct(magicImage.sprite);
    }

    public void OnMouseLeaveButton()
    {
        //Debug.Log($"Mouse left button {this.name}!");
    }

    public void changeText(string s)
    {
        textObject.text = s;
    }
}
