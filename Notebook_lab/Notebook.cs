using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook
{
    public class Notebook
    {
        public Dictionary<int, Note> allNotes = new Dictionary<int, Note>();

        private static void Greetings()
        {
            Console.WriteLine("Добро пожаловать в нашу записную книжку!");
            Console.WriteLine("\t- для создания новой записи введите команду: create.");
            Console.WriteLine("\t- для просмотра записи введите команду: show.");
            Console.WriteLine("\t- для редактирования записи введите команду: edit.");
            Console.WriteLine("\t- для удаления записи введите команду: del.");
            Console.WriteLine("\t- для просмотра списка всех записей введите команду: all.");
            Console.WriteLine("\t- для выхода из программы введите команду: exit.");
        }

        private void Action()
        {
            Greetings();
            while (true)
            {
                Console.Write("Введите команду: ");
                string choice;

                do
                {
                    choice = Console.ReadLine();
                    if (choice == "create" || choice == "show" || choice == "edit" || choice == "del" || choice == "all" || choice == "exit")
                        break;

                    Console.Clear();
                    Console.Write("Данной команды не найдено! Попробуйте ещё раз: ");
                } while (!(choice == "create" || choice == "show" || choice == "edit" || choice == "del" || choice == "all" || choice == "exit"));

                switch (choice)
                {
                    case "create":
                        CreateNote();
                        break;
                    case "show":
                        ReadNote();
                        break;
                    case "edit":
                        UpdateNote();
                        break;
                    case "del":
                        DeleteNote();
                        break;
                    case "all":
                        ShowAllNotes();
                        break;
                    case "exit":
                        Console.WriteLine("Пока-пока!");
                        return;
                }
            }
        }

        private int notesCount = 0;
        private void CreateNote()
        {
            Note note = new Note() { Id = notesCount };

            note.Surname = ReadUntilValidationPass("Surname");
            note.Name = ReadUntilValidationPass("Name");
            note.SecondName = ReadUntilValidationPass("SecondName");

            if (String.IsNullOrWhiteSpace(note.SecondName)) note.SecondName = null;
            note.Phone = ReadUntilValidationPass("Phone");
            note.Country = ReadUntilValidationPass("Country");

            if (String.IsNullOrWhiteSpace(note.Country)) note.Country = null;
            note.DateOfBirth = ReadUntilValidationPass("DateOfBirth");

            if (String.IsNullOrWhiteSpace(note.DateOfBirth)) note.DateOfBirth = null;
            note.Organization = ReadUntilValidationPass("Organization");

            if (String.IsNullOrWhiteSpace(note.Organization)) note.Organization = null;
            note.Position = ReadUntilValidationPass("Position");

            if (String.IsNullOrWhiteSpace(note.Position)) note.Position = null;
            note.Remark = ReadUntilValidationPass("Remark");

            if (String.IsNullOrWhiteSpace(note.Remark)) note.Remark = null;

            allNotes.Add(notesCount, note);

            notesCount++;
        }

        private void ReadNote()
        {
            Console.Write("Введите Id записи: ");
            string idStr = Console.ReadLine();

            if (int.TryParse(idStr, out int id))
            {
                foreach (var note in allNotes)
                {
                    if (id == note.Key)
                    {
                        Console.WriteLine(note.Value);
                        return;
                    }
                }
                Console.WriteLine("Данной записи не найдено!");
            }
            else
                Console.WriteLine("Введен некорректный идентификатор!");
        }

        private void UpdateNote()
        {
            Console.Write("Укажите ID записи для редактирования: ");
            string idStr = Console.ReadLine();



            if (int.TryParse(idStr, out int id))
            {
                if (allNotes.ContainsKey(id))
                {
                    while (true)
                    {
                        Console.WriteLine(allNotes[id]);
                        Console.WriteLine("Какое поле необходимо отредактировать?");
                        Console.WriteLine("\t1 - Фамилия\n\t2 - Имя\n\t3 - Отчество\n\t4 - Телефон\n\t5 - Страна\n\t6 - Дата рождения\n\t7 - Организация\n\t8 - Должность\n\t9 - Примечание");
                        Console.Write("Введите цифру для выбора или cancel для завершения редактирования: ");
                        string choice;
                        while (true)
                        {
                            choice = Console.ReadLine();
                            switch (choice)
                            {
                                case "1":
                                    allNotes[id].Surname = ReadUntilValidationPass("Surname");
                                    break;
                                case "2":
                                    allNotes[id].Name = ReadUntilValidationPass("Name");
                                    break;
                                case "3":
                                    allNotes[id].SecondName = allNotes[id].SecondName = ReadUntilValidationPass("SecondName");
                                    if (String.IsNullOrWhiteSpace(allNotes[id].SecondName)) allNotes[id].SecondName = null;
                                    break;
                                case "4":
                                    allNotes[id].Phone = ReadUntilValidationPass("Phone");
                                    break;
                                case "5":
                                    allNotes[id].Country = ReadUntilValidationPass("Country");
                                    if (String.IsNullOrWhiteSpace(allNotes[id].Country)) allNotes[id].Country = null;
                                    break;
                                case "6":
                                    allNotes[id].DateOfBirth = ReadUntilValidationPass("DateOfBirth");
                                    if (String.IsNullOrWhiteSpace(allNotes[id].DateOfBirth)) allNotes[id].DateOfBirth = null;
                                    break;
                                case "7":
                                    allNotes[id].Organization = ReadUntilValidationPass("Organization");
                                    if (String.IsNullOrWhiteSpace(allNotes[id].Organization)) allNotes[id].Organization = null;
                                    break;
                                case "8":
                                    allNotes[id].Position = ReadUntilValidationPass("Position");
                                    if (String.IsNullOrWhiteSpace(allNotes[id].Position)) allNotes[id].Position = null;
                                    break;
                                case "9":
                                    allNotes[id].Remark = ReadUntilValidationPass("Remark");
                                    if (String.IsNullOrWhiteSpace(allNotes[id].Remark)) allNotes[id].Remark = null;
                                    break;
                                case "cancel":
                                    return;
                                default:
                                    Console.Write("Команда не найдена! Введите ещё раз: ");
                                    continue;
                            }
                            break;
                        }

                        Console.Write("Поле изменено! Продолжить редактирование записи? (yes/no): ");
                        choice = Console.ReadLine();
                        while (choice != "yes" && choice != "no")
                        {
                            Console.WriteLine("Пожалуйста введите yes или no: ");
                            choice = Console.ReadLine();
                        }

                        if (choice == "yes")
                            Console.Clear();
                        else
                        {
                            Console.Clear();
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Данной записи не найдено!");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Введен некорректный идентификатор!");
                return;
            }

        }

        private void DeleteNote()
        {
            Console.Write("Введите Id записи для удаления: ");
            string idStr = Console.ReadLine();

            if (int.TryParse(idStr, out int idI))
            {
                var temp = new Dictionary<int, Note>(allNotes);
                foreach (var note in temp)
                {
                    if (idI == note.Key)
                    {
                        Console.WriteLine($"Запись {note.Key} удалена!");
                        allNotes.Remove(note.Key);
                        idI--;
                        return;
                    }
                }
                Console.WriteLine("Данной записи не найдено!");
            }
            else
                Console.WriteLine("Введен некорректный идентификатор!");
        }

        private void ShowAllNotes()
        {
            foreach (var note in allNotes)
                Console.WriteLine(note.Value.ToShortString());
        }
        private string ReadUntilValidationPass(string property)
        {
            while (true)
            {
                Console.Write($"Введите {property}: ");
                string t = Console.ReadLine();
                string w;
                if (Note.fieldsValidation[property].TryValidate(t, out w))
                {
                    return t;
                }
                else
                {
                    Console.WriteLine(w);
                }
            }
        }
        public static void Main(string[] args)
        {
            Notebook NotebookApp = new Notebook();

            NotebookApp.Action();
        }
    }
}