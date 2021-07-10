using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    Bag _bag;
    float TriggerTime;
    void Awake()
    {
        _bag = GetComponentInChildren<Bag>();
    }
    void OnTriggerEnter(Collider collider)
    {
        if (Time.time < TriggerTime + 0.1f) 
        {
            return;
        }
        //Skillere çarptýðýmýzda yeni skill kazanmayý ve elmaslarý çantamýza eklemeyi yaptým.
        switch (collider.tag)
        {
            case "SprintPower":

                if (PlayerManager.CurrentState == PlayerManager.GetState("SuperRunning"))
                {
                    return;
                }
                else if (PlayerManager.CurrentState == PlayerManager.GetState("Running"))
                {
                    PlayerManager.SetState("SuperRunning");
                }
                else
                {
                    PlayerManager.SetState("Running");
                }
                break;

            case "Slower":
                
                PlayerManager.SetState("Walking");
                break;

            case "Obstacle":

                PlayerManager.SetState("Dead");
                break;

            case "Gem":
                _bag.AddObject(collider.gameObject);
                break;

            case "Obelisk":
                _bag.AddObject(collider.gameObject);
                break;
        }
        TriggerTime = Time.time;
    }
  

    void OnTriggerStay(Collider collider)
    {
        switch (collider.tag)
        {
            case "Finish":
                PlayerManager.SetState("Win");
                break;
        }
    }
}
