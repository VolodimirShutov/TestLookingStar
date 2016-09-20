using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace star1
{
    class Program
    {
        static void Main(string[] args)
        {
            startProgram();
            Console.ReadLine();
        }

        static void startProgram()
        {
            //читаем файл
            string textFile = new ReadFile().readFile();
            //преобразуем файл в удобный формат для работы
            DatasConvert converter = new DatasConvert();

            Dictionary < string, Element > dict = converter.dataConvert(textFile);

            /*
             * Далее солжнее. Я преобразую данные по принцыпу "x = 100 - x". Таким образом 
             * я меняю условие задачи. И теперь мне нужно найти не тот путь, который дает 
             * найбольшую сумму, а тот, который даст найменьшу. А для этого лучше всего
             * подойдут вариации на тему алгоритмов поиска пути.
             */

            converter.numericConverterForDict(dict);
            int lineCount = converter.lineCount;

            //ну собственно сам алгоритм поиска пути:
            List<Element>  list = new FindPath().findPath(lineCount, dict);

            //конвертируем обратно
            converter.backConverter(list);

            //получаем результат
            int resoult = 0;
            foreach (var element in list)
            {
                resoult += element.value;
            }

            Console.WriteLine(resoult);
        }
    }
}
