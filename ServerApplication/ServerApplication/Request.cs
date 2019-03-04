using System;
using System.Collections.Generic;
using System.Text;

namespace ServerApplication
{
    public class Request
    {

        private string _verb;
        private string _noun;
        private List<string> _args;

        public Request(string verb, string noun, List<string> args) 
        {
            _verb = verb;
            _noun = noun;
            _args = args;
        }

        public string Verb
        {
            get { return _verb; }
            set { _verb = value; }
        }

        public string Noun
        {
            get { return _noun; }
            set { _noun = value; }
        }

        public List<string> Args
        {
            get { return _args; }
            set { _args = value; }
        }

    }
}
