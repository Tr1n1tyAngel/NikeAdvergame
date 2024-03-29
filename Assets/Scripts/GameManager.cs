using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
[System.Serializable]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject battleCanvas;
    public GameObject inventoryCanvas;
    public GameObject npcCanvas;
    public GameObject mainCanvas;
    public GameObject playerHealthBar;
    public GameObject enemyHealthBar;
    public GameObject pHBFill;
    public GameObject eHBFill;
    public GameObject weaponDropdown;
    public GameObject upgradeMenu;
    public GameObject pauseMenu;
    public Button attackBtn;
    public Button weaponBtn;
    public Button catchBtn;
    public Button runBtn;
    public float pHealth;
    public float eHealth;
    public int[] weaponsDamage = new int[3];
    public bool win = false;
    public bool lose = false;
    public bool CH1 = false;
    public bool CH2 = false;
    public bool encounter = false;
   public bool caught= false;
    public ShoeInventory shoeInventory;
    public TextMeshProUGUI enemyName;
    public TextMeshProUGUI catchTxt;
    public EnemySpawn enemySpawn;
    public Image playerImage;
    public Sprite Character1;
    public Sprite Character2;
    public Image enemyImage;
    public Health health;
    public bool invMenu;
    public int countRemoved;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        pHealth = 100;
        eHealth = 100;
    }
    private void Start()
    {
        
        
        win = false;
        lose = false;
        
        weaponsDamage[0] = 50;
        weaponsDamage[1] = 25;
        weaponsDamage[2] = 15;
    }

    private void Update()
    {
        InventoryDisplay();
        
        if (encounter==true)
        {
            enemySpawn.GetRandomShoe();
            catchTxt.text = "";
            health.eHealthMax = 100;
            attackBtn.interactable = true;
            weaponBtn.interactable = true;
            catchBtn.interactable = true;
            runBtn.interactable = true;
            encounter = false;
        }
       
        if (SceneManager.GetActiveScene().name != "Shop")
        {
            pauseMenu.SetActive(false);
        }
        else
        {
            
            pauseMenu.SetActive(true);
            
        }

        if (SceneManager.GetActiveScene().name == "Shop")
        {
            upgradeMenu.SetActive(false);
            battleCanvas.SetActive(false);
            mainCanvas.SetActive(true);
            npcCanvas.SetActive(true);
            
            win = false;
            lose = false;
          
        }
        else if(SceneManager.GetActiveScene().name == "BattleScene")
        {
            npcCanvas.SetActive(false);
            inventoryCanvas.SetActive(false);
            mainCanvas.SetActive(false);
            battleCanvas.SetActive(true);
           

        }
        if (GameManager.Instance.CH1 == true)
        {
            playerImage.sprite= Character1;

        }
        else if (GameManager.Instance.CH2 == true)
        {
            playerImage.sprite=Character2;

        }
    }
    public void SavePlayerData()
    {
        AudioManager.instance.Play("Button");
        SaveSystem.SavePlayerData(this);
        Debug.Log("Data saved");
    }
    public void LoadPlayerData()
    {
        AudioManager.instance.Play("Button");
        PlayerData loadedData = SaveSystem.LoadPlayerData();
        if (loadedData != null)
        {
            health.pHealthMax = loadedData.pHealth;
            pHealth = loadedData.pHealth;
            weaponsDamage = loadedData.weaponsDamage;
            CH1 = loadedData.CH1;
            CH2 = loadedData.CH2;
            shoeInventory.shoes= new List<Shoe>(loadedData.shoes);
            countRemoved = loadedData.countRemoved;

            
        }
        else
        {
            Debug.LogError("Failed to load data");
        }
        SceneManager.LoadScene("Shop");
    }
    public void InventoryDisplay()
    {
        if (Input.GetKeyDown(KeyCode.I) && invMenu)
        {
            npcCanvas.SetActive(false);
            inventoryCanvas.SetActive(true);
            invMenu = false;
        }
        else if (Input.GetKeyDown(KeyCode.I) && !invMenu)
        {
            npcCanvas.SetActive(false);
            inventoryCanvas.SetActive(false);
            invMenu = true;
        }
    }
}
