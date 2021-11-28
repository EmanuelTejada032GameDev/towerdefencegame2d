using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    
    private  BuildingTypeSO buildingType;
    private  BuildingTypeListSO buildingTypeList;
    private Camera mainCamera;


    private void Awake()
    {
        //Resources is unity function that allows you to find objects even assets at run time without a reference
        //Finding the scriptable objects list
        buildingTypeList = Resources.Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name);
        
        //Sets the default building type to element 0 on the list
        buildingType = buildingTypeList.buildingTypeSOList[0];
    }

    private void Start()
    {
        mainCamera = Camera.main;

    }
    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(buildingType.prefab, GetMouseWorldPosition(), Quaternion.identity );
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            buildingType = buildingTypeList.buildingTypeSOList[0];
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            buildingType = buildingTypeList.buildingTypeSOList[1];
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            buildingType = buildingTypeList.buildingTypeSOList[2];
        }

    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;
        return mouseWorldPosition;
    }

}
