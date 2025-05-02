using System;
using UnityEngine;

class Shape
{
    private string _forme;

    public string Forme
    {
        get => _forme;
        set => _forme = value;
    }

    public virtual void WriteShape()
    {
       Console.WriteLine("This is a Shape");
    }
}

class Circle : Shape
{
    public override void WriteShape()
    {
        base.WriteShape();
        Console.WriteLine("This is a Circle");
    }
}

class Square : Shape
{
    public override void WriteShape()
    {
        base.WriteShape();
        Console.WriteLine("This is a Square");
    }
}

class Call
{
    Shape Triangle = new Shape();
    Shape Star = new Shape();

    public void WriteShape()
    {
        Console.WriteLine("This is a Triangle");
        Triangle.WriteShape();

        Console.WriteLine("This is a Star");
        Star.WriteShape();
    }
}