using UnityEngine;
//讓Enemy照路線走
public class EnemyMovement : MonoBehaviour
{
    public float speed = 10f;

    private Transform targetPoint;
    private int pathPointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        targetPoint = PathPoint.points[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDir = targetPoint.position - transform.position;
        transform.Translate(moveDir.normalized * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, targetPoint.position) <= 0.4f){
            FindNextPoint();
        }
    }

    void FindNextPoint(){
        if (pathPointIndex >= PathPoint.points.Length - 1){     //走到終點
            Destroy(gameObject);
            return;
        }
        pathPointIndex++;
        targetPoint = PathPoint.points[pathPointIndex];
    }
}
