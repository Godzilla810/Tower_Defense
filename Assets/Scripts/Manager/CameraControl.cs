using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float moveSpeed = 20f;
    public Camera mainCamera;
    public Camera subCamera;
    private Camera currentCamera;
    public KeyCode switchKey;
    private Vector3 startMainCameraPos;
    private Vector3 startSubCameraPos;

    void Start(){
        startMainCameraPos = mainCamera.transform.position;
        startSubCameraPos = subCamera.transform.position;
        mainCamera.enabled = true;
        subCamera.enabled = false;
        currentCamera = mainCamera;
    }
    // Update is called once per frame
    void Update()
    {
        //切換相機
        if (Input.GetKeyDown(switchKey)){
            mainCamera.enabled = !mainCamera.enabled;
            subCamera.enabled = !subCamera.enabled;
            currentCamera = mainCamera.enabled ? mainCamera : subCamera;
        }
        //相機歸位
        if (Input.GetKeyDown("x")){
            mainCamera.transform.position = startMainCameraPos;
            subCamera.transform.position = startSubCameraPos;
        }
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        //前後左右
        currentCamera.transform.Translate(Vector3.right * horizontalInput * moveSpeed * Time.deltaTime + 
        Vector3.forward * verticalInput * moveSpeed * Time.deltaTime, Space.World);
        //放大
        if (currentCamera == mainCamera){
            currentCamera.transform.Translate(Vector3.down * scrollInput * moveSpeed * Time.deltaTime * 1000, Space.World);
        }
        else{
            currentCamera.orthographicSize -= scrollInput *moveSpeed * Time.deltaTime * 1000;
        }
    }
}
