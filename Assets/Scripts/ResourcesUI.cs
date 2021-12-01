using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesUI : MonoBehaviour
{
    private ResourceTypeListSO resourceTypeList;
    private Dictionary<ResourceTypeSO, Transform> resourceTypeTransformDictionary;
    //[SerializeField] private Transform resourceTemplate;
    private void Awake()
    {
        resourceTypeList = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name);
        resourceTypeTransformDictionary = new Dictionary<ResourceTypeSO, Transform>();

        Transform resourceTemplate = transform.Find("resourceTemplate");
        resourceTemplate.gameObject.SetActive(false);

        int index = 0;
        foreach(ResourceTypeSO resourceType in resourceTypeList.resourceTypeSOList)
        {
            //Creating and instantiating different resourceType UI elements
            Transform resourceTransform = Instantiate(resourceTemplate, transform);
            resourceTransform.gameObject.SetActive(true);

            //Setting position to the instantiated UI elements
            float offsetAmount = -150f;
            resourceTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(offsetAmount * index,0);

            //Update image of different instantiated UI objects base on resource on the ResourceTypeList
            resourceTransform.Find("image").GetComponent<Image>().sprite = resourceType.sprite;

            //Keep track of the transform of each element to use it outside the awake function
            resourceTypeTransformDictionary[resourceType] = resourceTransform;


            index++;
        }

    }

    private void Start()
    {
        ResourceManager.ResourceManagerInstance.OnResourceAmountChanged += ResourceManagerInstance_OnResourceAmountChanged;
        UpdateResourceAmountUI();
    }

    private void ResourceManagerInstance_OnResourceAmountChanged(object sender, System.EventArgs e)
    {
        UpdateResourceAmountUI();
    }

    private void UpdateResourceAmountUI()
    {
        foreach (ResourceTypeSO resourceType in resourceTypeList.resourceTypeSOList)
        {
            //Update text of different instantiated UI objects base on resource on the ResourceTypeList
            int resourceAmount = ResourceManager.ResourceManagerInstance.GetResourceAmount(resourceType);
            Transform resourceTransform = resourceTypeTransformDictionary[resourceType];
            resourceTransform.Find("text").GetComponent<TextMeshProUGUI>().SetText(resourceAmount.ToString());

            // old code to get the transform when all the code was on awake()
            //resourceTransform.Find("text").GetComponent<TextMeshProUGUI>().SetText(resourceAmount.ToString());
        }
    }
}
