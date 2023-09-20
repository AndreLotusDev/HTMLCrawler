using HtmlAgilityPack;

var url = "https://mimetype.io/all-types";
var web = new HtmlWeb();
var doc = web.Load(url);

var nodes = doc.DocumentNode.SelectSingleNode("//tbody");

var allFormats = new List<string>();

if (nodes != null)
{
    foreach (var tr in nodes.ChildNodes)
    {
        var tdMime = tr.ChildNodes.First(f => f.Name == "td");
        Console.WriteLine(tdMime.InnerText);
        allFormats.Add(tdMime.InnerText);
    }
}

//Write this to a txt file in desktop
var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
var path = Path.Combine(desktop, "allFormats.txt");
File.WriteAllLines(path, allFormats);
