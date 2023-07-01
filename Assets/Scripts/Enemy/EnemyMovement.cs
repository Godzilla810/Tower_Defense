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
        //朝點移動
        Vector3 moveDir = targetPoint.position - transform.position;
        transform.Translate(moveDir.normalized * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, targetPoint.position) <= 0.4f){
            FindNextPoint();
        }
    }
    //找下一個點
    void FindNextPoint(){
        if (pathPointIndex >= PathPoint.points.Length - 1){     //走到終點
            EndPath();
            return;
        }
        pathPointIndex++;
        targetPoint = PathPoint.points[pathPointIndex];
    }
    //敵人死亡(終點)
    void EndPath(){
        PlayerStatus.Lives--;
        GetComponent<EnemyStatus>().DestroyEnemy();
    }
}
