using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject mainScreen, hud, gameOver;

    public Button startBtn, restartBtn, replayBtn;

    public Text coinsTxt;

    private void Awake() {
        if(GameManager.uIManager != null){
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        mainScreen.SetActive(true);
        hud.SetActive(false);
        gameOver.SetActive(false);

        startBtn.onClick.RemoveAllListeners();
        replayBtn.onClick.RemoveAllListeners();
        restartBtn.onClick.RemoveAllListeners();

        startBtn.onClick.AddListener(() =>{
            mainScreen.SetActive(false);
            hud.SetActive(true);
        });
        restartBtn.onClick.AddListener(() => {
            hud.SetActive(false);
            mainScreen.SetActive(true);
            GameManager.RestartGame();
        });
        replayBtn.onClick.AddListener(() => {
            hud.SetActive(false);
            gameOver.SetActive(false);
            mainScreen.SetActive(true);
            GameManager.RestartGame();
        });
        
        GameManager.uIManager = this;
        GameManager.IncreaseCoins(0);
    }

    public void UpdateCoins(int value){
        coinsTxt.text = "Coins: "+value;
    }




}
