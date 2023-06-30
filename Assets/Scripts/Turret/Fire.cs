using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public Transform firePoint;
    private Transform target;
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    public bool isCoolDown = false;
    // Start is called before the first frame update
    void Start()
    {
        
    } 

    // Update is called once per frame
    void Update()
    {
        target = GetComponent<LookAtEnemy>().target;
        if (target != null && !isCoolDown){
            Shoot();
            StartCoroutine(CoolDown());
        }
    }

    public void Shoot(){
        //發射同時將target資料給Bullet
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, transform.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();
        bullet.GetTarget(target);
    }
    
    IEnumerator CoolDown(){
        isCoolDown = true;
        yield return new WaitForSeconds(1f / fireRate);
        isCoolDown = false;
    }
}
