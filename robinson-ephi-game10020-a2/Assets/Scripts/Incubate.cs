using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Incubate : MonoBehaviour, EventInterface
{
    public bool hasBeenUsed = false;
    public static event EventHandler spawnCells;

    private void Start()
    {
        spawnCells?.Invoke(this, EventArgs.Empty);
    }

    public void OnInteract(PlayerController player)
    {
        Debug.Log("firing");
        if (!hasBeenUsed)
        {
            spawnCells?.Invoke(this, EventArgs.Empty);
            hasBeenUsed = true;
        }
    }
}
