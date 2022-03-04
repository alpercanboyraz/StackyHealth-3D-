using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;
public class PlayerManager : MonoBehaviour
{
    
    
    [SerializeField] private int playerCurrentHealthy = 0;
    [SerializeField] Animator anim;
    public TextMeshProUGUI healthyText;
    Rigidbody rig;
    EnvironmentUp coinsManager;

    public GameObject ParentGameObject;

    void Start(){
        coinsManager = FindObjectOfType<EnvironmentUp>();
        rig = GetComponent<Rigidbody>();
    }
   void Update(){
        healthyText.text = "HEALTH : " + playerCurrentHealthy.ToString();

        
    }
    
    public void OnCollisionEnter(Collision collision){
       
        
        if(collision.gameObject.tag == "giftBox"){
            
            playerCurrentHealthy+=10;
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "healthy"){
            playerCurrentHealthy+=10;
            coinsManager.AddCoins(collision.transform.position,7);
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "unhealthy"){
            Destroy(collision.gameObject);
            
            if(playerCurrentHealthy > 0){
                playerCurrentHealthy-=5;
            }
            
        }
        if(collision.gameObject.tag == "sea"){
            //playerCurrentHealthy+=10;
            //Debug.Log("seaaaa");
            anim.SetBool("isFlip",true);
            
            //Destroy(collision.gameObject);
        }
         if(collision.gameObject.tag == "Finish"){
           
            anim.SetBool("isDance",true);
            //Debug.Log("Finishhh");  
            // camera
            GameObject  ChildGameObject1 = ParentGameObject.transform.GetChild(0).gameObject;
            Destroy(ChildGameObject1);
            GameObject  ChildGameObject2 = ParentGameObject.transform.GetChild(1).gameObject;

           
        }
    }

    public void OnCollisionExit(Collision col){
        if(col.gameObject.tag == "sea"){
          
            anim.SetBool("isFlip",false);
            
        }
    
    }
}
