using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private Image ElementHUDFire;

    [SerializeField] private Image ElementHUDEmpty;

    [SerializeField] public Image infoEImage;

    public static HUD instance;

    private void Awake()
    {
        instance = this;
    }

    public void ShowFireHUD()
    {
        ElementHUDEmpty.enabled = false;
        ElementHUDFire.enabled = true;
    }

    public void HideFireHUD()
    {
        ElementHUDEmpty.enabled = true;
        ElementHUDFire.enabled = false;
    }
}
