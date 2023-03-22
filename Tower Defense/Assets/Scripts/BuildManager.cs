using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one build manager");
            return;
        }
        instance = this;
    }
    
    public GameObject buildEffect;
    private TurretBlueprint turretToBuild;

    public bool CanBuild
    {
        get {return turretToBuild != null; }
    }
    
    public bool HasMoney
    {
        get {return PlayerStats.money >= turretToBuild.cost; }
    }


    public void SelectTurretToBuild( TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.money < turretToBuild.cost)
        {
            return;
        }

        PlayerStats.money -= turretToBuild.cost;
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        
        GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        node.turret = turret;
    }
    
}
