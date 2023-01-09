using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFrameWork.Medical_Research_Application
{
     public class DiseaseClass
    {
       public string Name { get; set; }
       public string Severity { get; set; }
      public  string Cause { get; set; }
        public string Description { get; set; }
    }
    public class Symptom
    {
        public string Disesse { get; set; }
        public string SymptomName { get; set; }
        public string Descrip { get; set; }
       
    }
}
