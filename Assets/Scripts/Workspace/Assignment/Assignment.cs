using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Assignment
{
    public class Assignment : MonoBehaviour
    {
        public void Start()
        {
             AS01_CountWords();
            AS02_CountNumber();
             AS03_CheckValidBrackets();
            AS04_PrintReverseLinkedList();
            AS05_FindMiddleElement();
            AS06_MergeDictionaries();
            AS07_RemoveDuplicatesFromLinkedList();
            AS08_TopFrequentNumber();
            AS09_PlayerInventory();
            AS10_GameEventQueue();
            AS11_PlayerStatsTracker();
        }

        #region Assignment

        [Header("AS01 - Count Words")]
        [SerializeField] private string[] as01Words;

        public void AS01_CountWords()
        {
            string[] words = as01Words;
            Dictionary<string, int> wordCountDict = new Dictionary<string, int>();
            foreach (string word in words)
            {
                if (wordCountDict.ContainsKey(word))
                {
                    wordCountDict[word]++;
                }
                else
                {
                    wordCountDict[word] = 1;
                }
            }

            // ?? keys ??? values ???????? array
            string[] keys = wordCountDict.Keys.ToArray();
            int[] values = wordCountDict.Values.ToArray();

            // ???????????????????? Debug.Log ?????????????????
            for (int i = 0; i < keys.Length; i++)
            {
                Debug.Log($"word: '{keys[i]}' count: {values[i]}");
            }
        }

        [Header("AS02 - Count Number")]
        [SerializeField] private int[] as02Numbers;

        public void AS02_CountNumber()
        {
            int[] numbers = as02Numbers;
            Dictionary<int, int> numberCountDict = new Dictionary<int, int>();
            foreach (int num in numbers)
            {
                if (numberCountDict.ContainsKey(num))
                {
                    numberCountDict[num]++;
                }
                else
                {
                    numberCountDict[num] = 1;
                }
            }

            int[] keys = numberCountDict.Keys.ToArray();
            int[] values = numberCountDict.Values.ToArray();

            for (int i = 0; i < keys.Length; i++)
            {
                Debug.Log($"number: {keys[i]} count: {values[i]}");
            }
        }

        [Header("AS03 - Check Valid Brackets")]
        [SerializeField] private string as03Input;

        public void AS03_CheckValidBrackets()
        {
            string input = as03Input;
            Dictionary<char, char> bracketPairs = new Dictionary<char, char>()
            {
                { ')', '(' },
                { ']', '[' },
                { '}', '{' }
            };
            LinkedList<char> stack = new LinkedList<char>();

            //??????????????????????? input
            foreach (char c in input)
            {
                if (bracketPairs.ContainsValue(c))
                {
                    stack.AddLast(c);
                }
                else if (bracketPairs.ContainsKey(c))
                {
                    if (stack.Count == 0)
                    {
                        Debug.Log("Invalid");
                        return;
                    }

                    // ??????????????????????????????????? stack.Last.Value
                    if (stack.Last.Value == bracketPairs[c])
                    {
                        // ???????????????????????????????
                        stack.RemoveLast();
                    }
                    else
                    {
                        // ??????????????????? Invalid ?????
                        Debug.Log("Invalid");
                        return;
                    }
                }
                // ??????????????????????????????????????????????
            }

            //?????????????????????? ??????? Valid ?????????? stack ????
            if (stack.Count == 0)
            {
                Debug.Log("Valid");
            }
            else
            {
                Debug.Log("Invalid");
            }
        }

        [Header("AS04 - Print Reverse Linked List")]
        [SerializeField] private IntLinkedListInput as04List = new IntLinkedListInput();

        public void AS04_PrintReverseLinkedList()
        {
            LinkedList<int> list = as04List.GetLinkedList();
            // ?????????? list.Count ??????? 0 ???????
            if (list.Count == 0)
            {
                Debug.Log("List is empty");
                return;
            }

            // ?????????????????????????????????? list.Last
            LinkedListNode<int> current = list.Last;

            // ?????? while ????????????????????????????????? null
            while (current != null)
            {
                // ???? Value ??????????????? ????????????????????? Previous
                Debug.Log(current.Value);
                current = current.Previous;
            }
        }

        [Header("AS05 - Find Middle Element")]
        [SerializeField] private StringLinkedListInput as05List = new StringLinkedListInput();

        public void AS05_FindMiddleElement()
        {
            LinkedList<string> list = as05List.GetLinkedList();
            if (list.Count == 0)
            {
                Debug.Log("List is empty");
                return;
            }

            LinkedListNode<string> slow = list.First;
            LinkedListNode<string> fast = list.First;
            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            Debug.Log(slow.Value);
        }

        [Header("AS06 - Merge Dictionaries")]
        [SerializeField] private StringIntDictionaryInput as06FirstDictionary = new StringIntDictionaryInput();
        [SerializeField] private StringIntDictionaryInput as06SecondDictionary = new StringIntDictionaryInput();

        public void AS06_MergeDictionaries()
        {
            Dictionary<string, int> dict1 = as06FirstDictionary.GetDictionary();
            Dictionary<string, int> dict2 = as06SecondDictionary.GetDictionary();
            Dictionary<string, int> mergedDictionary = new Dictionary<string, int>(dict1);

            foreach (KeyValuePair<string, int> kvp in dict2)
            {
                if (mergedDictionary.ContainsKey(kvp.Key))
                {
                    mergedDictionary[kvp.Key] += kvp.Value;
                }
                else
                {
                    mergedDictionary.Add(kvp.Key, kvp.Value);
                }
            }

            foreach (KeyValuePair<string, int> kvp in mergedDictionary)
            {
                Debug.Log($"key: {kvp.Key}, value: {kvp.Value}");
            }
        }

        [Header("AS07 - Remove Duplicates From Linked List")]
        [SerializeField] private IntLinkedListInput as07List = new IntLinkedListInput();

        public void AS07_RemoveDuplicatesFromLinkedList()
        {
            LinkedList<int> list = as07List.GetLinkedList();
            if (list.Count <= 1)
            {
                foreach (int item in list)
                {
                    Debug.Log(item);
                }
                return;
            }

            Dictionary<int, bool> seen = new Dictionary<int, bool>();
            LinkedListNode<int> current = list.First;

            while (current != null)
            {
                LinkedListNode<int> nextNode = current.Next;

                if (seen.ContainsKey(current.Value))
                {
                    list.Remove(current);
                }
                else
                {
                    seen.Add(current.Value, true);
                }

                current = nextNode;
            }

            foreach (int item in list)
            {
                Debug.Log(item);
            }
        }

        [Header("AS08 - Top Frequent Number")]
        [SerializeField] private int[] as08Numbers;

        public void AS08_TopFrequentNumber()
        {
            int[] numbers = as08Numbers;
            if (numbers == null || numbers.Length == 0)
            {
                Debug.Log("Input array is empty");
                return;
            }

            Dictionary<int, int> freqDict = new Dictionary<int, int>();
            foreach (int num in numbers)
            {
                if (freqDict.ContainsKey(num))
                {
                    freqDict[num]++;
                }
                else
                {
                    freqDict[num] = 1;
                }
            }

            int topNum = numbers[0];
            int maxCount = freqDict[topNum];

            foreach (int num in numbers)
            {
                int currentCount = freqDict[num];
                if (currentCount > maxCount)
                {
                    maxCount = currentCount;
                    topNum = num;
                }
            }

            Debug.Log($"{topNum} count: {maxCount}");

        }

        [Header("AS09 - Player Inventory")]
        [SerializeField] private StringIntDictionaryInput as09Inventory = new StringIntDictionaryInput();
        [SerializeField] private string as09ItemName;
        [SerializeField] private int as09Quantity;

        public void AS09_PlayerInventory()
        {
            Dictionary<string, int> inventory = as09Inventory.GetDictionary();
            string itemName = as09ItemName;
            int quantity = as09Quantity;
            if (inventory.ContainsKey(itemName))
            {
                inventory[itemName] += quantity;
            }
            else
            {
                inventory.Add(itemName, quantity);
            }

            foreach (KeyValuePair<string, int> item in inventory)
            {
                Debug.Log($"key: {item.Key}, value: {item.Value}");
            }
        }

        [Header("AS10 - Game Event Queue")]
        [SerializeField] private GameEventLinkedListInput as10EventQueue = new GameEventLinkedListInput();

        public void AS10_GameEventQueue()
        {
            LinkedList<GameEvent> eventQueue = as10EventQueue.GetLinkedList();
            if (eventQueue.Count == 0)
            {
                Debug.Log("Event queue is empty");
                return;
            }

            while (eventQueue.Count > 0)
            {
                GameEvent currentEvent = eventQueue.First.Value;

                Debug.Log($"Processing event: {currentEvent.eventName}");
                eventQueue.RemoveFirst();

                Debug.Log($"Remaining events in queue: {eventQueue.Count}");

                switch (currentEvent.eventType)
                {
                    case "enemy":
                        Debug.Log($"Enemy event processed - {currentEvent.eventName}");
                        break;
                    case "powerup":
                        Debug.Log($"Power-up event processed - {currentEvent.eventName}");
                        break;
                    case "level":
                        Debug.Log($"Level event processed - {currentEvent.eventName}");
                        break;
                }
            }
        }

        [Header("AS11 - Player Stats Tracker")]
        [SerializeField] private StringIntDictionaryInput as11PlayerStats = new StringIntDictionaryInput();
        [SerializeField] private string as11StatName;
        [SerializeField] private int as11Value;

        public void AS11_PlayerStatsTracker()
        {
            Dictionary<string, int> playerStats = as11PlayerStats.GetDictionary();
            string statName = as11StatName;
            int value = as11Value;
            if (playerStats.ContainsKey(statName))
            {
                playerStats[statName] += value;
            }
            else
            {
                playerStats.Add(statName, value);
            }

            Debug.Log($"Updated {statName}: {playerStats[statName]}");
            Debug.Log("Current player statistics:");

            foreach (KeyValuePair<string, int> stat in playerStats)
            {
                Debug.Log($"{stat.Key}: {stat.Value}");
            }
        }

        #endregion
    }
}
