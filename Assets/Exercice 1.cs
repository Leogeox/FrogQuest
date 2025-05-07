using System;
using Unity.VisualScripting;
using UnityEngine;

class People
{
    protected string nameEmployee;
    protected int ageEmployee;
    protected string genderEmployee;
}

class Employee : People
{
    public int idEmployee;
    public string postEmployee;

    public string NameEmployee
    {
        get => nameEmployee;
        set => nameEmployee = value;
    }
    public int AgeEmployee
    {
        get => ageEmployee;
        set => ageEmployee = value;
    }

    public string GenderEmployee
    {
        get => genderEmployee;
        set => genderEmployee = value;
    }

    void ChangeInfos(string name, int age, string gender)
    {
        nameEmployee = "Leo";
        ageEmployee = 18;
        genderEmployee = "Boy";
    }
}

class Modification
{
    public void NewEmployee()
    {
        Employee MyEmployee = new Employee();
        MyEmployee.idEmployee = 2;
        MyEmployee.postEmployee = "Manager";
        MyEmployee.NameEmployee = "Neil";
        MyEmployee.AgeEmployee = 23;
        MyEmployee.GenderEmployee = "Girl";

        Console.WriteLine("My employee name is : " + MyEmployee.NameEmployee);
        Console.WriteLine("My employee age is : " + MyEmployee.AgeEmployee);
        Console.WriteLine("My employee is a: " + MyEmployee.GenderEmployee);
        Console.WriteLine("My employee post is : " + MyEmployee.postEmployee);
        Console.WriteLine("My employee ID is : " + MyEmployee.idEmployee);
    }
}




