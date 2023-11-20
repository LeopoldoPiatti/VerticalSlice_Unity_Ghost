using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private Camera PlayerCam;
    [SerializeField] private LayerMask pickUpLayerMask;
    [SerializeField] private Transform objectGrabPointTransform;
    [SerializeField] private Transform PickupTarget;
    [SerializeField] private float PickupRange;
    private Rigidbody CurrentObject;

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(1) || Input.GetMouseButton(1))
        {
            if (CurrentObject)
            {
                CurrentObject.freezeRotation = false;
                CurrentObject.useGravity = true;
                CurrentObject = null;
                return;
            }

            Ray CameraRay = PlayerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if (Physics.Raycast(CameraRay, out RaycastHit HitInfo, PickupRange, pickUpLayerMask))
            {
                Debug.DrawRay(CameraRay.origin, CameraRay.direction * PickupRange, Color.green);
                CurrentObject = HitInfo.rigidbody;
                CurrentObject.useGravity = false;
                CurrentObject.freezeRotation = true;
            }
            else
            {
                Debug.DrawRay(CameraRay.origin, CameraRay.direction * PickupRange, Color.red);
            }
        }
        if (CurrentObject)
        {
            Vector3 DirectionToPoint = PickupTarget.position - CurrentObject.position;
            float DistanceToPoint = DirectionToPoint.magnitude;

            CurrentObject.velocity = DirectionToPoint * 12f * DistanceToPoint;
        }
    }
}


