using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void PurchaseStandardTurret(){
        Debug.Log("Standaaard");
        buildManager.SetTerretToBuild(buildManager.standardTurretPrefab);
    }
    public void PurchaseMissleTurret(){
        Debug.Log("Missile");
        buildManager.SetTerretToBuild(buildManager.missileTurretPrefab);
    }
    public void PurchaseLaserTurret(){
        Debug.Log("Loser");
        buildManager.SetTerretToBuild(buildManager.laserTurretPrefab);
    }
}
