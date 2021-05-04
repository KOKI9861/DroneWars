using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NumToggleScript : MonoBehaviour
{
    public static int NumOfPlayers = -1;
    public Toggle onePlayer;
    public Toggle twoPlayers;
    public Toggle threePlayers;
    public Toggle fourPlayers;

    // Start is called before the first frame update
    void Start()
    {
        onePlayer.onValueChanged.AddListener(toggleOne);
        twoPlayers.onValueChanged.AddListener(toggleTwo);
        threePlayers.onValueChanged.AddListener(toggleThree);
        fourPlayers.onValueChanged.AddListener(toggleFour);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleOne(bool on){
        if(on){
            NumOfPlayers = 1;
        }else{
            NumOfPlayers = -1;
        }
    }

    public void toggleTwo(bool on){
        if(on){
            NumOfPlayers = 2;
        }else{
            NumOfPlayers = -1;
        }
    }

    public void toggleThree(bool on){
        if(on){
            NumOfPlayers = 3;
        }else{
            NumOfPlayers = -1;
        }
    }

    public void toggleFour(bool on){
        if(on){
            NumOfPlayers = 4;
        }else{
            NumOfPlayers = -1;
        }
    }
}
