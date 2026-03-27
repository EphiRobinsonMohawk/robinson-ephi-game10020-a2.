using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GameMan : MonoBehaviour
{
    public GameObject cellPrefab;
    public static PlayerController player;
    



    void Awake()
    {
        Incubate.spawnCells += Spawn;
    }

    void Spawn(object sender, EventArgs e)
    {
        for (int i = 0; i < 3; i++)
        {
            Vector3 spawnPos = new Vector3(
                player.transform.position.x + UnityEngine.Random.Range(-1.6f, 1.6f),
                player.transform.position.y + UnityEngine.Random.Range(-1.6f, 1.6f),
                player.transform.position.z
            );

            Instantiate(cellPrefab, spawnPos, Quaternion.identity);
        }
    }
}
