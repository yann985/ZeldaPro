using UnityEngine;

public class jestionPositionAparition : MonoBehaviour
{ 
    [SerializeField]GameObject player;
    public GameObject PointAparition;
    void Start()
    {
        gameObject.transform.position = PointAparition.transform.position;
    }
}
