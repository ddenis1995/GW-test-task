using UnityEngine;

public class KeyboardCraneController : BaseCraneController
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            InvokeForwardEnter();
        }
        if (Input.GetKeyUp(KeyCode.O))
        {
            InvokeForwardExit();
        }
    }
}
