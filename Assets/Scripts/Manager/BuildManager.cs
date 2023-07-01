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

    public GameObject buildEffect;

    private TurretBluePrint turretToBuild;

    public bool CanBuild{ get { return turretToBuild != null; } }
    public bool HasMoney{ get { return PlayerStatus.Money >= turretToBuild.cost; } }

    public void SelectTerretToBuild(TurretBluePrint _turretToBuild){
        turretToBuild = _turretToBuild;
    }

    public void BuildTurretOn(Node node){
        if (PlayerStatus.Money < turretToBuild.cost){
            Debug.Log("窮逼");
            return;
        }
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, 
        node.GetBuildPosition(), Quaternion.identity);
        GameObject effect = Instantiate(buildEffect, 
        node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        node.turret = turret;
        PlayerStatus.Money -= turretToBuild.cost;
    }
}
