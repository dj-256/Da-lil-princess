using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
   public PlayerControls playerControls;
   public AIControls[] aiControls;
   public LapManager lapTracker;
   public TricolorLights tricolorLights;
   void Awake()
   {
       StartGame();
   }
   public void StartGame()
   {
       FreezePlayers(true);
       StartCoroutine("Countdown");
   }
   IEnumerator Countdown()
   {
       yield return new WaitForSeconds(1);
       Debug.Log("3");
       tricolorLights.SetProgress(1);
       yield return new WaitForSeconds(1);
       Debug.Log("2");
       tricolorLights.SetProgress(2);
       yield return new WaitForSeconds(1);
       Debug.Log("1");
       tricolorLights.SetProgress(3);
       yield return new WaitForSeconds(1);
       Debug.Log("GO");
       tricolorLights.SetProgress(4);
       StartRacing();
       yield return new WaitForSeconds(2f);
       tricolorLights.SetAllLightsOff();
   }
   public void StartRacing()
   {
       FreezePlayers(false);
   }
   void FreezePlayers(bool freeze)
   {
        playerControls.enabled = !freeze;
        foreach(AIControls ai in aiControls) ai.enabled = !freeze;
   
   }
}