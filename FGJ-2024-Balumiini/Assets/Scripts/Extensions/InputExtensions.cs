using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Balumiini.Extensions
{

    public static class InputExtensions
    {
        public static bool PressPerformed(this InputAction.CallbackContext ctx)
        {
            return ctx.performed && ctx.ReadValue<float>() == 1 ? true : false;
        }

    }

}