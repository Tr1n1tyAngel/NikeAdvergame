using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float pHealth;
    public int[] weaponsDamage = new int[3];

    public PlayerData(GameManager gameManager)
    {
       pHealth= gameManager.pHealth;
        foreach(int weapon in weaponsDamage)
        {
            weaponsDamage[weapon] = gameManager.weaponsDamage[weapon];
        }
    }
}
