using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaletteMan : MonoBehaviour
{
    public GameObject door;
    bool doorOpened = false;
    public static Color primaryColor;
    public static Color secondaryColor;
    public static Color tertiaryColor;
    public float paletteColourSeperation = 0.15f;
    public float pMinHue = 0f, pMaxHue = 1f, pMinSat = 0.4f, pMaxSat = 1f;
    public float sMinHue = 0f, sMaxHue = 1f, sMinSat = 0.4f, sMaxSat = 1f;
    public float tMinHue = 0f, tMaxHue = 1f, tMinSat = 0.4f, tMaxSat = 1f;
    float pHPalette = 0f, pSPalette = 0f, pVPalette = 0f;
    float sHPalette = 0f, sSPalette = 0f, sVPalette = 0f;
    float tHPalette = 0f, tSPalette = 0f, tVPalette = 0f;


    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        NewPrimaryColour(); 
        NewSecondaryColour();
        NewTertiaryColour();

        SeparatePalette(); //make sure 2 colours don't start too close together
    }

    void Start()
    {
        ColourShift.pColourSwap += SwapP; //subscribing to the primary colour swap event
        ColourShift.sColourSwap += SwapS; //subscribing to the secondary colour swap event
        ColourShift.tColourSwap += SwapT; //subscribing to the tertiary colour swap event    
    }

    void Update()
    {
        if (doorOpened) return;

        float ps = Mathf.Abs(pHPalette - sHPalette); //get difference between 2 hues
        float st = Mathf.Abs(sHPalette - tHPalette);
        float pt = Mathf.Abs(pHPalette - tHPalette);

        if (ps <= paletteColourSeperation && //if distance between all 3 is low enough open the door.
            st <= paletteColourSeperation &&
            pt <= paletteColourSeperation)
        {
            doorOpened = true;
            OpenDoor();
        }
    }

    void OpenDoor()
    {
        door.SetActive(false);
    }


    void SwapP(object sender, EventArgs e)
    {
        NewPrimaryColour();
    }

    void SwapS(object sender, EventArgs e)
    {
        NewSecondaryColour();
    }

    void SwapT(object sender, EventArgs e)
    {
        NewTertiaryColour();
    }


    void NewPrimaryColour()
    {
        primaryColor = UnityEngine.Random.ColorHSV(
            pMinHue, pMaxHue,   // Hue range
            pMinSat, pMaxSat, // Saturation
            0f, 1f  // Value (not used)
        );
        Color.RGBToHSV(primaryColor, out pHPalette, out pSPalette, out pVPalette);
    }

    void NewSecondaryColour()
    {
        secondaryColor = UnityEngine.Random.ColorHSV(
            sMinHue, sMaxHue,
            sMinSat, sMaxSat,
            0f, 1f
        );
        Color.RGBToHSV(secondaryColor, out sHPalette, out sSPalette, out sVPalette);
    }

    void NewTertiaryColour()
    {
        tertiaryColor = UnityEngine.Random.ColorHSV(
            tMinHue, tMaxHue,
            tMinSat, tMaxSat,
            0f, 1f
        );
        Color.RGBToHSV(tertiaryColor, out tHPalette, out tSPalette, out tVPalette);
    }

    void SeparatePalette()
    {
        while (Mathf.Abs(pHPalette - sHPalette) <= paletteColourSeperation)
            NewSecondaryColour();

        while (Mathf.Abs(sHPalette - tHPalette) <= paletteColourSeperation ||
            Mathf.Abs(pHPalette - tHPalette) <= paletteColourSeperation)
            NewTertiaryColour();
    }
}


