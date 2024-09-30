using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotation = new Vector3(0, 300, 0) * Time.deltaTime;
        transform.Rotate(rotation);
    }
    private void OnTriggerEnter(Collider other) // trigger porque lo quiero atravesar
    {
        if (other.gameObject.GetComponent<PlayerMovement_RB>())
        {
            GameManager.instance.IncreaseScore(1); // llamamos al gamemanager para que el metodo de increase score pueda sumar los puntos de uno en uno (1) cundo coge una pocion.
            Destroy(gameObject);

        }
    }
}
