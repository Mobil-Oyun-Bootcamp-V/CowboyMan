using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentObjects : MonoBehaviour
{
    //Disabled ettiðimiz objeleri restart durumunda tekrar enabled ediyoruz.
    public void ResetEnvironment() { 

        for(int i=0; i < transform.childCount - 1; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
