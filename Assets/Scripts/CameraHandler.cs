using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{

    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera; //Getting reference of the virtual camera

    private float ortographicSize;
    private float targetOrtographicSize;
    private void Start()
    {
        ortographicSize = cinemachineVirtualCamera.m_Lens.OrthographicSize;
        targetOrtographicSize = ortographicSize;
    }
    private void Update()
    {
        handleMovement();
        handleZoom();
    }

    private void handleMovement()
    {
        //get movement on directions from keyboard or gamepad bbuttons
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = new Vector3(x, y).normalized;
        float moveSpeed = 30f;

        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    private void handleZoom()
    {
        float zoomAmount = 2f;
        targetOrtographicSize += -Input.mouseScrollDelta.y * zoomAmount;
        float minOrtographicSize = 10;
        float maxOrtographicSize = 30;
        targetOrtographicSize = Mathf.Clamp(targetOrtographicSize, minOrtographicSize, maxOrtographicSize);

        float zoomSpeed = 5f;
        ortographicSize = Mathf.Lerp(ortographicSize, targetOrtographicSize, Time.deltaTime * zoomSpeed);
        cinemachineVirtualCamera.m_Lens.OrthographicSize = ortographicSize;
    }

}
