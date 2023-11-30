using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[System.Serializable]
public class BattleMechanics : MonoBehaviour
{

    public Health health;
    
    public float damage;
    
    int weaponNum = 0 ;
    public float randomValue;
    public float catchChance;



    private void Start()
    {
        damage = 5;
        GameManager.Instance.weaponDropdown.SetActive(false);
        GameManager.Instance.upgradeMenu.SetActive(false);
    }

    private void FixedUpdate()
    {
        if(SceneManager.GetActiveScene().name == "BattleScene" &&  GameManager.Instance.win == false)
        {
            GameManager.Instance.upgradeMenu.SetActive(false);
        }
        if(GameManager.Instance.win == true&& GameManager.Instance.lose !=true && GameManager.Instance.upgradeMenu != null)
        {

            Win();

        }
        if (GameManager.Instance.lose == true && GameManager.Instance.win != true)
        {
            Lose();
        }
        
    }
    public void AttackBtn()
    {
        AudioManager.instance.Play("Button");
        GameManager.Instance.attackBtn.interactable = false;
        if(weaponNum==0)
        {
            AttackEnemy();
            EnemyAttack();
            Invoke("AttackFix", 1);
        }
        if (weaponNum == 1)
        {
            EnemyAttack();
            Invoke("EnemyAttack", 1);
            Invoke("AttackEnemy", 2);
            Invoke("AttackFix", 3);
        }
        if (weaponNum == 2)
        {
            AttackEnemy();
            EnemyAttack();
            Invoke("AttackFix", 1);
        }
        if (weaponNum == 3)
        {
            AttackEnemy();
            Invoke("AttackEnemy", 1);
            Invoke("EnemyAttack", 2);
            Invoke("AttackFix", 3);
        }

    }
    public void Weapon()
    {
        AudioManager.instance.Play("Button");
        GameManager.Instance.weaponDropdown.SetActive(true);
        
        
    }
    public void setWeapon(int weaponChosen)
    {
        if (weaponChosen == 0)
        {
            weaponNum = 0;
            damage = 5;
        }
        if (weaponChosen == 1)
        {
            weaponNum = 1;
            
            damage = GameManager.Instance.weaponsDamage[0];
        }
        if (weaponChosen == 2)
        {
            weaponNum = 2;
            damage = GameManager.Instance.weaponsDamage[1];
        }
        if (weaponChosen == 3)
        {
            weaponNum = 3;
            damage = GameManager.Instance.weaponsDamage[2];
        }

        GameManager.Instance.weaponDropdown.SetActive(false);
    }
    public void Catch()
    {
        AudioManager.instance.Play("Button");
        catchChance = ((float)(health.eHealthMax - GameManager.Instance.eHealth) / health.eHealthMax) * 100;

        randomValue = UnityEngine.Random.Range(0f, 100f);
        if (randomValue<=catchChance)
        {
            GameManager.Instance.caught = true;
        }
        else
        {
            GameManager.Instance.caught = false;
        }
        if (GameManager.Instance.caught == true)
        {
            GameManager.Instance.win = true;
            GameManager.Instance.shoeInventory.AddShoe(GameManager.Instance.enemySpawn.enemyShoes[GameManager.Instance.enemySpawn.rnd]);
            GameManager.Instance.catchTxt.text = "You caught " + GameManager.Instance.enemyName.text + ", well done!";
            Win();
            GameManager.Instance.caught = false;
        }
        else if(GameManager.Instance.caught == false)
        {
            GameManager.Instance.catchTxt.text = "You did not catch " + GameManager.Instance.enemyName.text + ", damage it and try again.";
            EnemyAttack();
        }

    }
  public void Run()
    {
        AudioManager.instance.Play("Button");
        GameManager.Instance.weaponDropdown.SetActive(false);
        GameManager.Instance.upgradeMenu.SetActive(false);
        SceneManager.LoadScene("Shop");
    }

