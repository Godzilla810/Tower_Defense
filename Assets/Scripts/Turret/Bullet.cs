using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 40.0f;
    public int damage = 50;
    public float explosionRadius = 0f;
    private Transform target;
    public GameObject bulletPiecesPrefab;
    
    public void GetTarget(Transform _target){
        target = _target;
    }

    void Update()
    {
        if (target != null){
            Vector3 fireDirection = target.position - transform.position;
            transform.Translate(fireDirection.normalized * Time.deltaTime * speed, Space.World);
        }
        else{
            Destroy(gameObject);
            return;
        }
        transform.LookAt(target);
    } 

    void OnTriggerEnter(Collider other) {
        Explode();
        Destroy(gameObject);
        GameObject bulletPieces = (GameObject)Instantiate(bulletPiecesPrefab, transform.position, transform.rotation);
        Destroy(bulletPieces, 1f);
    }
    
    void Explode(){
        Collider[] enemiesInAttackRange = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider other in enemiesInAttackRange){
            if (other.tag == "Enemy"){
                Damage(other.transform);
            }
        }
    }
    void Damage(Transform enemy){
        EnemyStatus enemyScript = enemy.GetComponent<EnemyStatus>();
        if (enemyScript != null){
            enemyScript.TakeDamage(damage);
        }
    }

    void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, explosionRadius);
	}
}
