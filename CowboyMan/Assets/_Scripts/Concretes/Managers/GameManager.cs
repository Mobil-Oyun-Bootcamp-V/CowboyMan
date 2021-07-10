using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonSetup<GameManager>
{

    public event System.Action OnIsWalking;
    public event System.Action OnIsRunning;
    public event System.Action OnIsSuperRunning;
    public event System.Action OnIsDead;
    public event System.Action OnIsWin;
    void Awake()
    {
        StartSingleton(this);
    }
    //Mevcut duruma göre Eventleri çalýþtýrýyor.
    void Update()
    {
        if (PlayerManager.CurrentState == PlayerManager.GetState("Walking"))
        {
            OnIsWalking?.Invoke();
        }
        else if (PlayerManager.CurrentState == PlayerManager.GetState("Running"))
        {
            OnIsRunning?.Invoke();
        }
        else if (PlayerManager.CurrentState == PlayerManager.GetState("SuperRunning"))
        {
            OnIsSuperRunning?.Invoke();
        }
        else if (PlayerManager.CurrentState == PlayerManager.GetState("Dead"))
        {
            OnIsDead?.Invoke();
        }
        else if (PlayerManager.CurrentState == PlayerManager.GetState("Win"))
        {
            OnIsWin.Invoke();
        }
    }
 

}

