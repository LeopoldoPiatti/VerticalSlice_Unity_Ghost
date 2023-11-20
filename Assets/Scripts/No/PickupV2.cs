using UnityEngine;

public class PickupV2 : MonoBehaviour
{
    [Header("Pickup Settings")]
    [SerializeField] Transform holdArea;
    [SerializeField] private LayerMask pickUpLayerMask;
    private GameObject heldObj;
    private Rigidbody heldObjRb;

    [Header("Physics Parameters")]
    [SerializeField] private float pickupRange;
    [SerializeField] private float pickupForce;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)/* || Input.GetMouseButton(1)*/)
        {
            if(heldObj == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange, pickUpLayerMask))
                {
                    PickupObject(hit.transform.gameObject);
                    Debug.DrawRay(transform.position, transform.forward, Color.green);
                }
            }
            else 
            {
                DropObject();
            }
        
            if (heldObj != null)
            {
                MoveObject();
            }
    }

    void MoveObject()
        {
            if (Vector3.Distance(heldObj.transform.position, holdArea.position) > 0.1f)
            {
                Vector3 moveDirection = (holdArea.position - heldObj.transform.position);
                heldObjRb.AddForce(moveDirection * pickupForce);
            }
        }

    void PickupObject (GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
            {
            heldObjRb = pickObj.GetComponent<Rigidbody>();
            heldObjRb.useGravity = false;
            heldObjRb.drag = 10;
            heldObjRb.constraints = RigidbodyConstraints.FreezeRotation;
            heldObjRb.transform.parent = holdArea;
            heldObj = pickObj;
            }
    }

    void DropObject()
    {        
            heldObjRb.useGravity = true;
            heldObjRb.drag = 1;
            heldObjRb.constraints = RigidbodyConstraints.None;
            heldObjRb.transform.parent = null;
            heldObj = null;        
    }
    }
}
