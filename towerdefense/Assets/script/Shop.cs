using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    // Start is called before the first frame update
    void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void PurchaseStandardTurret()
    {
        buildManager.setTurretToBuild(buildManager.standardTurretPrefab);
    } 
    public void PurchaseMissileLauncher()
    {
        buildManager.setTurretToBuild(buildManager.MissileLauncherPrefab);

    }    

    // Update is called once per frame
    void Update()
    {
        
    }
}
