using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
   public UnityEvent<GameObject, Checkpoint> onCheckpointEnter;
   void OnTriggerEnter(Collider collider)
   {
       //use CardIdentity to check if the gameObject is a car
        CarIdentity carIdentity = collider.gameObject.GetComponent<CarIdentity>();
        if (carIdentity != null)
       {
           // fire an event giving the entering gameObject and this checkpoint
           onCheckpointEnter.Invoke(collider.gameObject, this);
       }
   }
}