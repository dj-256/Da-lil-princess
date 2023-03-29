using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public UnityEvent<GameObject, Coin> onCoinEnter;
    void OnTriggerEnter(Collider collider)
    {
        //use CardIdentity to check if the gameObject is a car
        CarIdentity carIdentity = collider.gameObject.GetComponent<CarIdentity>();
        if (carIdentity != null)
        {
            // fire an event giving the entering gameObject and this checkpoint
            onCoinEnter.Invoke(collider.gameObject, this);
        }
    }
}
