using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculatePoint : MonoBehaviour
{
    public float Point{ get; private set; }

    [SerializeField] GameObject Player;
    [SerializeField] GameObject EndPoint;
    [SerializeField] DistancePanel DistancePanel;

    float currentDistance;
    float distance;
    float plus;
    float Counter1, Counter2, Counter3;
    float time;

    void Awake()
    {
        distance = Vector3.Distance(EndPoint.transform.position, Player.transform.position);
        plus = 100 / distance;
    }
    void Update()
    {
        if (PlayerManager.CurrentState == PlayerManager.GetState("Dead") ||
            PlayerManager.CurrentState == PlayerManager.GetState("Win"))
        {
            return; 
        }

        time+=Time.deltaTime;

        if (PlayerManager.CurrentBagState == PlayerManager.GetBagState("Empty"))
             Counter1++;
        
        else if (PlayerManager.CurrentBagState == PlayerManager.GetBagState("Obelisk"))
             Counter2++;

        else if (PlayerManager.CurrentBagState == PlayerManager.GetBagState("Gem"))
            Counter3++;
    
    }
    //Bitiþ ile mesafeyi ölçüyor.
    public float GetCurrentDistance() 
    {
        currentDistance = distance - Vector3.Distance(EndPoint.transform.position, Player.transform.position);
        return currentDistance;
    }
    //Bitiþ zamaný
    public int GetTime()
    {
        return (int)time;
    }
    //Mesafeyi ölçekleme
    public float GetPlus()
    {
        return plus;
    }
    //Karakterin sýrtýndaki objeye göre o an puanlamasý.
    public float GetPoint()
    {   
       Point = (Counter1 * 1) + (Counter2 * 2) + (Counter3 * 3);
       return Point;
    }
   public void ResetScore()
    {
        Counter1 = 0;
        Counter2 = 0;
        Counter3 = 0;
    }
   public void ResetTime()
    {
        time = 0;
    }
}
