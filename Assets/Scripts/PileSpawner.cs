using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PileSpawner : MonoBehaviour
{
    public List<GameObject>Piles = new List<GameObject>();

    public GameObject pileInstance;
    public GameObject levelEnd;

    public Transform newPilePoint;

    void Start()
    {
        if(LevelManager.spawnEnd){
            LevelManager.incrementInitialQuantity.Invoke();
            Instantiate(levelEnd,newPilePoint.position,Quaternion.identity);
            return;
        }
        int sort = Random.Range(0, Piles.Count);
        var pile = Instantiate(Piles[sort],transform.position,Quaternion.identity);
        pile.transform.SetParent(transform);
        GameObject newPile = pileInstance;
        Instantiate(newPile, newPilePoint.position,Quaternion.identity);
        LevelManager.incrementQuatity.Invoke();
    }

}
