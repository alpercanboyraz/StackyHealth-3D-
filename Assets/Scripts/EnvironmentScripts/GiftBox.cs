using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftBox : MonoBehaviour
{
  public GameObject collectAnim;
    float accelx, accely, accelz = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        gameObject.transform.Rotate(accelx * Time.deltaTime, 45 * Time.deltaTime, accelz * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(collectAnim, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
