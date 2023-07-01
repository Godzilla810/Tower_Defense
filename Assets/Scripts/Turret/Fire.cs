using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public Transform firePoint;
    private Transform target;

    public bool isBullet = true;
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    public bool isCoolDown = false;

    public bool isLaser = false;
    public LineRenderer linerenderer;
    public ParticleSystem laserEffect;
    
    // Start is called before the first frame update
    void Start()
    {
        
    } 

    // Update is called once per frame
    void Update()
    {
        target = GetComponent<LookAtEnemy>().target;
        if (target == null || isCoolDown){
            if (isLaser){
                laserEffect.Stop();
                linerenderer.enabled = false;
            }
            return;
        }
        else{
            if(isBullet){
                Shoot();
                StartCoroutine(CoolDown());
            }
            else{
                Laser();
            }
            
        }
    }

    public void Shoot(){
        //發射同時將target資料給Bullet
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, 
        firePoint.position, transform.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();
        bullet.GetTarget(target);
    }
    
    public void Laser(){
        if(linerenderer.enabled == false){
            linerenderer.enabled = true;
            laserEffect.Play();
        }
        linerenderer.SetPosition(0, firePoint.position);
        linerenderer.SetPosition(1, target.position);
        laserEffect.transform.position = target.position;
        laserEffect.transform.rotation = Quaternion.LookRotation(
            firePoint.position - target.position);
    }

    IEnumerator CoolDown(){
        isCoolDown = true;
        yield return new WaitForSeconds(1f / fireRate);
        isCoolDown = false;
    }
}
