﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class GenericExample<T1,T2> where T1: MonoBehaviour 
    {
        public T1 Value1 { get; set; }
        public T2 Value2 { get; set; }

        public GenericExample(T1 value1,T2 value2)
        {
            Value1 = value1;
            Value2 = value2;
        }

        public void DisplayValue()
        {

        }

    }
}
