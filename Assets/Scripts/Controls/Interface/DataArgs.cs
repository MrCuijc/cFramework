using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DataArgs<T> : EventArgs
{
    T t;

    public DataArgs(T t)
    {
        this.t = t;
    }

    public T Data { get { return t; } }
}
