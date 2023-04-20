using System;
using System.Collections.Generic;
using static System.Console;
namespace Події
{
    public delegate void ДелегатІспита(string завдання);
    class Студент
    {
        public int id;
        public string імйа { get; set; }
        public string прізвище { get; set; }
        public DateTime дата_народження { get; set; }
        public void іспит(string завдання)
        {
            if(id % 2 != 0) WriteLine($"Студент {прізвище} отримав {завдання} першого варіанту");
            else WriteLine($"Студент {прізвище} отримав {завдання} другого варіанту варіанту");
        }
    }
    class Викладач
    {
        public event ДелегатІспита подія;
        public void Іспит(string завдання)
        {
            if (подія != null)
            {
                подія(завдання);
            }
        }
    }
    class Програма
    {
        static void Main(string[] args)
        {
            List<Студент> група = new List<Студент>
    {
    new Студент
    {
      id = 1,
      імйа = "Іван",
      прізвище = "Дертьник",
      дата_народження = new DateTime(1997,3,12)
    },
    new Студент
    {
      id = 2,
      імйа = "Катя",
      прізвище = "Елемент",
      дата_народження = new DateTime(1998,7,22)
    },
    new Студент
    {
      id = 3,
      імйа = "ДЖура",
      прізвище = "Фіртань",
      дата_народження = new DateTime(1996,11,30)
    },
    new Студент
    {
      id = 4,
      імйа = "Микола",
      прізвище = "Кравець",
      дата_народження = new DateTime(1996,5,10)
    }
    };
            Викладач викладач = new Викладач();
            foreach (Студент студент in група)
            {
                викладач.подія += студент.іспит;
            }
            викладач.Іспит("завдання іспита");
        }
    }
}