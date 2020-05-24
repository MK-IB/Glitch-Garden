using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
   void Start()
   {
       PlayerPrefsController.SetMasterVolume(0.4f);
       Debug.Log("Returned value of " + PlayerPrefsController.GetMasterVolume());
   }
}