    public void EnemyAttack()
    {
        float rnd = 0;
        rnd= Random.Range(0, 50);
        GameManager.Instance.pHealth -= rnd;

    }
    public void AttackEnemy()
    {
        AudioManager.instance.Play("Attack");
        GameManager.Instance.eHealth -= damage;
    }
    void AttackFix()
    {
        GameManager.Instance.attackBtn.interactable = true;
    }
    public void Upgrade(int upgradeChoice)
    {
        
        
            switch (upgradeChoice)
            {
                case 0:

                    break;
                case 1:
                    health.pHealthMax++;
                    GameManager.Instance.pHealth = health.pHealthMax;
                    GameManager.Instance.upgradeMenu.SetActive(false);
                    SceneManager.LoadScene("Shop");


                    break;
                case 2:
                    GameManager.Instance.weaponsDamage[0]++;
                    GameManager.Instance.pHealth = health.pHealthMax;
                    GameManager.Instance.upgradeMenu.SetActive(false);
                    SceneManager.LoadScene("Shop");

                    break;
                case 3:
                    GameManager.Instance.weaponsDamage[1]++;
                    GameManager.Instance.pHealth = health.pHealthMax;
                    GameManager.Instance.upgradeMenu.SetActive(false);
                    SceneManager.LoadScene("Shop");

                    break;
                case 4:
                    GameManager.Instance.weaponsDamage[2]++;
                    GameManager.Instance.pHealth = health.pHealthMax;
                    GameManager.Instance.upgradeMenu.SetActive(false);
                    SceneManager.LoadScene("Shop");

                    break;
                default:
                    health.pHealthMax++;
                    GameManager.Instance.pHealth = health.pHealthMax;
                    GameManager.Instance.upgradeMenu.SetActive(false);
                    SceneManager.LoadScene("Shop");
                    
                    break;
            }
        
    }

    private void Win()
    {
        GameManager.Instance.upgradeMenu.SetActive(true);
        GameManager.Instance.attackBtn.interactable = false;
        GameManager.Instance.weaponBtn.interactable = false;
        GameManager.Instance.catchBtn.interactable = false;
        GameManager.Instance.runBtn.interactable = false;
        GameManager.Instance.lose = false;
        GameManager.Instance.eHealth = health.eHealthMax;
        GameManager.Instance.weaponDropdown.SetActive(false);
        GameManager.Instance.encounter = false;

    }
    private void Lose()
    {
        GameManager.Instance.win = false;
        GameManager.Instance.eHealth = health.eHealthMax;
        GameManager.Instance.pHealth = health.pHealthMax;
        Downgrade();
        GameManager.Instance.encounter = false;
    }
    
    private void Downgrade()
    {
        int rnd = Random.Range(1, 5);
        switch (rnd)
        {
            
            case 1:
                health.pHealthMax--;
                GameManager.Instance.pHealth = health.pHealthMax;
                GameManager.Instance.upgradeMenu.SetActive(false);
                SceneManager.LoadScene("Shop");


                break;
            case 2:
                GameManager.Instance.weaponsDamage[0]--;
                GameManager.Instance.pHealth = health.pHealthMax;
                GameManager.Instance.upgradeMenu.SetActive(false);
                SceneManager.LoadScene("Shop");

                break;
            case 3:
                GameManager.Instance.weaponsDamage[1]--;
                GameManager.Instance.pHealth = health.pHealthMax;
                GameManager.Instance.upgradeMenu.SetActive(false);
                SceneManager.LoadScene("Shop");

                break;
            case 4:
                GameManager.Instance.weaponsDamage[2]--;
                GameManager.Instance.pHealth = health.pHealthMax;
                GameManager.Instance.upgradeMenu.SetActive(false);
                SceneManager.LoadScene("Shop");

                break;
            default:
                health.pHealthMax--;
                GameManager.Instance.pHealth = health.pHealthMax;
                GameManager.Instance.upgradeMenu.SetActive(false);
                SceneManager.LoadScene("Shop");

                break;
        }
    }
}
