﻿using System;

[assembly: CLSCompliant(true)]
namespace Examples.Fundamentals
{
    [CLSCompliant(false)]
    public class CLSCompliant
    {
        public uint i; //uint not in CLS 

        public int I; //identifier differing only by case
    }
}
