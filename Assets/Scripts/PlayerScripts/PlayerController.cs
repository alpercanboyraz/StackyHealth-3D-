using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
   Rigidbody rig;
    bool left, right;
    bool turnRight;
    float prevZ;
    public float damping = 1000.0f;

    [SerializeField]
    float speed;

    [SerializeField]
    
    int count = 0;
    bool isFinish = true;
    Vector3 go_right,go_left;
    void Start()
    {
        
        rig = GetComponent<Rigidbody>();
        turnRight = false;
    }

    
    void Update()
    {
        if(isFinish){
            playerTranslate();
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            
        }
        
        if (Input.touchCount > 0)
        {
            Touch finger = Input.GetTouch(0);

            if(finger.deltaPosition.x > 20.0f)
            {
                right = true;
                left = false;
            }
           
            if (finger.deltaPosition.x <  -20.0f)
            {
                right = false;
                left = true;
            }
        
            if(right == true)
            {
                transform.position = Vector3.Lerp(transform.position, go_right, 5f * Time.deltaTime);
            }

            if (left == true)
            {
                transform.position = Vector3.Lerp(transform.position, go_left, 5f * Time.deltaTime);
            }

        }

        if (turnRight)
        {
            StartCoroutine(Rotate(Vector3.up, 45.0f, 0.85f));
            
            /*
            float desiredRot = 90.0f;
            float rotationComplete = transform.rotation.eulerAngles.y - (transform.rotation.eulerAngles.y % 10);
            var targetRotQuaternion = Quaternion.Euler(transform.eulerAngles.x, desiredRot, transform.eulerAngles.z);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotQuaternion, Time.deltaTime * damping);

            if (rotationComplete == desiredRot)
            {
                turnRight = false;
            }
            */

            /*
            transform.RotateAround(transform.position, Vector3.up, 90 * Time.deltaTime);
            if (transform.rotation.eulerAngles.y >= 90.0f)
            {
                turnRight = false;
                float rotationComplete = transform.rotation.eulerAngles.y - (transform.rotation.eulerAngles.y % 10);
                
                transform.rotation = Change(transform.rotation.eulerAngles.x, rotationComplete, transform.rotation.eulerAngles.z);
                Debug.Log(rotationComplete);
            }
            else
            {
                Debug.Log(Time.deltaTime);
                transform.position = new Vector3(transform.position.x, transform.position.y, prevZ);
            }
            */
        }
    }

    public void OnCollisionEnter(Collision collision)
    {

       if (collision.gameObject.tag == "turnLeft")
        {
            Debug.Log("Turning point!!!");
        }

        if (collision.gameObject.tag == "turnRight")
        {
            Debug.Log("rightttt");
            prevZ = transform.position.z;
            turnRight = true;
            count++;
        }

         if(collision.gameObject.tag == "Finish"){
           
            
            isFinish = false;
            StartCoroutine(Rotate(Vector3.up, 150.0f, 0.85f));
            Debug.Log("Finishhh");
            
        }
    }

    IEnumerator Rotate(Vector3 axis, float angle, float duration = 1.0f)
    {
        Quaternion from = transform.rotation;
        Quaternion to = transform.rotation;
        to *= Quaternion.Euler(axis * angle);

        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            transform.rotation = Quaternion.Slerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.rotation = to;
        turnRight = false;
    }


    void playerTranslate(){
            
            switch(count){
                case 0:
                       go_right = new Vector3(15.33f, transform.position.y, transform.position.z);
                       go_left = new Vector3(-15f, transform.position.y, transform.position.z);
                return; 
                case 1:
                       go_right = new Vector3(transform.position.x, transform.position.y, 582f);
                       go_left = new Vector3(transform.position.x, transform.position.y, 607f);
                return;
                case 2:
                       go_right = new Vector3(817f, transform.position.y, transform.position.z);
                       go_left = new Vector3(852f, transform.position.y, transform.position.z);
                return;
            }
            
        }
}
