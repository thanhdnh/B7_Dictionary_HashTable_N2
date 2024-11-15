using System.Collections;

public class IPAddress : DictionaryBase
{
    public void Add(string name, string ip)
    {
        base.InnerHashtable.Add(name, ip);
    }
    public string Item(string name)
    {
        return base.InnerHashtable[name].ToString();
    }
    public void Remove(string name)
    {
        base.InnerHashtable.Remove(name);
    }
    public void Display(){
        DictionaryEntry[] arr = new DictionaryEntry[base.InnerHashtable.Count];
        base.InnerHashtable.CopyTo(arr, 0);
        
        for(int i=0; i<arr.Length-1; i++)
            for(int j=i+1; j<arr.Length; j++){
                //DictionaryEntry a = arr[i];
                //DictionaryEntry b = arr[j];
                if(arr[i].Value.ToString().CompareTo(arr[j].Value.ToString())>0){
                    DictionaryEntry t = arr[i];
                    arr[i] = arr[j];
                    arr[j] = t;
                }
            }
        
        foreach(DictionaryEntry ele in arr)
            Console.WriteLine($"Key={ele.Key}, Value={ele.Value}");
    }
}
public class BucketHash
{
    private const int SIZE = 10;
    ArrayList[] data;
    public BucketHash()
    {
        data = new ArrayList[SIZE];
        for (int i = 0; i <= SIZE - 1; i++)
            data[i] = new ArrayList(4);
    }
    public int Hash(string s)
    {//hash function
        long tot = 0;
        char[] chararray;
        chararray = s.ToCharArray();
        for (int i = 0; i <= s.Length - 1; i++)
            tot += 37 * tot + (int)chararray[i];
        tot = tot % data.GetUpperBound(0);
        if (tot < 0)
            tot += data.GetUpperBound(0);
        return (int)tot;
    }
    public void Insert(string item)
    {
        int hash_value = Hash(item);
        if (!data[hash_value].Contains(item))
            data[hash_value].Add(item);
    }
    public void Remove(string item)
    {
        int hash_value = Hash(item);
        if (data[hash_value].Contains(item))
            data[hash_value].Remove(item);
    }
}
public class Program
{
    static List<string> NonOverlapWord(string line){
        string[] words = line.Split(" ");
        List<string> result = new List<string>(words);
        List<string> final = new List<string>();
        foreach(string word in result)
            if(!final.Contains(word))
                final.Add(word);
        return final;
    }
    static Dictionary<string, int> CreateDict(string line){
        Dictionary<string, int> dict = new Dictionary<string, int>();
        foreach(string key in NonOverlapWord(line))
            dict.Add(key, 1);
        return dict;
    }
    static Dictionary<string, int> UpdateDict(string line){
        string[] words = line.Split(" ");
        Dictionary<string, int> dict = CreateDict(line);
        foreach(KeyValuePair<string, int> word in dict){
            int count = 0;
            foreach(string w in words)
                if(word.Key.Equals(w))
                    count++;
            dict[word.Key] = count;
        }
        return dict;
    }
    public static void Main(string[] args)
    {
        string s = "toi di hoc dai hoc va hoc xong thi toi di ve";
        Dictionary<string, int> dict = UpdateDict(s);
        foreach(KeyValuePair<string,int> item in dict)
            Console.WriteLine(item.Key + ", " + item.Value);    
        /*IPAddress myips = new IPAddress();
        myips.Add("Mike", "192.151.0.1");
        myips.Add("David", "192.151.0.2");
        myips.Add("Bernica", "192.151.0.3");
        myips.Display();*/

        /*Console.WriteLine("IP cua Mike la: " + myips.Item("Mike"));
        Console.WriteLine("\n key va value la:");
        IDictionaryEnumerator e = myips.GetEnumerator();
        while (e.MoveNext())
            Console.WriteLine("key={0},value={1}", e.Key, e.Value);
        */
        /*
            key=Bernica,value=192.151.0.3
            key=David,value=192.151.0.2
            key=Mike,value=192.151.0.1
        */
        //System.Console.WriteLine("\n======\n");

        /*Hashtable infos = new Hashtable(5);
        infos.Add("salary", 100000);
        infos.Add("name", "David Job");
        infos.Add("age", 45);
        infos.Add("dept", "Information Technology");
        infos["gender"] = "Male";
        Console.WriteLine("Key: ");
        foreach (object key in infos.Keys)
            Console.WriteLine(key);
        Console.WriteLine("Value:");
        foreach (object value in infos.Values)
            Console.WriteLine(value);
        Console.ReadLine();*/
    }
}