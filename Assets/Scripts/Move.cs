using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public GameObject Cube;

    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        float a = (int)(Random.value * 10);
        if (a == 5)
        {
            var b = new System.Random();
            var x = b.Next(0, 2);
            var y = b.Next(0, 4);
            var z = b.Next(0, 5);
            Cube.transform.position = new Vector3(x, y, z);

        }
    }
}
