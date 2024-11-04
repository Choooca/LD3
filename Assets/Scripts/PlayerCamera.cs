using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform cameraPivot;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Vector2 _MouseSpeed = new Vector2(8f, 8f);
    [SerializeField, Range(0, 1)] private float _Friction = .5f;

    [SerializeField] private Vector2 _MinMaxPitch = new Vector2(20, 60);
    [SerializeField] private float startPitchAngle = 33;
    [SerializeField] private float startYawAngle = 100;

    private float _Yaw, _Pitch;
    public float yawAngle, pitchAngle;

    private int frameCounter = -1;

    private void Start()
    {
        yawAngle = startYawAngle;
        pitchAngle = startPitchAngle;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        ++frameCounter;
        if (frameCounter < 1) return;

        // rotate the player
        // get the yaw and pitch
        _Yaw += Input.GetAxis("HorizontalMouse") * _MouseSpeed.x * Time.deltaTime;
        _Pitch += Input.GetAxis("VerticalMouse") * _MouseSpeed.y * Time.deltaTime;

        // set the angles
        yawAngle = (yawAngle + _Yaw) % 360f;
        pitchAngle += _Pitch;
        pitchAngle = Mathf.Clamp(pitchAngle, _MinMaxPitch.x, _MinMaxPitch.y);

        // apply the friction
        _Yaw *= 1 - _Friction;
        _Pitch *= 1 - _Friction;

        // apply rotation and set player forward
        cameraPivot.rotation = Quaternion.AngleAxis(yawAngle - 180, Vector3.up) * Quaternion.AngleAxis(pitchAngle, Vector3.right);
        playerTransform.forward = Vector3.Scale(cameraPivot.rotation * Vector3.forward, new Vector3(1, 0, 1)).normalized;
    }
}
