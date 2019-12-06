using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

 namespace May25th.Update
{
    //测试LuaCallCSharp 标签
    //自定义类被Lua访问到
    [LuaCallCSharp]
    public class TestLuaCallCSharp : MonoBehaviour
    {
        public static void SayHello()
        {
            Debug.Log("静态方法, I am static function");
        }

        public void SayHello2()
        {
            Debug.Log("实例方法, I am model function");
        }

        public void SayHello2(string value)
        {
            Debug.Log("实例方法带参数, 参数->" + value);
        }

        public string SayHello3(string s)
        {
            Debug.Log("我是具有返回值的CS方法:" + s);
            return "你好，我获得了lua，我是C#";
        }

        public void SayHelloWithRefParam(ref string s)
        {
            s = "Hello 我是C# ref";
        }

        public int SayHelloWithRefParamAndReturnInt(ref int s)
        {
            return s + 1;
        }
        public void SayHelloWithOutParam(out string s)
        {
            s = "Hello，我是C#";
            Debug.Log("Hello Aladdin_XLua, I am model function whih out param:" + s);
        }
    }
}
