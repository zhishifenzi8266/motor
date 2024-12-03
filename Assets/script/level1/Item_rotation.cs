using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_rotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        //让金币能够自己旋转

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(new Vector3(0, 50, 0) * Time.deltaTime, Space.Self);
    }
}
