using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class EnemySpawn : MonoBehaviour
{
    [SerializeField] public List<Shoe> enemyShoes;
    public int rnd;
    
    public Shoe GetRandomShoe()
    {
        int shiny = Random.Range(1, 4097);
        rnd = Random.Range(0, enemyShoes.Count);
        
        if(shiny ==1)
        {
            GameManager.Instance.enemyName.text = enemyShoes[rnd].Base.Name+"*";
            enemyShoes[rnd].Base.Name = enemyShoes[rnd].Base.Name + "*";
            GameManager.Instance.enemyImage.sprite=enemyShoes[rnd].Base.ShinySprite;
        }
        else
        {
            GameManager.Instance.enemyName.text = enemyShoes[rnd].Base.Name;
            GameManager.Instance.enemyImage.sprite = enemyShoes[rnd].Base.ShoeSprite;
        }
        return enemyShoes[rnd];
      
    }
}
