using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattleMechanics : MonoBehaviour
{

    public Health health;
    
    public float damage;
    
    int weaponNum = 0 ;

   
    
    
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
        int a = Mathf.Max(Mathf.FloorToInt((3 * health.eHealthMax - 2 * GameManager.Instance.eHealth) / (3f * health.eHealthMax)), 1);

        int randomValue = UnityEngine.Random.Range(1, a + 1);
        if(randomValue == 1)
        {
            GameManager.Instance.caught = true;
        }
        if (GameManager.Instance.caught == true)
        {
            Win();
            //GameManager.Instance.shoeInventory.AddShoe();
            GameManager.Instance.caught = false;
        }
    }
  public void Run()
    {
        GameManager.Instance.weaponDropdown.SetActive(false);
        GameManager.Instance.upgradeMenu.SetActive(false);
        SceneManager.LoadScene("Shop");
    }

    public void EnemyAttack()
    {
        float rnd = 0;
        rnd= Random.Range(0, health.pHealthMax/2.5f);
        GameManager.Instance.pHealth -= rnd;

    }
    public void AttackEnemy()
    {
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
                    GameManager.Instance.pHealth++;
                    GameManager.Instance.pHealth = health.pHealthMax;
                    GameManager.Instance.upgradeMenu.SetActive(false);
                    SceneManager.LoadScene("Shop");
                    
                    break;
            }
        
    }

    private void Win()
    {
        GameManager.Instance.upgradeMenu.SetActive(true);
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
        Run();
        GameManager.Instance.encounter = false;
    }
    
}
