using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    public int health = 100;
    public int value = 50;
    public GameObject enemyPiecesPrefab;
    
    public void TakeDamage(int damage){
        health -= damage;
        if (health <= 0){
            EnemyDefeated();
        }
    }
    //敵人死亡(攻擊)
    void EnemyDefeated(){
        PlayerStatus.Money += value;
        DestroyEnemy();
    }
    //消除敵人
    public void DestroyEnemy(){
        Destroy(gameObject);
        GameObject enemyPieces = (GameObject)Instantiate(enemyPiecesPrefab, transform.position, transform.rotation);
        Destroy(enemyPieces, 1f);
    }

}
