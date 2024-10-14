using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public float rayDistance = 5f;
    public Transform manos;
    private GameObject grabbedObject;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (grabbedObject == null)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                //Raycast para detectar el objeto
                if (Physics.Raycast(ray, out hit, rayDistance))
                {
                    if (hit.collider.CompareTag("Item")) //el objeto debe tener la etiqueta "Item"
                    {
                        grabbedObject = hit.collider.gameObject;

                        //verifica si el objeto esta en el inventario
                        if (FindObjectOfType<Inventory>().items.Contains(grabbedObject))
                        {
                            FindObjectOfType<Inventory>().RemoveFromInventory(grabbedObject);
                        }

                        grabbedObject.GetComponent<Rigidbody>().isKinematic = true; //evita que caiga
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

    void OnTriggerEnter(Collider other)
    {
        if (grabbedObject != null && other.CompareTag("InventoryArea"))
        {
            //añade el objeto al inventario cuando entra en el área del plano
            FindObjectOfType<Inventory>().AddToInventory(grabbedObject);
            DropObject();
        }
    }

    void DropObject()
    {
        grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
        grabbedObject.transform.parent = null;
        grabbedObject = null;
    }
}
