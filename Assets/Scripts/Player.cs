using UnityEngine;

[RequireComponent(typeof(Controller))]
public class Player : MonoBehaviour
{
    Controller playerController;
    void Start()
    {
        playerController = GetComponent<Controller>();
    }

}
