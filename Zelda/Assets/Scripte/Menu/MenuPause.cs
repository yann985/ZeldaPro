using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;
public class MenuPause : MonoBehaviour
{
    [SerializeField] GameObject _activeMenu;
    [SerializeField] GameObject _fermePanel;
    [SerializeField] Button button;
     public void Pause(InputAction.CallbackContext context)
    {
        if (context.performed && !Manadjeur.instance.DialogueStarte )
        {
            button.Select();
            _activeMenu.SetActive(!_activeMenu.activeSelf);
            if (_activeMenu.activeSelf )
            {
                Cursor.lockState=CursorLockMode.None;
                
                Time.timeScale=0;
            }
            if (!_activeMenu.activeSelf )
            {
                 _fermePanel.SetActive(false);
                Time.timeScale=1;
                Cursor.lockState=CursorLockMode.Locked;
                
            }
            
            
        }

        
        
    }
   
}
