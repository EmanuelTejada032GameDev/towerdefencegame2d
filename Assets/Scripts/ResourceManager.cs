using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    private Dictionary<ResourceTypeSO, int> resourceAmountDictionary;

    public static ResourceManager ResourceManagerInstance { get;  private set; }
    public event EventHandler OnResourceAmountChanged;

    private void Awake()
    {
        ResourceManagerInstance = this;

        resourceAmountDictionary = new Dictionary<ResourceTypeSO, int>();


        //Allows you to find objects and assets , this time is accesing the Scriptable objects of type resource from the assets in project
        //since you cant get a reference of an asset because is not instantiated.
        //Resources is unity function that allows you to find objects even assets at run time without a reference
        //Finding the scriptable objects list
        ResourceTypeListSO resourceTypeList = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name);

        foreach(ResourceTypeSO resourceType in resourceTypeList.resourceTypeSOList)
        {
            resourceAmountDictionary[resourceType] = 0;
        }


    }

    private void Update()
    {


        //testing generating resource manually
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    ResourceTypeListSO resourceTypeList = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name);
        //    AddResource(resourceTypeList.resourceTypeSOList[0], 2);
        //    TestLogResourceAmountDictionary();
        //}
    }

    public int GetResourceAmount(ResourceTypeSO resourceType)
    {
        
        return resourceAmountDictionary[resourceType];
    }

    private void TestLogResourceAmountDictionary()
    {
        foreach (ResourceTypeSO resourceType in resourceAmountDictionary.Keys)
        {
            Debug.Log($"{resourceType.nameString}: {resourceAmountDictionary[resourceType]}");
        }
    }

    public void AddResource(ResourceTypeSO resourceType, int amount)
    {
        resourceAmountDictionary[resourceType] += amount;
        OnResourceAmountChanged?.Invoke(this, EventArgs.Empty);
        TestLogResourceAmountDictionary();
    }
}
