using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public interface GenConfig {
    //lua中要使用到C#库的配置，比如C#标准库，或者Unity API，第三方库等。
    List<Type> LuaCallCSharp { get; }

    //C#静态调用Lua的配置（包括事件的原型），仅可以配delegate，interface
    List<Type> CSharpCallLua { get; }

    //黑名单
    List<string> BlackList { get; }
}