using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    private Dictionary<ResourceTypeSO, int> resourceAmountDictionary;

    public static ResourceManager ResourceManagerInstance { get;  private set; }
    private void Awake()
    {
        ResourceManagerInstance = this;

        resourceAmountDictionary = new Dictionary<ResourceTypeSO, int>();

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

        TestLogResourceAmountDictionary();
    }
}
