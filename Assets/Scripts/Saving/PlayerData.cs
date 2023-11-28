using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float pHealth;
    public int[] weaponsDamage = new int[3];
    public bool CH1 = false;
    public bool CH2= false;

    public PlayerData(GameManager gameManager)
    {
       pHealth= gameManager.pHealth;
        for (int i = 0; i < 3; i++)
        {
            weaponsDamage[i] = gameManager.weaponsDamage[i];
        }
        CH1= gameManager.CH1;
        CH2= gameManager.CH2;
    }
}
