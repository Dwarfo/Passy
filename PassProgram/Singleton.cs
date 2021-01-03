using System;
using System.Collections;
using System.Collections.Generic;

public class Singleton<T> where T : Singleton<T>
{
    public string test = "it's working";
    private static T instance;
    public static T Instance
    {
        get 
        {
            if (!IsInitialized) 
            {
                throw new ArgumentNullException();
            }
            return instance; 
        }
    }

    protected static bool IsInitialized
    {
        get { return instance != null; }
    }
    protected static void Init(T newInstance)
    {
        if (newInstance == null) throw new ArgumentNullException();
        instance = newInstance;
    }
}
