using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullscreenToggle : MonoBehaviour
{
   public void toggle(bool a){
      Screen.fullScreen = a;
   }
}
