using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private Image ElementHUDFire;

    [SerializeField] private Image ElementHUDWater;

    [SerializeField] private Image ElementHUDAir;  

    [SerializeField] private Image ElementHUDEarth;

    [SerializeField] private Image ElementHUDEmpty;

    [SerializeField] public Image infoEImage;

    [SerializeField] public Image infoZImage;

    [SerializeField] public Image infoFireEimage;

    [SerializeField] public Image infoWaterEimage;

    [SerializeField] public Image infoAirEimage;

    [SerializeField] public Image infoEarthEimage;

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

    /*public void ShowWaterHUD()
    {
        ElementHUDEmpty.enabled = false;
        ElementHUDWater.enabled = true;
    }

    public void HideWaterHUD()
    {
        ElementHUDEmpty.enabled = true;
        ElementHUDWater.enabled = false;
    }*/

    public void ShowAirHUD()
    {
        ElementHUDEmpty.enabled = false;
        ElementHUDAir.enabled = true;
    }

    public void HideAirHUD()
    {
        ElementHUDEmpty.enabled = true;
        ElementHUDAir.enabled = false;
    }

    public void ShowEarthHUD()
    {
        ElementHUDEmpty.enabled = false;
        ElementHUDEarth.enabled = true;
    }

    public void HideEarthHUD()
    {
        ElementHUDEmpty.enabled = true;
        ElementHUDEarth.enabled = false;
    }
}
