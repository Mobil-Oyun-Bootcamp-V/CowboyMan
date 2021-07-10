using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObjects : MonoBehaviour
{
   void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "Bag" || collider.tag == "Floor" || collider.tag=="Slower") { return; }
        this.gameObject.SetActive(false);
    }
}
