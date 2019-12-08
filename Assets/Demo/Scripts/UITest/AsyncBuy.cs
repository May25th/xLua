using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class AsyncBuy : MonoBehaviour
{
    LuaEnv luaenv = null;
 
    void Start()
    {
        luaenv = new LuaEnv();
        luaenv.DoString("require 'async_buy'");
    }
 
    // Update is called once per frame
    void Update()
    {
        if (luaenv != null)
        {
            luaenv.Tick();
        }
    }
}
