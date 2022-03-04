using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections.Generic;
public class EnvironmentUp : MonoBehaviour
{
    [Header("UI references")]
    [SerializeField] GameObject animatedHealthPrefab;
    [SerializeField] Transform target;
    
    [Space]
    [Header("Available coins")]
    [SerializeField] int maxCoins;
    Queue<GameObject> coinsQueue = new Queue<GameObject>();
    
    [Header("Animation settings")]
    [SerializeField] [Range(0.5f,0.9f)] float minAnimUDration; 
    [SerializeField] [Range(0.9f,2f)] float maxAnimUDration; 
    [SerializeField] Ease easeType;
    Vector3 targetPosition;
    Vector3 collectedCoinPosition;
    private int _c = 0;
  
    void Awake(){
        targetPosition = target.position;
        PrepareCoins();
    }

    // Update is called once per frame
    
    public void PrepareCoins(){
        
        GameObject coin;
        for (int i = 0; i < 7; i++)
        {
        coin = Instantiate(animatedHealthPrefab);
        coin.transform.parent = transform;
        coin.SetActive(false);
        coinsQueue.Enqueue(coin);
        }
    }

    public void AddCoins(Vector3 collectedCoinPosition,int amount){
        
        Animate(collectedCoinPosition,amount);
    }
    void Animate(Vector3 collectedCoinPosition,int amount){
        for (int i = 0; i < amount; i++)
        {
            if(coinsQueue.Count > 0){
                   GameObject coin = coinsQueue.Dequeue();
                   coin.SetActive(true);
            
                   coin.transform.position = collectedCoinPosition;
                   float duration = Random.Range(minAnimUDration,maxAnimUDration);
                   coin.transform.DOMove(targetPosition,duration*3).SetEase(easeType)
                   .OnComplete(() =>{
                        coin.SetActive(false);
                        coinsQueue.Enqueue(coin);
                    });
            }
        }
    }
}
