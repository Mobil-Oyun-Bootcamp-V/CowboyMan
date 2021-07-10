using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager:SingletonSetup<PlayerManager>
{
    public static State _State;

    public static BagState _BagState;
    public static State CurrentState 
    {
        get 
        { 
            return _State; 
        }
    }
    public static BagState CurrentBagState 
    {
        get 
        {
            return _BagState; 
        }
    }
    void Awake()
    {
        StartSingleton(this);
    }
    public enum State
    {
        Walking,
        Running,
        SuperRunning,
        Dead,
        Win
    }
    public enum BagState
    {
        Empty,
        Gem,
        Obelisk
    }
  
    //STATE DURUMLARI
    public static State GetState(string get)
    {
        switch (get)
        {
            case "Walking":
                return State.Walking;
                
            case "Running":
                return State.Running;

            case "SuperRunning":
                return State.SuperRunning;
                
            case "Dead":
                return State.Dead;
         
            case "Win":
                return State.Win;
            
            default :
                Debug.LogError("Geçersiz durum girildi");
                return State.Walking;
        }
    }
   
    public static void SetState(string set) {
        switch (set)
        {
            case "Walking":
                _State = State.Walking;
                break;
            case "Running":
                _State = State.Running;
                break;
            case "SuperRunning":
                _State = State.SuperRunning;
                break;
            case "Dead":
                _State = State.Dead;
                break;
            case "Win":
                _State = State.Win;
                break;
        }
    }
    //BAG STATE DURUMLARI
    public static BagState GetBagState(string get)
    {
        switch (get)
        {
            case "Empty":
                return BagState.Empty;

            case "Gem":
                return BagState.Gem;

            case "Obelisk":
                return BagState.Obelisk;
            default:
                Debug.LogError("Geçersiz durum girildi");
                return BagState.Empty;
        
        }
    }
    public static void SetBagState(string set)
    {
        switch (set)
        {
            case "Empty":
                _BagState = BagState.Empty;
                break;
            case "Gem":
                _BagState = BagState.Gem;
                break;
            case "Obelisk":
                _BagState = BagState.Obelisk;
                break;
        }
    }
    public void ResetAllStates()
    {
        SetState("Walking");
        SetBagState("Empty");
    }
  




}
