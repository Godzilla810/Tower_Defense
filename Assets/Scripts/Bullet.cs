using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 40.0f;
    private LookAtEnemy lookAtEnemy;
    private Transform target;
    public GameObject bulletPiecesPrefab;
    // Start is called before the first frame update
    void Start()
    {
        lookAtEnemy = GameObject.Find("Turret").GetComponent<LookAtEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        target = lookAtEnemy.target;
        if (target != null){
            Vector3 fireDirection = target.position - transform.position;
            transform.Translate(fireDirection.normalized * Time.deltaTime * speed, Space.World);
        }
        else{
            Destroy(gameObject);
            return;
        }
    }

    void OnTriggerEnter(Collider other) {
        Destroy(other.gameObject);
        Destroy(gameObject);
        GameObject bulletPieces = (GameObject)Instantiate(bulletPiecesPrefab, transform.position, transform.rotation);
        Destroy(bulletPieces, 1f);
    }
}
