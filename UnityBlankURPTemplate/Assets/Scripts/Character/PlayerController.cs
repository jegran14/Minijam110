
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput), typeof(CapsuleCollider), typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    //Component properties
    private PlayerInput _inputManager;
    private CharacterController _characterController;

    [Header("Editor References")]
    public Transform carryPosition;

    [Header("Movement Properties")]
    //Movement properties
    [SerializeField, Tooltip("Velocidad a la que se mueve el personaje por segundo")] 
    private float moveSpeed = 5.0f;
    [SerializeField, Tooltip("Velocidad a la que rota el personaje por segundo")]
    private float rotationSpeed = 10.0f;
    [SerializeField, Tooltip("Distancia que recorre el personaje durante el impulso")] 
    private float impulseDistance = 10.0f;
    [SerializeField, Tooltip("Tiempo dura el impulso del personaje")]
    private float impulseTime = 0.2f;
    private Vector3 _movement;

    private CharacterStateBase _currentState;
    
    //Getters and Setters
    public Vector3 GetMovement { get => _movement; }
    public float GetMovementSpeed { get => moveSpeed; }
    public float GetRotationSpeed { get => rotationSpeed; }
    public float GetImpulseDistance { get => impulseDistance; }
    public float GetImpulseTime { get => impulseTime; }
    
    private void Awake()
    {
       _characterController = GetComponent<CharacterController>();
       _inputManager = GetComponent<PlayerInput>();
        
        //Subscribe to Input events
        PlayerInputActions inputActions = new PlayerInputActions();
        inputActions.Player.Enable();
        inputActions.Player.Impulse.performed += OnImpulse;
        inputActions.Player.Movement.performed += OnMovement;
        inputActions.Player.Movement.canceled += OnMovementRelease;
    }

    // Start is called before the first frame update
    void Start()
    {
        _currentState = new CharacterDefaultState();
    }

    // Update is called once per frame
    void Update()
    {
        CharacterStateBase resultState = _currentState.Update(this);
        if (_currentState != resultState)
        {
            resultState.Enter(this);
            _currentState = resultState;
        }
    }

    //***** Messages from the Input Manger *****
    void OnImpulse(InputAction.CallbackContext context)
    {
        CharacterStateBase resultState = _currentState.OnImpulse(this);
        if (_currentState != resultState)
        {
            resultState.Enter(this);
            _currentState = resultState;
        }
    }

    void OnMovement(InputAction.CallbackContext context)
    {
        Vector2 inputVector = context.ReadValue<Vector2>();
        _movement = new Vector3(inputVector.x, 0.0f, inputVector.y);

        CharacterStateBase resultState = _currentState.OnMovement(this);
        if (_currentState != resultState)
        {
            resultState.Enter(this);
            _currentState = resultState;
        }
    }

    void OnMovementRelease(InputAction.CallbackContext context)
    {
        _movement = Vector3.zero;

        CharacterStateBase resultState = _currentState.OnMovementEnd(this);
        if (_currentState != resultState)
        {
            resultState.Enter(this);
            _currentState = resultState;
        }
    }
    //******************************************
    
    public void Move(Vector3 dir, float speed)
    {
        _characterController.Move(dir * (speed * Time.deltaTime));
    }

    public void Rotate(Vector3 dir, float speed)
    {
        Quaternion targetRotation = Quaternion.LookRotation(dir, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
    }
}
