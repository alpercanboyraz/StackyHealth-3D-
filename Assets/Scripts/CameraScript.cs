using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    Camera myCamera;
    float maxZoomIn = 32.0f;
    float limit = 35.0f;

    // Start is called before the first frame update
    void Start()
    {
        myCamera = gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            InvokeRepeating("zoomCameraIn", 0.0f, 0.0001f);
        }

        if (myCamera.fieldOfView < limit)
        {
            CancelInvoke("zoomCameraIn");
        }
    }

    void zoomCameraIn()
    {
        float yVelocity = 0.0f;
        myCamera.fieldOfView = Mathf.SmoothDamp(myCamera.fieldOfView, maxZoomIn, ref yVelocity, 0.3f);
    }
}