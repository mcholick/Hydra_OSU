using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGameOnClick : MonoBehaviour {

     public void LoadGame()
     {
          SaveLoad.Load();
          Game.current = SaveLoad.data;
     }
}
