using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour
{
    //public Text Text, Text1, Text2;

    public bool chk = true;
    Vector3 directionVector = new Vector3();
    public Camera eyes;
    public Rigidbody rb;
    public GameObject BulletPrefab;
    public Transform firingPoint;
    public float rotationSpeed = 300;
    public float speed = 0.1F;
    public Transform crosshair;
    public int score = 0;
    int jumptimes;
    private Vector3 moveDirection = Vector3.zero;
    CharacterController player;
    float MoveFB;
    float MoveLR;
    float RotX, RotY;
    float vertVelocity;
    float jumpDist = 5f;
    float playerHeight, originalHeight;
    // Use this for initialization
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        player = GetComponent<CharacterController>();
        playerHeight = player.height;
        originalHeight = playerHeight;
    }

    // Update is called once per frame
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        moveDirection = new Vector3(0, 0, 0);
        Vector3 rotation = transform.localEulerAngles;

        if (chk == true)
        {

            MoveFB = Input.GetAxis("Vertical") * speed;
            MoveLR = Input.GetAxis("Horizontal") * speed;
            RotX = Input.GetAxis("Mouse X") * rotationSpeed;
            RotY -= Input.GetAxis("Mouse Y") * rotationSpeed;

            RotY = Mathf.Clamp(RotY, -60f, 60f);
            //new Vector3(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"), 0);
            transform.Rotate(0, RotX, 0);
            eyes.transform.localRotation = Quaternion.Euler(RotY, 0, 0);




            Vector3 movement = new Vector3(MoveLR, vertVelocity, MoveFB);


            movement = transform.rotation * movement;
            player.Move(movement * Time.deltaTime);
            if (Input.GetButtonDown("Crouch"))
            {
                player.height = playerHeight / 2;
            }
            else if (Input.GetButtonUp("Crouch"))
            {
                player.height = originalHeight;
            }
            if (jumptimes < 2)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    jumptimes += 1;
                    vertVelocity += jumpDist;
                }
            }
            Ray ray;
            ray = eyes.ScreenPointToRay(new Vector3(crosshair.position.x, crosshair.position.y, 0));
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
            if (Input.GetButtonDown("Fire1"))
            {
                RaycastHit hit;
                Physics.Raycast(ray.origin, ray.direction, out hit);
                GameObject Bullet = (GameObject)Instantiate(BulletPrefab, firingPoint.position, Quaternion.identity);
                Bullet.transform.LookAt(hit.point);
                //Bullet.GetComponent<Rigidbody>().AddForce(new Vector3(Bullet.transform.forward.x * 500, Bullet.transform.forward.y * 300, Bullet.transform.forward.z * 500));
            }
        }
        if (Input.GetKey(KeyCode.Escape))
            Screen.lockCursor = false;
        else
            Screen.lockCursor = true;
    }
    void FixedUpdate()
    {
        if (player.isGrounded == false)
        {
            vertVelocity += Physics.gravity.y * Time.deltaTime;
        }
        else
        {
            jumptimes = 0;
            vertVelocity = 0f;
        }

    }


}