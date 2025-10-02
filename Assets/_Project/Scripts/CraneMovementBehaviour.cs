using System;
using UnityEngine;

public class CraneMovementBehaviour : MonoBehaviour
{
    private void Awake()
    {
        ForwardButton.OnForwardEnter += MoveForward;
    }

    private void MoveForward(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}
