using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public NPC[] npcs;
    public bool select = false;
   

    public void Update()
    {
        

            
        
    }
    public void ShoeSelect()
    {
        AudioManager.instance.Play("Button");
        GameManager.Instance.inventoryCanvas.SetActive(true);
        select = true;

        
    }
}
