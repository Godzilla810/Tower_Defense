using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    private Renderer rend;
    private Color startColor;
    public Color hoverColor;

    private GameObject turret;
    public Vector3 positionOffset;

    BuildManager buildManager;
    
    void Start() {
        buildManager = BuildManager.instance;

        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }
    //Up跟Down處理點擊
    void OnMouseDown() {
        GameObject turretToBuild = buildManager.GetTurretToBuild();
        //正在按選單
        if (EventSystem.current.IsPointerOverGameObject())
			return;
        //未選擇建立哪個砲台
        if (turretToBuild == null){
            return;
        }
        //該位置已建立砲台
        if (turret != null){
            Debug.Log("Cant build here");
            return;
        }
        
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }
    //顏色提示
    //Enter跟Exit處理覆蓋
    void OnMouseEnter() {
        GameObject turretToBuild = buildManager.GetTurretToBuild();
        //正在按選單
        if (EventSystem.current.IsPointerOverGameObject())
			return;
        //未選擇建立哪個砲台
		if (turretToBuild == null)
			return;
        rend.material.color = hoverColor;
    }
    void OnMouseExit() {
        rend.material.color = startColor;
    }
}
