using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameManager
{
    public static UIManager uIManager;

    public static CutterController cutterController;

    private static int currentLevelCoins = 0;

    private static int recordCoins = 0;

    public static void RestartGame(){
        SceneManager.LoadScene(
            0
        );
        currentLevelCoins = 0;
        uIManager.UpdateCoins(recordCoins);
        cutterController.Init();
    }

    public static void NextLevel(){
        recordCoins = currentLevelCoins;
        GameManager.uIManager.gameOver.SetActive(true);
    }

    public static void IncreaseCoins(int value){
        currentLevelCoins += value;
        uIManager.UpdateCoins(currentLevelCoins+recordCoins);
    }


}
