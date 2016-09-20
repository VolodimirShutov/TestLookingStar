using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace star1
{
    class FindPath
    {

        private Dictionary<string, Element> activeElements = new Dictionary<string, Element>();
        private int counter = 0;
        private Dictionary<string, Element> mainDict;
        private bool dontStup = true;
        private int lineCount;

        public List<Element> findPath(int lineCount, Dictionary<string, Element> dict )
        {
            this.lineCount = lineCount;
            mainDict = dict;
            string firstItemName = "0_0";
            Element firstItem = dict[firstItemName];
            firstItem.pathValue = firstItem.value;
            counter = firstItem.value;
            findNewActive(firstItemName, firstItem);

            Element lastElement = findNextPoint();

            List<Element> list = findResoultPath(lastElement);

            return list;
        }

        private List<Element> findResoultPath(Element lastElement)
        {
            string parentName = lastElement.parentElementName;
            List<Element> list = new List<Element>();

            list.Add(lastElement);
            
            while(true)
            {
                if (parentName != null && mainDict.ContainsKey(parentName) == true)
                {
                    Element parent = mainDict[parentName];
                    parentName = parent.parentElementName;
                    list.Add(parent);
                }
                else
                {
                    break;
                }
            }

            return list;
        }


        private Element findNextPoint()
        {
            while(dontStup == true)
            {
                counter++;

                List<string> names = new List<string>() ;

                foreach (var item in activeElements)
                {
                    names.Add(item.Key);
                }

                foreach (var name in names)
                {
                    Element element = activeElements[name];
                    //Console.WriteLine(element.name, element.pathValue);

                    if (element.pathValue <= counter)
                    {
                        if (this.lineCount <= element.line)
                        {
                            dontStup = false;
                            return element;
                        }
                        else
                        {
                            Console.WriteLine(name);
                            findNewActive(name, element);
                        }   
                    }
                }

            }
            return new Element();
        }

        private void findNewActive(string itemName, Element item)
        {
            int line = item.line + 1;
            int position = item.position;
            //int pathValue = item.pathValue;

            string name = line.ToString() + "_" + (position - 1).ToString();
            addActive(name, item);

            name = line.ToString() + "_" + (position).ToString();
            addActive(name, item);

            name = line.ToString() + "_" + (position + 1).ToString();
            addActive(name, item);

            if (activeElements.ContainsKey(itemName) == true)
                activeElements.Remove(itemName);
        }

        private void addActive(string newItemName, Element item)
        {
            if (mainDict.ContainsKey(newItemName) == true)
            {
                Element element = mainDict[newItemName];
                if (element.parentElementName == null)
                {
                    element.pathValue = item.pathValue + element.value;
                    element.parentElementName = item.name;
                    activeElements[newItemName] = element;

                    Console.WriteLine(newItemName);
                }
            }
        }
    }
}
