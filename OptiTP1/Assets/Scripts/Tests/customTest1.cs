using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customTest1 : ManagedUpdateBehaviour
{
   private string text = "60fps";

   public override void UpdateMe()
   {
      Print();
   }

   private void Print()
   {
      print(text);
   }
}
