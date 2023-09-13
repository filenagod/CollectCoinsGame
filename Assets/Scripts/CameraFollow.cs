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
            // a�a��daki kodda transform(cameran�n) LoolAt(z vekt�r�n�) target(topa) e�itledim.
            transform.LookAt(target.transform.position);
        } 
    }

    private Vector3 Calculateoffset (Transform newTarget)
    {
        // Kamera ile oyuncu aras�ndaki mesafeyi hesaplay�n
        return transform.position - newTarget.position;
    }

}
