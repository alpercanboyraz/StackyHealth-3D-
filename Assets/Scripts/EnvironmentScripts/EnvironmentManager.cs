using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    float accelx, accely, accelz = 0;

    void Update(){
        Rotate();
    }


   private void Rotate()
    {
        gameObject.transform.Rotate(accelx * Time.deltaTime, 45 * Time.deltaTime, accelz * Time.deltaTime);
    
    }
}
