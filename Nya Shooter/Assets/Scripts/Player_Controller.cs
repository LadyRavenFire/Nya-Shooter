using UnityEngine;

public class Player_Controller : MonoBehaviour
{

    [SerializeField] private float speed = 5f;
    [SerializeField] private float lookSensivity = 3f;

    private Player_Motor motor;

    void Start()
    {
        motor = GetComponent<Player_Motor>();
    }

    void Update()
    {
        //Calculate movement velocity as a 3D vector    
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");

        Vector3 _movHorizontal = transform.right * _xMov;
        Vector3 _movVertical = transform.forward * _zMov;

        //Final movement vector
        Vector3 _velocity = (_movVertical + _movHorizontal).normalized * speed;

        //Apply movement
        motor.Move(_velocity);

        //Calculate rotation as a 3D vector (turning around)
        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensivity;

        //Apply rotation
        motor.Rotate(_rotation);

        //Calculate camera rotation as a 3D vector (turning around)
        float _xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 _cameraRotation = new Vector3(_xRot, 0f, 0f) * lookSensivity;

        //Apply camera rotation
        motor.RotateCamera(_cameraRotation);
    }
}
