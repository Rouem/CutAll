using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int maxPilesQuantity;

    public int initialPilesQuantity;

    private int currentQuantity = 0;

    public static bool spawnEnd {set;get;} = false;

    public static System.Action incrementQuatity, incrementInitialQuantity;

    private void OnEnable() {
        incrementQuatity += IncrementQuantity;
        incrementInitialQuantity += IncrementInitialQuantity;
    }

    private void OnDisable() {
        incrementQuatity -= IncrementQuantity;
        incrementInitialQuantity -= IncrementInitialQuantity;
    }

    private void OnDestroy() {
        incrementQuatity -= IncrementQuantity;
        incrementInitialQuantity -= IncrementInitialQuantity;
    }


    public void IncrementQuantity(){
        currentQuantity++;
        currentQuantity = Mathf.Clamp(currentQuantity,0,initialPilesQuantity);
        spawnEnd = currentQuantity >= initialPilesQuantity;        
    }

    public void IncrementInitialQuantity(){
        initialPilesQuantity++;
        initialPilesQuantity = Mathf.Clamp(initialPilesQuantity,3,maxPilesQuantity);
        spawnEnd = false;
    }






}
