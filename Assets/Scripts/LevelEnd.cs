using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool finished = false;
    void Start()
    {
        finished = false;
    }


    private void OnTriggerEnter(Collider other) {
        if(other.tag != "Player") return;
        Debug.Log("Level End");
        if(LevelEnd.finished){
            enabled = false;
            return;
        }
        LevelManager.incrementInitialQuantity.Invoke();
        GameManager.NextLevel();
        enabled = false;
    }
}
