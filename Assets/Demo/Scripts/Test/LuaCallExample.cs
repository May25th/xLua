using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

namespace May25th.Update
{
    public class LuaCallExample : MonoBehaviour
    {
        private LuaEnv luaEnv;
        void Start()
        {
            luaEnv = new LuaEnv();
            luaEnv.DoString("print(\"hello world\")");
            
            luaEnv.DoString(
                @"
                print('Lua访问特性标记的对象方法')
                local luaM2 = CS.May25th.Update.TestLuaCallCSharp
                local luaO2 = luaM2()
                luaM2:SayHello()
                luaO2:SayHello2()
                luaO2:SayHello2('test')
                local value = luaO2:SayHello3('test')
                print(value)
                local ref_value = 'test'
                local outputValue = luaO2:SayHelloWithRefParam(ref_value)
                print('ref_value',  ref_value)
                print('outputValue', outputValue)

                local test_int = 1;
                local test_back_int, test_int = luaO2:SayHelloWithRefParamAndReturnInt(test_int)
                print(test_int, test_back_int)
                "
            );
            /**/
        }

        private void OnDestroy()
        {
            //虚拟机的销毁
            luaEnv.Dispose();
        }
    }
}
