using UnityEngine;
using UnityEngine.InputSystem;

public class Blag : MonoBehaviour
{
    [SerializeField] GameObject gameObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            //gameObject.SetActive
        }
    }
}
