using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private Transform target;
    [SerializeField] private float cameraFollowSpeed = 5f;
    private Vector3 offsetVector;

    // Start is called before the first frame update
    void Start()
    {
        offsetVector = Calculateoffset(target);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveTheCamera();
    }

    private void MoveTheCamera()
    {
        if (target != null)
        {
            Vector3 targetToMove = target.position + offsetVector;
            transform.position = Vector3.Lerp(transform.position, targetToMove, Time.deltaTime * cameraFollowSpeed);
            // aþaðýdaki kodda transform(cameranýn) LoolAt(z vektörünü) target(topa) eþitledim.
            transform.LookAt(target.transform.position);
        } 
    }

    private Vector3 Calculateoffset (Transform newTarget)
    {
        // Kamera ile oyuncu arasýndaki mesafeyi hesaplayýn
        return transform.position - newTarget.position;
    }

}
