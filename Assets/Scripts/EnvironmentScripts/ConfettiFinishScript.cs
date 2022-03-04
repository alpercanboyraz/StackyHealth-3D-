using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfettiFinishScript : MonoBehaviour
{
  public GameObject collectAnim;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   

   

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(collectAnim, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            //Destroy(gameObject);
        }
    }
}
