using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Commands
{
    public abstract class Command : ICommand
    {
        public string name { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string[] patterns { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string[] answers { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public string Exectute()
        {
            return "";
        }

        public void ShowResult()
        {
            throw new System.NotImplementedException();
        }
    }
}