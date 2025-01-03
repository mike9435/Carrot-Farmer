using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 cameraOffset = new Vector3 (0, 5, -8);
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void LateUpdate()
    {
        cameraOffset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * 2, Vector3.up) * cameraOffset;
        transform.position = player.transform.position + cameraOffset;
        transform.LookAt(player.transform.position);
    }
}
