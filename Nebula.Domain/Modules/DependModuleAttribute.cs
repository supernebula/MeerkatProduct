﻿using System;

namespace Nebula.Domain.Modules
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class DependOnAttribute : Attribute
    {
        public Type[] DependedModuleTypes;
        public DependOnAttribute(params Type[] dependedModuleTypes)
        {
            DependedModuleTypes = dependedModuleTypes;
        }
    }
}