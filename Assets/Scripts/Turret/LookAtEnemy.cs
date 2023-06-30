using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtEnemy : MonoBehaviour
{
    public Transform target;
    public Transform partToRotate;
    public float reactionTime = 0.2f;
    public float attackRange = 15f;
    public float turnSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GetNearestTarget", 0f, reactionTime);  //在指定的延遲時間後重複調用指定的函數
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null){
            LookAtTarget();
        }
        else{
            return;
        }
    }

    //找到最近目標
    void GetNearestTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearestEnemy = null;
        float shortestDistance = Mathf.Infinity;
        foreach (GameObject enemy in enemies){
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= attackRange){
            target = nearestEnemy.transform;
            // targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else {
            target = null;
        }
    }

    //瞄準目標
    void LookAtTarget()
    {
        Vector3 directionToTarget = target.position - transform.position;
        Quaternion partRotation = Quaternion.LookRotation(directionToTarget);
        //在兩個旋轉之間平滑過渡
        Vector3 smoothRotation = Quaternion.Lerp(partToRotate.rotation, 
        partRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, smoothRotation.y, 0f);
    }

    //顯示攻擊範圍
    void OnDrawGizmosSelected()     //在Scene視圖中繪製調試或可視化信息的圖形元素
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
