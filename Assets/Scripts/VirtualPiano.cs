using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VirtualPiano : MonoBehaviour
{
    public VirtualButtonBehaviour[] buttons;
    public AudioSource[] audios;
    public Material defaultMaterial;
    public Material pressedMaterial;
    void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].RegisterOnButtonPressed(OnButtonDown);
            buttons[i].RegisterOnButtonReleased(OnButtonRelease);
            buttons[i].GetComponent<MeshRenderer>().SetMaterials(new List<Material> { defaultMaterial });
        }
    }
    private void OnButtonRelease(VirtualButtonBehaviour button)
    {
        button.GetComponent<MeshRenderer>().SetMaterials(new List<Material> { defaultMaterial });
    }
    private void OnButtonDown(VirtualButtonBehaviour button)
    {
        button.GetComponent<MeshRenderer>().SetMaterials(new List<Material> { pressedMaterial });
        switch (button.VirtualButtonName)
        {
            case "1":
                audios[0].Play();
                break;
            case "2":
                audios[1].Play();
                break;
            case "3":
                audios[2].Play();
                break;
            case "4":
                audios[3].Play();
                break;
            case "5":
                audios[4].Play();
                break;
            case "6":
                audios[5].Play();
                break;
            case "7":
                audios[6].Play();
                break;
            default:
                break;
        }
    }
    private void OnDestroy()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].UnregisterOnButtonPressed(OnButtonDown);
            buttons[i].UnregisterOnButtonReleased(OnButtonRelease);
        }
    }
}
