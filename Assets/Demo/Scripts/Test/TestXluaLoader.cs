using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using System.IO;

//自定义Loader
public class TestXluaLoader : MonoBehaviour
{
    private LuaEnv luaEnv;
    // Use this for initialization
    void Awake () {
        luaEnv = new LuaEnv();
        //luaEnv.AddLoader(MyLoader);
        luaEnv.AddLoader(MyLoader2);
        //luaEnv.DoString("require 'helloWorld.lua'");
        luaEnv.DoString("require 'TestLua'");
        //访问全局变量 这个变量是在Lua脚本里定义的
        int a = luaEnv.Global.Get<int>("testA");
        print(a);
        luaEnv.Dispose();

    }

    private byte[] MyLoader(ref string filePath)
    {
        string s = "print('best kk')";
        return System.Text.Encoding.UTF8.GetBytes(s);
    }

    //加载完后的回调 filePath 是加载的文件的名字
    private byte[] MyLoader2(ref string filePath)
    {
        print(filePath);
        print(Application.streamingAssetsPath);
        string path = Application.streamingAssetsPath + "/" + filePath + ".lua.txt";
        print(path);
        return System.Text.Encoding.UTF8.GetBytes(File.ReadAllText(path));
    }
}
