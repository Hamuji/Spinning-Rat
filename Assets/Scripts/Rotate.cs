using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    bool isDragging = false;
    public GameObject soundManager;
    Rigidbody rb;

    public AudioSource audio_;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audio_ = GameObject.Find("Free Bird").GetComponent<AudioSource>();
    }

    void OnMouseDrag()
    {
        isDragging = true;
/*        soundManager.SetActive(true);
*/    }


    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
/*            soundManager.SetActive(false);
*/            audio_.Pause();
        }
    }

    void FixedUpdate()
    {
        if (isDragging)
        {
            float x = Input.GetAxis("Mouse X") * rotationSpeed * Time.fixedDeltaTime;
            float y = Input.GetAxis("Mouse Y") * rotationSpeed * Time.fixedDeltaTime;

            rb.AddTorque(Vector3.down * x);
            rb.AddTorque(Vector3.right * y);
            audio_.UnPause();

        }
    }
}
