using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBluePrint standardTurret;
    public TurretBluePrint missileTurret;
    public TurretBluePrint laserTurret;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void PurchaseStandardTurret(){
        buildManager.SelectTerretToBuild(standardTurret);
    }
    public void PurchaseMissleTurret(){
        buildManager.SelectTerretToBuild(missileTurret);
    }
    public void PurchaseLaserTurret(){
        buildManager.SelectTerretToBuild(laserTurret);
    }
}
