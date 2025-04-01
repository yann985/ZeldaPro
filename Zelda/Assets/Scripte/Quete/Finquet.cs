using Unity.Mathematics;
using UnityEngine;

public class Finquet : MonoBehaviour
{
    [SerializeField] QueteInteraction queteInteraction;
    [SerializeField]  int fin;
    [SerializeField] GameObject gameObject;

    // Update is called once per frame
    void Update()
    {
        if (queteInteraction.Progrétion==fin)
        {
            Instantiate(gameObject,transform.position,transform.rotation);
        }
    }
}
