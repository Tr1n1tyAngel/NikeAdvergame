using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public NPC[] npcs;
    public bool select = false;
    public void ShoeSelect()
    {
        GameManager.Instance.inventoryCanvas.SetActive(true);
        select = true;
    }
}
