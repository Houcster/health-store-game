using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragBodies : MonoBehaviour
{
    public float forceAmount = 500;

    Rigidbody2D selectedRigidbody;
    Camera targetCamera;
    Vector3 originalScreenTargetPosition;
    Vector3 originalRigidbodyPos;
    float selectionDistance;
    public LayerMask NeedLayer;

    // Start is called before the first frame update
    void Start()
    {
        targetCamera = GetComponent<Camera>();
    }

    void Update()
    {
        if (!targetCamera)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            //Check if we are hovering over Rigidbody, if so, select it
            selectedRigidbody = GetRigidbodyFromMouseClick();
        }

        if (Input.GetMouseButtonUp(0) && selectedRigidbody)
        {
            //Release selected Rigidbody if there any
            selectedRigidbody = null;
        }

        if (Input.touches.Length > 1)
        {
            selectedRigidbody = null;
        }
    }

    void FixedUpdate()
    {
        //print(Input.GetTouch(0).position.x);
        //if (selectedRigidbody)
        if (selectedRigidbody && Input.touches.Length > 0)
        {
            //print(Input.GetTouch(0).position.x);
            //Vector3 mousePositionOffset = targetCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, selectionDistance)) - originalScreenTargetPosition;
            Vector3 mousePositionOffset = targetCamera.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, selectionDistance)) - originalScreenTargetPosition;
            selectedRigidbody.velocity = (originalRigidbodyPos + mousePositionOffset - selectedRigidbody.transform.position) * forceAmount * Time.deltaTime;
        }
    }

    /*Rigidbody2D GetRigidbodyFromMouseClick()
    {
        RaycastHit2D hitInfo = new RaycastHit2D();
        //Ray ray = targetCamera.ScreenPointToRay(Input.mousePosition);
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        bool hit = Physics2D.Raycast(cursorPos, Vector2.zero);
        Debug.Log("Try hit");
        if (hit)
        {
            RaycastHit2D[] allHits = Physics2D.RaycastAll(cursorPos, Vector2.zero);
            for (int i = 0; i & lt; allHits.Length; i++)
            {
                Debug.Log(allHits[i].transform.name);
            }
            Debug.Log("got hit");
            if (hitInfo.collider.gameObject.GetComponent<Rigidbody2D>())
            {
                
                //selectionDistance = Vector3.Distance(cursorPos.origin, hitInfo.point);
                originalScreenTargetPosition = targetCamera.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
                originalRigidbodyPos = hitInfo.collider.transform.position;
                return hitInfo.collider.gameObject.GetComponent<Rigidbody2D>();
            }
        }

        return null;
    }*/

    Rigidbody2D GetRigidbodyFromMouseClick()
    {
        Vector2 CurMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //јнализировать будем только при нажатии мышки

        //RaycastHit2D rayHit = Physics2D.Raycast(CurMousePos, Vector2.zero);
        RaycastHit2D rayHit = Physics2D.Raycast(CurMousePos, Vector2.zero, 10f, NeedLayer);
        if (rayHit.transform != null && !Main.isGameOver)
        {
            //Debug.Log("Selected object: " + rayHit.transform.name);
            rayHit.collider.attachedRigidbody.bodyType = RigidbodyType2D.Dynamic;
         
            return rayHit.collider.attachedRigidbody;
        }

            /*RaycastHit2D[] allHits = Physics2D.RaycastAll(CurMousePos, Vector2.zero);

            for (int i = 0; i < allHits.Length; i++)
            {
                Debug.Log(allHits[i].transform.name);
            }

            RaycastHit2D maskHit = Physics2D.Raycast(CurMousePos, Vector2.zero, 10f, NeedLayer);
            if (maskHit.transform != null)
                Debug.Log("Layer object: " + maskHit.transform.name);*/

        
        return null;
    }
}