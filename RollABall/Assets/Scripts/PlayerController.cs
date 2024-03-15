using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class PlayerController : MonoBehaviour
{
    private Rigidbody rb; 
    private int count;
    private float movementX;
    private float movementY;
    public float speed = 0; 
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public Transform childTransform;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody>(); 
        childTransform = transform.GetChild(0);
        count = 0; 
        SetCountText();
        winTextObject.SetActive(false);
    }

    private void FixedUpdate() 
   {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        if (movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            childTransform.rotation = Quaternion.RotateTowards(childTransform.rotation, targetRotation, Time.deltaTime * 500f);
        }
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }   

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMove (InputValue movementValue)
   {
        Vector2 movementVector = movementValue.Get<Vector2>(); 
        movementX = movementVector.x; 
        movementY = movementVector.y;
   }

   void SetCountText() 
   {
       countText.text =  "Count: " + count.ToString();
       if (count >= 5)
       {
           winTextObject.SetActive(true);
       }
   }

      void OnTriggerEnter(Collider other) 
   {
          count = count + 1;
          if (other.gameObject.CompareTag("PickUp")) 
          {
               other.gameObject.SetActive(false); 
               SetCountText();
          }
   }
}
