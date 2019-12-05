using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

 namespace May25th.Update
{
    public class TestXlua : MonoBehaviour
    {
        //LuaEnv可以理解为lua虚拟机，往往整个工程一个虚拟机即可
        private LuaEnv luaenv;
        // Start is called before the first frame update
        void Start()
        {

            //虚拟机的创建
            luaenv = new LuaEnv();
            luaenv.DoString("print(\"hello world\")");
            luaenv.DoString("CS.UnityEngine.Debug.Log('hello world 2')");
            TestLoad();
        }

        private void OnDestroy()
        {
            //虚拟机的销毁
            luaenv.Dispose();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void TestLoad()
        {
            //加载helloWorld.lua.txt,TextAsset会自动加txt的后缀
            //Resources Load 只能加载根目录下Resrouces文件夹内的资源 别的地方做不到 如果可以做到再改
            TextAsset ta2 = Resources.Load<TextAsset>("TestLua.lua");
            luaenv.DoString(ta2.text);
            luaenv.Dispose();
        }
    }
}
