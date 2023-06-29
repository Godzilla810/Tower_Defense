using UnityEngine;
//讀取路線點
public class PathPoint : MonoBehaviour
{
    public static Transform[] points;

    void Awake(){
        points = new Transform[transform.childCount];
        for (int i = 0; i  < points.Length; i++){
            points[i] = transform.GetChild(i);
        }
    }
}
