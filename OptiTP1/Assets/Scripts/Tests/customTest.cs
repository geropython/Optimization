// Para hacer un nuevo script con el update custom se le agrega como herencia su manager de custom update correspondiente
// Gameplay agregan ManagedUpdateBehaviour
// UI agregan ManagedUpdateBehaviourUI
// Ejemplo| public class Player : ManagedUpdateBehaviour
// Luego lo que se pondria dentro del Update si pone dentro de la funcion| public override void UpdateMe()

public class customTest : ManagedUpdateBehaviourUI
{
   private string text = "30fps";

   public override void UpdateMe()
   {
      Print();
   }

   private void Print()
   {
      print(text);
   }
}
