using Photon.Pun;
using UnityEngine;

public class Crouch : MonoBehaviourPun
{
    public float crouchSpeed = 2;
    public float crouchYLocalPosition = 1;
    [Tooltip("Head to lower when we crouch")]
    public Transform head;
    [HideInInspector]
    public float defaultHeadYLocalPosition;

    [Tooltip("Capsule collider to lower when we crouch.\nCan be empty.")]
    public CapsuleCollider capsuleCollider;
    [HideInInspector]
    public float defaultCapsuleColliderHeight;

    public GroundCheck groundCheck;
    public FirstPersonMovement character;

    public KeyCode key = KeyCode.LeftControl;
    public bool IsCrouched { get; private set; }
    public event System.Action CrouchStart, CrouchEnd;


    void Reset()
    {
        if(!photonView.IsMine || !PhotonNetwork.IsConnected)
            return;
        
        head = GetComponentInChildren<Camera>().transform;
        capsuleCollider = GetComponentInChildren<CapsuleCollider>();
        character = GetComponentInParent<FirstPersonMovement>();

        // Get or create the groundCheck object.
        groundCheck = GetComponentInChildren<GroundCheck>();
        if (!groundCheck)
            groundCheck = GroundCheck.Create(transform);
    }

    void Start()
    {
        if(!photonView.IsMine || !PhotonNetwork.IsConnected)
            return;
        
        defaultHeadYLocalPosition = head.localPosition.y;
        if (capsuleCollider)
            defaultCapsuleColliderHeight = capsuleCollider.height;
    }

    void LateUpdate()
    {
        if(!photonView.IsMine || !PhotonNetwork.IsConnected)
            return;
        
        if (Input.GetKey(key))
        {
            // Enforce crouched y local position of the head.
            head.localPosition = new Vector3(head.localPosition.x, crouchYLocalPosition, head.localPosition.z);

            // Lower the capsule collider.
            if (capsuleCollider)
            {
                capsuleCollider.height = defaultCapsuleColliderHeight - (defaultHeadYLocalPosition - crouchYLocalPosition);
                capsuleCollider.center = Vector3.up * capsuleCollider.height * .5f;
            }

            // Set state.
            if (!IsCrouched)
            {
                IsCrouched = true;
                SetSpeedOverrideActive(true);
                CrouchStart?.Invoke();
            }
        }
        else if (IsCrouched)
        {
            // Reset the head to its default y local position.
            head.localPosition = new Vector3(head.localPosition.x, defaultHeadYLocalPosition, head.localPosition.z);

            // Reset the capsule collider's position.
            if (capsuleCollider)
            {
                capsuleCollider.height = defaultCapsuleColliderHeight;
                capsuleCollider.center = Vector3.up * capsuleCollider.height * .5f;
            }

            // Reset state.
            IsCrouched = false;
            SetSpeedOverrideActive(false);
            CrouchEnd?.Invoke();
        }
    }


    void SetSpeedOverrideActive(bool state)
    {
        if(!photonView.IsMine || !PhotonNetwork.IsConnected)
            return;
        
        if (state && !character.speedOverrides.Contains(SpeedOverride))
            character.speedOverrides.Add(SpeedOverride);
        if (!state && character.speedOverrides.Contains(SpeedOverride))
            character.speedOverrides.Remove(SpeedOverride);
    }

    float SpeedOverride() => crouchSpeed;
}
