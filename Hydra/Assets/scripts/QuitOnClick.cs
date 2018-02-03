using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitOnClick : MonoBehaviour {

     public void Quit()
     {
          //if in unity editor exit play mode
#if UNITY_EDITOR
          UnityEditor.EditorApplication.isPlaying = false;
          //if not in editor then must be in actual build
#else
          Application.Quit();
#endif
     }
}
