namespace Passwords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Password
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int k = int.Parse(Console.ReadLine());
            int[] keyboard = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            int[] password = new int[n];
            List<string> listOfPasswords = new List<string>();
            FindPassword(keyboard, 0, input, password, listOfPasswords, keyboard.Length - 1);
            listOfPasswords = listOfPasswords.OrderBy(x => x).ToList();
            Console.WriteLine(listOfPasswords[k - 1]);
        }

        public static void FindPassword(int[] keyboard, int index, string input, int[] password, List<string> list, int currentPosition)
        {
            if (index >= password.Length)
            {
                string result = string.Join("", password);
                list.Add(result);
                return;
            }
            else
            {
                if (index > 0)
                {
                    if (input[index - 1] == '=')
                    {
                        password[index] = password[index - 1];
                        FindPassword(keyboard, index + 1, input, password, list, currentPosition);
                    }
                    else if (input[index - 1] == '>')
                    {
                        for (int i = currentPosition + 1; i < keyboard.Length && i >= 0; i++)
                        {
                            password[index] = keyboard[i];
                            FindPassword(keyboard, index + 1, input, password, list, i);
                        }
                    }
                    else if (input[index - 1] == '<')
                    {
                        for (int i = currentPosition - 1; i < keyboard.Length && i >= 0; i--)
                        {
                            password[index] = keyboard[i];
                            FindPassword(keyboard, index + 1, input, password, list, i);
                        }
                    }
                }
                else
                {
                    FindPassword(keyboard, index + 1, input, password, list, keyboard.Length - 1);
                    for (int i = 0; i < keyboard.Length - 1; i++)
                    {
                        password[index] = keyboard[i];
                        FindPassword(keyboard, index + 1, input, password, list, i);
                    }
                }
            }
        }

    }
}
