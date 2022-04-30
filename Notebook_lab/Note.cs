using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook
{
    public class Note
    {
        public string Phone { get; set; }
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Country { get; set; }
        public string DateOfBirth { get; set; }
        public string Organization { get; set; }
        public string Position { get; set; }
        public string Remark { get; set; }

        public static string abc = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        public static string nums = "1234567890";
        public static string symbs = ",.?!()\\+-=№@\'\"&$;:^";

        public static Dictionary<string, Validation> fieldsValidation = new Dictionary<string, Validation>()
        {
            ["Name"] = new Validation(true, 1, 20, (abc + " " + "-").ToCharArray()),
            ["Surname"] = new Validation(true, 1, 20, (abc + " " + "-").ToCharArray()),
            ["SecondName"] = new Validation(false, 0, 20, (abc + " " + "-").ToCharArray()),
            ["Phone"] = new Validation(true, 5, 11, nums.ToCharArray()),
            ["Country"] = new Validation(false, 0, 20, (abc + " " + "-").ToCharArray()),
            ["DateOfBirth"] = new Validation(false, 10, 10, (nums + ".").ToCharArray()),
            ["Organization"] = new Validation(false, 0, 20, (abc + "-" + " ").ToCharArray()),
            ["Position"] = new Validation(false, 0, 20, (abc + " " + "-").ToCharArray()),
            ["Remark"] = new Validation(false, 0, 200, (abc + nums + symbs + " ").ToCharArray()),
            ["Id"] = new Validation(true, 1, 10, nums.ToCharArray())
        };

        public override string ToString() => $"\n\tID: {Id}\n\tФамилия: {Surname}\n\tИмя: {Name}\n\tОтчество: {SecondName}\n\tНомер телефона: {Phone}\n\tСтрана: {Country}\n\tДата рождения: {DateOfBirth}\n\tОрганизация: {Organization}\n\tДолжность: {Position}\n\tПримечание: {Remark}";

        public string ToShortString() => $"{Id} {Surname} {Name} {Phone}";


    }
}

