using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Vector3 positionOffset;

    private Renderer rend;
    private Color startColor;
    public Color hoverColor;
    public Color disabledColor;

    [Header("Optional")]
    public GameObject turret;

    BuildManager buildManager;

    
    void Start() {
        buildManager = BuildManager.instance;

        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }
    public Vector3 GetBuildPosition() {
        return transform.position + positionOffset;
    }
    //Up跟Down處理點擊
    void OnMouseDown() {
        //正在按選單
        if (EventSystem.current.IsPointerOverGameObject())
			return;
        //未選擇建立哪個砲台
        if (!buildManager.CanBuild){
            return;
        }
        //該位置已建立砲台
        if (turret != null){
            Debug.Log("Cant build here");
            return;
        }
        //建立砲台
        buildManager.BuildTurretOn(this);
    }
    //顏色提示
    //Enter跟Exit處理覆蓋
    void OnMouseEnter() {
        //正在按選單
        if (EventSystem.current.IsPointerOverGameObject())
			return;
        //未選擇建立哪個砲台
		if (!buildManager.CanBuild)
			return;
        if (!buildManager.HasMoney){
            rend.material.color = disabledColor;
            return;
        }
        rend.material.color = hoverColor;
    }
    void OnMouseExit() {
        rend.material.color = startColor;
    }
}
