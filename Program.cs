using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace structs
{
    class Program
    {
        #region ReadInt
        /// <summary>
        /// Safely read int number
        /// </summary>
        /// <returns></returns>
        public static int ReadInt()
        {
            string str = null;
            int num;
            while (!int.TryParse(str, out num))
            {
                str = Console.ReadLine();
            }
            str = null;

            return num;
        }
        #endregion
        static void Main(string[] args)
        {
            string str = null;
            Console.Write("How many groups do u have?");
            int nmbr = ReadInt();
            Group[] ourGr = CreateGroup(nmbr);
            bool state = true;
            while (state)
            {
                Console.Write("#>");
                string command = Console.ReadLine();
                switch (command)
                {
                    case "FillGroup":
                        Console.Write("select group for filling:");
                        nmbr = ReadInt();
                        ourGr[nmbr] = FillGroup(ourGr[nmbr].Size, ourGr[nmbr]);
                        break;
                    case "ShowGroup":
                        Console.Write("select group to show:");
                        nmbr = ReadInt();
                        ShowGroup(ourGr[nmbr]);
                        break;
                    case "AddStudent":
                        Console.Write("Select group where u need to add student:");
                        nmbr = ReadInt();
                        ourGr[nmbr] = AddStudent(ourGr[nmbr]);
                        break;
                    case "EditStudent":
                        Console.WriteLine("Select group where we need edit student");
                        nmbr = ReadInt();
                        ourGr[nmbr] = EditStudent(ourGr[nmbr]);
                        break;
                    case "Help":
                        Console.Write("Commands: AddStudent, FillGroup, ShowGroup ");
                        Console.Write("EditStudent, DeleteStudent\n");
                        break;
                    case "DeleteStudent":
                        Console.Write("Select group where u need to delete student:");
                        nmbr = ReadInt();
                        ourGr[nmbr] = DeleteStudent(ourGr[nmbr]);
                        break;
                    case "Exit": state = false; break;
                    case "": break;
                    default: Console.WriteLine("Error. Try Again."); break;
                }                
            }
            Console.ReadKey();
        }
        #region STUB
        /// <summary>
        /// stub
        /// </summary>
        public static void FStub()
        {
            Console.WriteLine("this function is being developen now");
        }
        #endregion

        /// <summary>
        /// Add student to group
        /// </summary>
        /// <param name="opGroup"></param>
        /// <returns></returns>
        public static Group AddStudent(Group opGroup)
        {
            string str;
            Student nstud;
            Console.WriteLine("new student:");
            Console.Write("number of card:");
            nstud.idCard = Console.ReadLine();
            Console.Write("Name:");
            nstud.Name = Console.ReadLine();
            Console.Write("Surname:");
            nstud.Surname = Console.ReadLine();
            nstud.groupNum = opGroup.GID;
            Console.Write("Age:");
            nstud.age = ReadInt();
            str = null;
            Console.Write("Gender(male or female):");
            str = Console.ReadLine();
            switch (str)
            {
                    case "male": nstud.gndr = gender.male; break;
                    case "female": nstud.gndr = gender.female; break;
                    default: nstud.gndr = gender.undefined; break;
            }
            str = null;
            //Group tmpgr = opGroup;
            opGroup.Size = opGroup.Size + 1;
            opGroup.Traines = new Student[opGroup.Size];
            //opGroup = tmpgr;
            int d = opGroup.Traines.GetLength(0) - 1;
            opGroup.Traines[d] = nstud;
            
            return opGroup;
        }

        /// <summary>
        /// Delete student from group
        /// </summary>
        /// <param name="dGroup"></param>
        /// <returns></returns>
        public static Group DeleteStudent(Group dGroup)
        {
            Group tmpGr=dGroup;
            dGroup.Size = dGroup.Size - 1;
            dGroup.Traines = new Student[dGroup.Size];
            Console.WriteLine("input #IDcard of student to delete:");
            string str = Console.ReadLine();
            bool state = true;
            for (int i = 0, j = 0; i < dGroup.Traines.GetLength(0); i++, j++)
            {
                if (dGroup.Traines[i].idCard == str) { j++; }
                dGroup.Traines[i] = tmpGr.Traines[j];
            }
            return dGroup;
        }

        /// <summary>
        /// Edit student data in group
        /// </summary>
        /// <param name="eGroup"></param>
        /// <returns></returns>
        public static Group EditStudent(Group eGroup)
        {
            Console.WriteLine("input #IDcard of student:");
            string str=Console.ReadLine();
            bool state = true;
            for (int i = 0; i < eGroup.Traines.GetLength(0); i++)
            {
                if (eGroup.Traines[i].idCard == str) 
                {
                    Console.Write("##>Select data to edit(n-Name, s-Surname, i-idCard, a-age");
                    Console.WriteLine(" g-gndr,e-end edit):");
                    while (state)
                    {
                        Console.Write("##>");
                        str=Console.ReadLine();
                        switch (str)
                        {
                            case "n": eGroup.Traines[i].Name = Console.ReadLine(); break;
                            case "s": eGroup.Traines[i].Surname = Console.ReadLine(); break;
                            case "i": eGroup.Traines[i].idCard = Console.ReadLine(); break;
                            case "a": eGroup.Traines[i].age = ReadInt(); break;
                            case "g":
                                {
                                    Console.WriteLine("select gender(m-male, f-female)");
                                    string gst = Console.ReadLine();
                                    switch (gst)
                                    {
                                        case "m": eGroup.Traines[i].gndr = gender.male; break;
                                        case "f": eGroup.Traines[i].gndr = gender.female; break;
                                        default: eGroup.Traines[i].gndr = gender.undefined; break;
                                    }
                                    break;
                                }
                            case "e": state = false; break;
                            default: Console.WriteLine("error");
                                break;
                        }
                    }
                }
            }

            return eGroup;
        }

        /// <summary>
        /// Filling selected group
        /// </summary>
        /// <param name="grSize"></param>
        /// <param name="newGr"></param>
        /// <returns></returns>
        public static Group FillGroup(int grSize, Group newGr)
        {
            string str = null;
           // Group newGr;
            Console.Write("inpun id of group(int value inly):");
            newGr.GID = ReadInt();
            newGr.Traines = new Student[grSize];
            for (int i = 0; i < newGr.Traines.GetLength(0); i++)
            {
                Console.WriteLine(i + 1 + " student:");
                Console.Write("number of card:");
                newGr.Traines[i].idCard = Console.ReadLine();
                Console.Write("Name:");
                newGr.Traines[i].Name = Console.ReadLine();
                Console.Write("Surname:");
                newGr.Traines[i].Surname = Console.ReadLine();
                newGr.Traines[i].groupNum = newGr.GID;
                Console.Write("Age:");
                newGr.Traines[i].age = ReadInt();
                Console.Write("Gender(male or female):");
                str = Console.ReadLine();
                switch (str)
                {
                    case "male": newGr.Traines[i].gndr = gender.male; break;
                    case "female": newGr.Traines[i].gndr = gender.female; break;
                    default: newGr.Traines[i].gndr = gender.undefined; break;
                }
                str = null;
            }

            return newGr;
        }

        /// <summary>
        /// Show selected group
        /// </summary>
        /// <param name="groupToShow"></param>
        public static void ShowGroup(Group groupToShow)
        {
            for (int i = 0; i < groupToShow.Traines.GetLength(0); i++)
            {
                Console.Write("Student " + groupToShow.Traines[i].Name + " ");
                Console.Write(groupToShow.Traines[i].Surname);
                Console.Write(" studies in group " + groupToShow.Traines[i].groupNum + ".");
                switch (groupToShow.Traines[i].gndr)
                {
                    case gender.undefined: Console.Write(" It is ");
                        break;
                    case gender.male: Console.Write(" He is ");
                        break;
                    case gender.female: Console.Write(" She is ");
                        break;
                    default:
                        break;
                }
                Console.Write(groupToShow.Traines[i].age + " years old");
                Console.WriteLine(" and has IDcard #" + groupToShow.Traines[i].idCard + ".\n");
            }
            
        }

        /// <summary>
        /// Define new group;
        /// </summary>
        /// <param name="groupQuality"></param>
        /// <returns></returns>
        public static Group[] CreateGroup(int groupQuality)
        {
            Group[] newGroups=new Group[groupQuality];
            for (int i = 0; i < newGroups.GetLength(0); i++)
            {
                Console.Write("In " + i + " group are: ");
                newGroups[i].Size = ReadInt();
                newGroups[i].Traines = new Student[newGroups[i].Size];
                newGroups[i].GID = i;
            }

            return newGroups;
        }
    }
}
