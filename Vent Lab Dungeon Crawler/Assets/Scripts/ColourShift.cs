using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ApplyPalette;

public class ColourShift : MonoBehaviour, EventInterface
{
    public static event EventHandler pColourSwap;
    public static event EventHandler sColourSwap;
    public static event EventHandler tColourSwap;

    public enum Colour
    {
        Primary,
        Secondary,
        Tertiarty
    }

    public Colour toSwap = Colour.Primary;

    public void OnInteract(PlayerController player)
    {
        Debug.Log("Event Interface Fired");

        if (toSwap == Colour.Primary)
        {
            pColourSwap?.Invoke(this, EventArgs.Empty);
        }
        else if (toSwap == Colour.Secondary)
        {
            sColourSwap?.Invoke(this, EventArgs.Empty);
        }
        else if (toSwap == Colour.Tertiarty)
        {
            tColourSwap?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            Debug.Log("Colour Enum Is Null On" + this.name + "Fix That Yo!");
        }
    }
}