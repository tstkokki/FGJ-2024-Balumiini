
using UnityEngine.InputSystem;

public interface IInputReceiver
{
    void OnPrimary(InputAction.CallbackContext ctx);
    void OnSecondary(InputAction.CallbackContext ctx);
    void OnTertiary(InputAction.CallbackContext ctx);
    void OnHorizontal(InputAction.CallbackContext ctx);
    void OnVertical(InputAction.CallbackContext ctx);
    void OnBack(InputAction.CallbackContext ctx);
    void OnParty1(InputAction.CallbackContext ctx);
    void OnParty2(InputAction.CallbackContext ctx);
    void OnParty3(InputAction.CallbackContext ctx);
    void OnParty4(InputAction.CallbackContext ctx);
    void OnParty5(InputAction.CallbackContext ctx);
    void OnParty6(InputAction.CallbackContext ctx);
    
}
