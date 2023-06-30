using UnityEngine;

public class BuildManager : MonoBehaviour
{
    //讓其他腳本訪問
    public static BuildManager instance;
    void Awake() {
        if (instance != null){
			Debug.LogError("More than one BuildManager in scene!");
			return;
		}
        instance = this;
    }

    public GameObject standardTurretPrefab;
    public GameObject missileTurretPrefab;
    public GameObject laserTurretPrefab;
    private GameObject turretToBuild;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SetTerretToBuild(GameObject _turretToBuild){
        turretToBuild = _turretToBuild;
    }
    public GameObject GetTurretToBuild(){
        return turretToBuild;
    }
}
