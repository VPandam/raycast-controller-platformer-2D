using UnityEngine;

[RequireComponent(typeof(Controller))]
public class Player : MonoBehaviour {
    float moveSpeed = 6;
    float gravity = -20f;
    Vector3 velocity;
    Controller playerController;

    void Start() {
        playerController = GetComponent<Controller>();


    }
    private void Update() {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        velocity.x = input.x * moveSpeed;
        velocity.y += gravity * Time.deltaTime;
        playerController.Move(velocity * Time.deltaTime);
    }


}
