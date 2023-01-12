using System;
using System.Collections.Generic;
using ConsoleAppFrameWork.Medical_Research_Application;
using ConsoleAppFrameWork;

using UIComponent;
using System.Collections;

namespace UIComponent
{

    class UIDesign
    {
        private static string menu = "--------------------MEDICAL RESEARCH APPLICATION--------------------------- \nTO ADD DISEASE TO THE SYSTEM ENTER--------------1\nTO ADD SYMPTOMS TO THE DISEASE ENTER -----------2 \nTO CHECK PATIENT ENTER--------------------------3 \nTO EXIT ENTER ANY OTHER---------------------------";
        // enum Option { AddDisesse=1,AddSymptoms,CheckPatient};

        private static ArrayList DeseaseRecord = new ArrayList();
        private static ArrayList SymptomsRecord = new ArrayList();
        //private static ArrayList split = new ArrayList();
        private static ArrayList splitted = new ArrayList();
        private static ArrayList split = new ArrayList();
        public static void Display()
        {
            Console.WriteLine(menu);
            bool processing = true;
            do
            {
                int choice = Utilities.GetNumber("Enter the Choice");
                processing = SelectActions(choice);
            } while (processing);
        }
        public static bool SelectActions(int choice)
        {

            switch (choice)
            {
                case 1:
                    AddDisesse();
                    break;
                case 2:
                    AddSymptoms();
                    break;
                case 3:
                    CheckPatient();
                    break;
                default:
                    return false;

            }
            return true;
        }
        //public static cause { Exterval_factore=1, Interval_factors}
        static void AddDisesse()
        {
            string Name = Utilities.Prompt("Enter the Name");
            string Severity = Utilities.Prompt("Enter the severity [High, Medium, Low]");
            string Cause = Utilities.Prompt(" Enter the factor:  Externel Factor or internal Factor ");
            string Description = "";
        repeat:
            try
            {

                Description = Utilities.Prompt("Enter description[size should be greater than 30 character]");
                if (Description.Length <30)
                {
                    throw new Exception("Description length must be less than 30 charactors");
                }
            }
            catch
            {
                goto repeat;
            }
            DiseaseClass des = new DiseaseClass { Name = Name, Severity = Severity, Cause = Cause, Description = Description };
            DeseaseRecord.Add(des);
            Console.WriteLine(" Record Added Successfully");

        }

        static void AddSymptoms()
        {
            Console.WriteLine("Enter the Disesse Name\n" + "These are the list of Disesses Enter What Disease which you want to add Symptoms ");
            for (int i = 0; i < DeseaseRecord.Count; i++)
            {
                var UnBound = DeseaseRecord[i] as DiseaseClass;
                Console.WriteLine(UnBound.Name);
            }
            string Disesse = Console.ReadLine();
            String SymptomName = Utilities.Prompt("Enter The Symptoms[You can enter multiple symptoms separated by ,]");
            string Descrip = Utilities.Prompt("Enter the Description 0f the Disesse");
            Symptom smp = new Symptom { Disesse = Disesse, SymptomName = SymptomName, Descrip = Descrip };
            SymptomsRecord.Add(smp);
        }
        static void CheckPatient()
        {
            ArrayList foundDiseases = new ArrayList();
            string PatientName = Utilities.Prompt("Enter the Patient Name");
            string[] array = new string[SymptomsRecord.Count];
            foreach (var item in SymptomsRecord)
            {
                var UnBound = item as Symptom;
                var item1 = UnBound.SymptomName;
                var words = item1.Split(',');
                //Console.WriteLine(words);

                for (int i = 0; i < words.Length; i++)
                {
                      splitted.Add(words[i]);
                 }
                

            }
        

            string Symptoms = Utilities.Prompt("Enter the Symptoms");
            Console.WriteLine("THE POSIBBLE DISEASE ARE:");
            foreach (var item in splitted)
            {
                if (Symptoms.Contains(item.ToString()))
                {
                    for (int i = 0; i < SymptomsRecord.Count; i++)
                    {
                        var UnBound = SymptomsRecord[i] as Symptom;
                        if (UnBound.SymptomName.Contains(item.ToString()))
                        {
                            if(!foundDiseases.Contains(disease))
                                foundDiseases.Add(disease);

                        }
                    }
                }
                foreach(var item in foundDiseases){
                    Console.WriteLine(item);
                }

            }

        }
    }
}
    namespace ConsoleAppFrameWork.Medical_Research_Application
    {
        class MedicalApplication
        {
            static void Main(string[] args)
            {
                UIDesign.Display();
            }
        }
    }

