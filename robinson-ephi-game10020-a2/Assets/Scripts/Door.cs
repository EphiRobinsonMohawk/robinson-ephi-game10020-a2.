using System;
using UnityEngine;

public class Door : MonoBehaviour
{
    public ApplyPalette palette;
    public bool isOpening = false;
    public float closedAmmount = 100f;
    public SpriteRenderer thisSprite;

    void Start()
    {
        PaletteMan.openDoor += Open; //subscribing to the open door event
    }

    private void Update()
    {
        if (isOpening)
        {
            closedAmmount -= Time.deltaTime /3f; //open the door somewhat slowly over time
            closedAmmount = Mathf.Clamp01(closedAmmount); //prep numb to be alpha

            thisSprite.color = new Color(
                thisSprite.color.r,
                thisSprite.color.g,
                thisSprite.color.b,
                closedAmmount //fade alpha as door opens n closedAmmount goes down
            );
        }
    }

    void Open(object sender, EventArgs e)
    {
        isOpening = true;
        palette.enabled = false;
    }
}