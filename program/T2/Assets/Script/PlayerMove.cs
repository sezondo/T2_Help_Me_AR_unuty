using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float speed = 5f;
    public VariableJoystick joy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //float h = Input.GetAxisRaw("Horizontal");
        //float v = Input.GetAxisRaw("Vertical");

        float h = joy.Horizontal;
        float v = joy.Vertical;



        Vector3 camForward = Camera.main.transform.forward;
        Vector3 camRight = Camera.main.transform.right;
        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        Vector3 moveDir = camForward * v + camRight * h;

        if (moveDir != Vector3.zero)
        {
        transform.rotation = Quaternion.LookRotation(moveDir);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        //GetComponent<Animator>().SetBool("bMove", true);
        }
        else
        {
        //GetComponent<Animator>().SetBool("bMove", false);
        }
        
        
    }
}
