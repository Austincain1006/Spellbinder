using System;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ButtonScript : MonoBehaviour
{
    private MagicInspector magicInspector;
    private UnityEngine.UI.Image magicImage;

    void Start()
    {
        magicInspector = GameObject.FindGameObjectWithTag("InspectorTag").GetComponent<MagicInspector>();
        magicImage = GetComponent<UnityEngine.UI.Image>();
        Debug.Log(magicInspector);
    }

    public void OnMouseOverButton()
    {
        Debug.Log($"Mouse over button {this.name}!");
        magicInspector.SetProduct(magicImage.sprite);
    }

    public void OnMouseLeaveButton()
    {
        Debug.Log($"Mouse left button {this.name}!");
    }
}
