using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float speed = 35f;
    public float borderThickness = 10f;
    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;
    public float minZ = -84f;
    public float maxZ = 7f;
    public float minX = 0f;
    public float maxX = 60f;

    private bool moveCamera = true;

	void Update()
    {
        MouseMovement();
        ScrollMovement();
    }

    private void MouseMovement()
    {
        if (Input.GetKeyDown(KeyCode.F))
            moveCamera = !moveCamera;

        if (!moveCamera)
            return;

        if (Input.mousePosition.y <= borderThickness && transform.position.x <= maxX)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
        }
        if (Input.mousePosition.y >= Screen.height - borderThickness && transform.position.x >= minX)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }
        if (Input.mousePosition.x <= borderThickness && transform.position.z >= minZ)
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
        }
        if (Input.mousePosition.x >= Screen.width - borderThickness && transform.position.z <= maxZ)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
        }
    }

    private void ScrollMovement()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        var pos = transform.position;
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }
}
