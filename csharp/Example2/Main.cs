//  
//  Copyright (C) 2010 Andrius Bentkus
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
using System;
using System.IO;
using Mono.Stfl;

namespace Example2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Form f = new Form(null, "example.stfl");

            string msg;
            while ((msg = f.Run(0)) != "ESC")
            {
                string focus = f.GetFocus();
                
                if ((msg == "ENTER") && f.GetFocus() == "file")
                {
                    StreamWriter sw = new StreamWriter(File.Open(f["filetext"], FileMode.Create));
                    sw.WriteLine("BEGIN:VCARD\nVERSION:2.1\nFN:{0} {1}\nN:{1};{0}\nEMAIL;INTERNET:{2}\nEND:VCARD",
                                 f["firstnametext"], f["lastnametext"], f["emailtext"]);
                    sw.Close();
                    f["msg"] = String.Format("Stored vCard to {0}", f["filetext"]);
                    f.SetFocus("firstname");
                }
            }
            Form.ResetConsole();
        }
    }
}