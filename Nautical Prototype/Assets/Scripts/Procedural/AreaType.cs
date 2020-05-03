using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaType : MonoBehaviour
{
    public int type;

    public void areaDestroy()
    {
        Destroy(gameObject);
    }
}
