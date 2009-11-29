////////////////////////////////////////////////////////////////////////
// IntegerElement.cs: holds the data needed to represent an Integer.
// 
// version: 1.0
// description: part of the interpreter example for the visitor design
//  pattern.
// author: Deepak Goyal (dgoyal@syr.edu)
// language: C# .Net 3.5
////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Text;

public class StringElement : Element
{
    StringBuilder sb;

    public StringElement()
    {
        sb = new StringBuilder();
    }

    public override void Accept(Visitor visitor)
    {
        visitor.VisitStringElement(this);
    }

    public string getText() { return sb.ToString(); }
    public void setText(string value) 
    {
        sb.Append(value);
    }
}
