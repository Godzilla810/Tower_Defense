using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int pathPointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        target = PathPoint.points[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDir = target.position - transform.position;
        transform.Translate(moveDir.normalized * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, target.position) <= 0.4f){
            FindNextPoint();
        }
    }

    void FindNextPoint(){
        if (pathPointIndex >= PathPoint.points.Length - 1){     //走到終點
            Destroy(gameObject);
            return;
        }
        pathPointIndex++;
        target = PathPoint.points[pathPointIndex];
    }
}
