using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   [SerializeField] private GameObject[] giftBox = new GameObject[4];
   float accelx, accely, accelz = 0;

  void Update(){
      RotateGiftBox();
  }
 
 
  public void RotateGiftBox(){
      for (int i = 0; i < giftBox.Length; i++)
      {
          // giftBox[i].transform.rotation = new Quaternion(0, 45, 0, 0);
           giftBox[i].transform.Rotate (accelx * Time.deltaTime, 45 * Time.deltaTime, accelz * Time.deltaTime);
      }
  }  

}
