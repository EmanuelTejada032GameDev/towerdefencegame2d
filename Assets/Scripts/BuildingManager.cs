using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager Instance { get; private set; }
    private  BuildingTypeSO activeBuildingType;
    private  BuildingTypeListSO buildingTypeList;
    private Camera mainCamera;


    private void Awake()
    {
        Instance = this;

        //Allows you to find objects and assets , this time is accesing the Scriptable objects of type building from the assets in project
        //since you cant get a reference of an asset because is not instantiated.
        //Resources is unity function that allows you to find objects even assets at run time without a reference
        //Finding the scriptable objects list
        buildingTypeList = Resources.Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name);

        //Sets the default building type to element 0 on the list
        //activeBuildingType = buildingTypeList.buildingTypeSOList[0]; actually now is null and cursor is going to be the default on awake
    }

    private void Start()
    {
        mainCamera = Camera.main;

    }
    private void Update()
    {
        //Using unity events system we have access to the current event and function IsPointerOverGameObject to check if the click was on top of another object
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject() )
        {
            if(activeBuildingType != null)
            {
                Instantiate(activeBuildingType.prefab, GetMouseWorldPosition(), Quaternion.identity);
            }
        }

        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    buildingType = buildingTypeList.buildingTypeSOList[0];
        //}
        
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    buildingType = buildingTypeList.buildingTypeSOList[1];
        //}

        //if (Input.GetKeyDown(KeyCode.G))
        //{
        //    buildingType = buildingTypeList.buildingTypeSOList[2];
        //}

    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;
        return mouseWorldPosition;
    }

    public void setActiveBuildingType(BuildingTypeSO buildingType)
    {
        activeBuildingType = buildingType;
    }

    public BuildingTypeSO GetActiveBuildingType()
    {
        return activeBuildingType;
    }

}
