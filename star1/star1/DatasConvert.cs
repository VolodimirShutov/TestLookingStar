using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;

namespace star1
{
    class DatasConvert
    {
        public int lineCount = 0;

        public Dictionary<string, Element> dataConvert(string textFile)
        {
            //разбиваем на строки
            String pattern = @"\n";
            String[] lines = Regex.Split(textFile, pattern);

            //Преобразуем в удобній формат.
            var dict = new Dictionary<string, Element>();
            int lineCounter = 0;
            int positionCounter = 0;
            string[] elements;
            Element newElement;
            string newName;

            foreach (string  line in lines)
            {
                positionCounter = 0;

                pattern = @" ";
                elements = Regex.Split(line, pattern);

                bool hasElements = false;
                foreach(string stringElement in elements)
                {
                    if (stringElement != "")
                    {
                        newName = lineCounter.ToString() + "_" + positionCounter.ToString();
                        newElement = new Element();
                        newElement.line = lineCounter;
                        newElement.name = newName;
                        newElement.position = positionCounter;
                        newElement.value = Int32.Parse(stringElement);

                        dict[newName] = newElement;

                        positionCounter++;
                        hasElements = true;
                    }
                }

                if(hasElements)
                    lineCounter ++;
            }

            //Console.WriteLine(dict);
            lineCount = lineCounter - 1;
            return dict;
        }

        public void numericConverterForDict(Dictionary<string, Element> dict)
        {
            foreach (var item in dict)
            {
                Element element = item.Value;
                element.value = 100 - element.value;
            }
            
        }

        public void backConverter(List<Element> list)
        {
            foreach (var element in list)
            {
                element.value = 100 - element.value;
            }
        }
    }
}
