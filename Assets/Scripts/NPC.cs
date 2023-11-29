using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
[System.Serializable]
public class NPC : MonoBehaviour
{
    
    [SerializeField] public GameObject dialogueCanvas;
    [SerializeField] public TextMeshProUGUI dialogueText;
    [SerializeField] public string dialogue;
     
    [SerializeField] public bool playerNearby;
    [SerializeField] bool firstMenu = true;
    [SerializeField] public string[] shoe;
    public int rnd;

    // Start is called before the first frame update
    void Start()
    {
        dialogueText.text = "";
        RandomShoe();

    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerNearby) 
        { 
            if (dialogueCanvas.activeSelf && !firstMenu)
            {
                
                firstMenu = true;
                dialogueText.text = "";
                dialogueCanvas.SetActive(false);
                GameManager.Instance.inventoryCanvas.SetActive(false);

            }
            else if(!dialogueCanvas.activeSelf && firstMenu) 
            {
                
                firstMenu = false;
                dialogueText.text = "The shoe i want is: " + shoe[rnd];
                dialogueCanvas.SetActive(true);





            }
        }
    }
    
   
    void RandomShoe()
    {
        rnd = Random.Range(0, 4);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerNearby = true;
            
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            firstMenu = true;
            dialogueText.text = "";
            dialogueCanvas.SetActive(false);

        }
    }
}
