using System;
using static System.Console;

namespace laba5
{
    class TVProgramm
    {
        public string Name { get; set; }
        public string[] Channels;
        public override string ToString()
        {
            string typeVal = base.ToString();
            string objectVal = Name;
            return typeVal + '\n' + objectVal;
        }
    }

    class News : TVProgramm
    {
        public string[] NewsTitles;
        public string[] NewsText;
        public override string ToString()
        {
            string typeVal = base.ToString();
            string objectVal = "";
            for (int i = 0; i < NewsTitles.Length; i++)
            {
                objectVal += NewsTitles[i] + ' ';
            }
            objectVal += '\n';
            for (int i = 0; i < NewsText.Length; i++)
            {
                objectVal += NewsText[i] + ' ';
            }
            return typeVal + '\n' + objectVal;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            News newsObj = (News)obj;
            if (newsObj.NewsText.Length != this.NewsText.Length) return false;
            for (int i = 0; i < this.NewsText.Length; i++)
            {
                if (this.NewsText[i] != newsObj.NewsText[i])
                    return true;
            }
            return true;
        }
    }

    class Cartoon : Movie, IMovie
    {
        public string[] Animators;
        public string Name { get; set; }
        public override float Rating { get; set; }
        protected override int AgeLimit { get; set; }
        public override void IncrementAgeLimit()
        {
            AgeLimit -= 3;
        }
        public override bool isGood()
        {
            if (Rating > 8) return true;
            return false;
        }

        public override string ToString()
        {
            string typeVal = base.ToString();
            string objectVal = Name + ' ' + Rating + ' ' + AgeLimit;
            objectVal += '\n';
            for (int i = 0; i < Animators.Length; i++)
            {
                objectVal += Animators[i] + ' ';
            }
            return typeVal + '\n' + objectVal;
        }
    }

    class Film : Movie, IMovie
    {
        public string[] Authors;
        public float Budget;
        public string Name { get; set; }
        public override float Rating { get; set; }
        protected override int AgeLimit { get; set; }

        public override bool isGood()
        {
            if (Rating > 7) return true;
            return false;
        }

        public override string ToString()
        {
            string typeVal = base.ToString();
            string objectVal = Name + ' ' + Rating + ' ' + AgeLimit + ' ' + Budget;
            objectVal += '\n';
            for (int i = 0; i < Authors.Length; i++)
            {
                objectVal += Authors[i] + ' ';
            }
            return typeVal + '\n' + objectVal;
        }
    }

    class ArtisticFilm : Film
    {
        public string[] characters;
        public override string ToString()
        {
            string typeVal = base.ToString();
            string objectVal = Name + ' ' + Rating + ' ' + AgeLimit + ' ' + Budget;
            objectVal += '\n';
            for (int i = 0; i < characters.Length; i++)
            {
                objectVal += characters[i] + ' ';
            }
            return typeVal + '\n' + objectVal;
        }
    }

    class Add : TVProgramm
    {
        public float Cost;
        public override string ToString()
        {
            string typeVal = base.ToString();
            string objectVal = Cost.ToString();
            return typeVal + '\n' + objectVal;
        }
    }

    sealed class Producer : IPerson
    {
        public string[] projects;
        public string Name { get; set; }
        public override string ToString()
        {
            string typeVal = base.ToString();
            string objectVal = Name;
            objectVal += '\n';
            for (int i = 0; i < projects.Length; i++)
            {
                objectVal += projects[i] + ' ';
            }
            return typeVal + '\n' + objectVal;
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            Film film1 = new Film { Rating = 8.7F, Name = "Shrek" };
            WriteLine(film1.isGood());
            News news1 = new News { NewsText = new string[] { "text1", "text2" } };
            Cartoon cartoon1 = new Cartoon { Name = "Valera", Rating = 9F, Animators = new[] { "nikelod", "animit" } };
            ArtisticFilm artisticFilm1 = new ArtisticFilm { characters = new string[] { "Nikoglai", "Leo" } };
            if (artisticFilm1 is Film)
                film1 = artisticFilm1;
            artisticFilm1 = film1 as ArtisticFilm;
            if (film1 == null)
                WriteLine("Ошибка преобразования");
            else
                WriteLine(artisticFilm1.characters[0]);
            Movie[] classes = { cartoon1, new Film { Rating = 6F, Name = "batman" } };
            Printer print = new Printer();
            foreach (var cls in classes)
            {
                WriteLine(print.IAmPrinting(classes[0]));
                WriteLine('\n');
            }
        }
    }
}
