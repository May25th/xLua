using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestOut : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Check();
    }

    void Check()
    {
        int[] datas = new int[5]{61,2,3,4,6};
        int min, max, sum;
        CheckAry(datas, out min, out max, out sum);
        print(min);
        print(max);
        print(sum);
    }

    private void CheckAry(int[] datas, out int min, out int max, out int sum)
    {
        min = int.MaxValue;
        max = int.MinValue;
        sum = 0;
        for(int i= 0; i< datas.Length; i++)
        {
            if(min > datas[i])
            {
                min = datas[i];
            }
            if(max < datas[i])
            {
                max = datas[i];
            }
            sum += datas[i];
        }
    }
}
