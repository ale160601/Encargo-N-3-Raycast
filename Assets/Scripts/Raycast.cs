using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Raycast : MonoBehaviour
{
    public float rayDistance = 5f;
    public Transform manos;
    public TextMeshProUGUI productoInfoUI;
    private GameObject grabbedObject;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //mostrar data del producto al apuntarlo
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.collider.CompareTag("Item"))
            {
                Producto producto = hit.collider.GetComponent<Producto>();
                if (producto != null)
                {
                    productoInfoUI.text = producto.GetInfo();
                }
            }
        }
        else
        {
            productoInfoUI.text = "";
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (grabbedObject == null)
            {
                if (Physics.Raycast(ray, out hit, rayDistance))
                {
                    if (hit.collider.CompareTag("Item"))
                    {
                        grabbedObject = hit.collider.gameObject;
                        grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                        grabbedObject.transform.position = manos.position;
                        grabbedObject.transform.parent = manos;
                    }
                }
            }
            else
            {
                DropObject();
            }
        }
    }

    void DropObject()
    {
        grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
        grabbedObject.transform.parent = null;
        grabbedObject = null;
    }
}
