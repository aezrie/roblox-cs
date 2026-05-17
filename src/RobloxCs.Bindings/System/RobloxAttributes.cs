namespace System;

// Putting this in the System namespace means we don't need to add a 'using' statement everywhere
[AttributeUsage(AttributeTargets.Class)]
public class RobloxServiceAttribute : Attribute { }
