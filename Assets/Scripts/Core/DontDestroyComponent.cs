using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyComponent : MonoBehaviour
{
   private static bool hasCreated = false;
   void Awake()
   {
      if (!hasCreated)
      {
         hasCreated = true;
         DontDestroyOnLoad(this);
      }
      else
      {
         Destroy(gameObject);
      }
   }
}
