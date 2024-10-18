using System;
[AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
public class ButtonAttribute : Attribute
{
    public string ButtonLabel { get; private set; }
    public ButtonAttribute(string buttonLabel = null)
    {
        ButtonLabel = buttonLabel;
    }
}