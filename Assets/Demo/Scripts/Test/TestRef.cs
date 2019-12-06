using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRef : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string test = "test";
        SayHelloWithRefParam(ref test);
        Debug.Log("结果是:" + test);
    }

    public void SayHelloWithRefParam(ref string s)
    {
        Debug.Log("传入的参数是:" + s);
        s = "Hello 我是C# ref";
    }
}
