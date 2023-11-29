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
        int shiny = Random.Range(0, 2);
        rnd = Random.Range(0, enemyShoes.Count);
        GameManager.Instance.enemyName.text = enemyShoes[rnd].Base.Name;
        if(shiny ==0)
        {
            GameManager.Instance.enemyImage.sprite=enemyShoes[rnd].Base.ShinySprite;
        }
        else
        {
            GameManager.Instance.enemyImage.sprite = enemyShoes[rnd].Base.ShoeSprite;
        }
        return enemyShoes[rnd];
      
    }
}
