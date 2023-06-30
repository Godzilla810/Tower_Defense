using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 40.0f;
    public float explosionRadius = 0f;
    private Transform target;
    public GameObject bulletPiecesPrefab;
    public GameObject enemyPiecesPrefab;
    
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
    void Explode(){
        Collider[] enemiesInAttackRange = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider other in enemiesInAttackRange){
            if (other.tag == "Enemy"){
                Destroy(other.gameObject);
                GameObject enemyPieces = (GameObject)Instantiate(enemyPiecesPrefab, transform.position, transform.rotation);
                Destroy(enemyPieces, 1f);
            }
        }
    }
    void OnTriggerEnter(Collider other) {
        Explode();
        Destroy(gameObject);
        GameObject bulletPieces = (GameObject)Instantiate(bulletPiecesPrefab, transform.position, transform.rotation);
        Destroy(bulletPieces, 1f);
    }
    void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, explosionRadius);
	}
}
