using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool doMovement = true;

    public float panSpeed = 10f;
    public float panBorderThickness = 10f;

    public float scrollSpeed = 5f;
    public float minY = 16.8f;
    public float maxY = 28.75f;

    public float maxX = 91.29f;
    public float minX = 46f;

    public float minZ = 25f;
    public float maxZ = 75f;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            doMovement = !doMovement;
        }

        if (!doMovement)
        {
            return;
        }


        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * 100 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;



        if (Input.GetKey("right"))
        {
            if (pos.z >= minZ && pos.z <= maxZ)
            {
                transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
            }
            else
            {
                transform.position = transform.position - new Vector3(0, 0, 0.75f);
            }
        } 
        

        if (Input.GetKey("left"))
        {
            if (pos.z >= minZ && pos.z <= maxZ)
            {
                transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
            }
            else
            {
                transform.position = transform.position + new Vector3(0, 0, 0.75f);
            }
        }

        if (Input.GetKey("down"))
        {
            if (pos.x >= minX && pos.x <= maxX)
            {
                transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
            }
            else
            {
                transform.position = transform.position - new Vector3(0.75f, 0, 0);
            }        
        }

        if (Input.GetKey("up"))
        {
            if (pos.x >= minX && pos.x <= maxX)
            {
                transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
            }
            else
            {
                transform.position = transform.position + new Vector3(0.75f, 0, 0);
            }
        }
        
    }
}
