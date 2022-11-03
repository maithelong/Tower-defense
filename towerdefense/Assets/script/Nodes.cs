using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Nodes : MonoBehaviour
{
   
    public Color hoverColor;
    private Color startColor;
    public GameObject turret;
    private Renderer rend;
    public Vector3 positionOffset;
    BuildManager buildManager;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor=rend.material.color;
        buildManager = BuildManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (buildManager.getTurretToBuild()==null)
            return;
        //hàm tạo turret
        if (turret == null)
        {
            Debug.Log("can't build there - TODO: Display on screen.");
            return;
        }
        else
        {
            GameObject turretToBuild = buildManager.getTurretToBuild();
            turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
        }
    }
    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (buildManager.getTurretToBuild() == null)
            return;
        //hover vào node node sẽ đổi màu 
        rend.material.color = hoverColor;
       
    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;
        //hover out vào node sẽ trả lại màu mặc định 
    }
    

}
