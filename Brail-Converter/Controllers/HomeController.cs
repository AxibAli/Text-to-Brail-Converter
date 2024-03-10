using Brail_Converter.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Brail_Converter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ConvertToBraille(string inputText, string selectedLanguage)
        {
            string brailleText = ConvertTextToBraille(inputText, selectedLanguage);

            ViewBag.InputText = inputText;
            ViewBag.BrailleText = brailleText;

            return View("Index");
        }

        private string ConvertTextToBraille(string text, string language)
        {
            Dictionary<char, string> brailleMap = GetBrailleMapForLanguage(language);

            text = text.ToLower(); // Convert to lowercase for simplicity

            string brailleText = "";
            foreach (char c in text)
            {
                if (brailleMap.ContainsKey(c))
                {
                    brailleText += brailleMap[c] + " "; // Add space for better visualization
                }
                else
                {
                    // If the character is not in the map, just keep it as is
                    brailleText += c;
                }
            }

            return brailleText.Trim(); // Trim to remove trailing space
        }

        private Dictionary<char, string> GetBrailleMapForLanguage(string language)
        {
            // Define language-specific Braille mappings
            // Urdu Braille mappings
            Dictionary<char, string> urduBrailleMap = new Dictionary<char, string>
            {
              {'ا', "⠁"},
              {'ب', "⠃"},
              {'پ', "⠏"},
              {'ت', "⠅"},
              {'ٹ', "⠆"},
              {'ث', "⠙"},
              {'ج', "⠚"},
              {'چ', "⠛"},
              {'ح', "⠜"},
              {'خ', "⠝"},
              {'د', "⠙"},
              {'ڈ', "⠃⠆"},
              {'ذ', "⠑"},
              {'ر', "⠗"},
              {'ڑ', "⠗⠆"},
              {'ز', "⠵"},
              {'ژ', "⠹"},
              {'س', "⠎"},
              {'ش', "⠱"},
              {'ص', "⠮"},
              {'ض', "⠾"},
              {'ط', "⠹"},
              {'ظ', "⠤⠦"},
              {'ع', "⠪"},
              {'غ', "⠳"},
              {'ف', "⠋"},
              {'ق', "⠟"},
              {'ک', "⠅"},
              {'گ', "⠛"},
              {'ل', "⠇"},
              {'م', "⠍"},
              {'ن', "⠝"},
              {'ں', "⠙"},
              {'ھ', "⠓"},
              {'ہ', "⠓"},
              {'و', "⠺"},
              {'ؤ', "⠚"},
              {'ء', "⠄"},
              {'ی', "⠽"},
              {'ے', "⠯"},
              {'ۓ', "⠾"},
              {'ئ', "⠌"},
              {' ', "⠤"}
            };

            // Default to English Braille if the language is not recognized
            Dictionary<char, string> defaultBrailleMap = new Dictionary<char, string>
            {
              {'a', "⠈"},
              {'b', "⠃"},
              {'c', "⠉"},
              {'d', "⠙"},
              {'e', "⠑"},
              {'f', "⠋"},
              {'g', "⠛"},
              {'h', "⠓"},
              {'i', "⠊"},
              {'j', "⠚"},
              {'k', "⠅"},
              {'l', "⠇"},
              {'m', "⠍"},
              {'n', "⠝"},
              {'o', "⠕"},
              {'p', "⠏"},
              {'q', "⠟"},
              {'r', "⠗"},
              {'s', "⠎"},
              {'t', "⠞"},
              {'u', "⠥"},
              {'v', "⠧"},
              {'w', "⠺"},
              {'x', "⠭"},
              {'y', "⠽"},
              {'z', "⠵"},
              {' ', "⠤"}
            };

            // Select the appropriate language-specific Braille map
            Dictionary<char, string> selectedBrailleMap;
            switch (language.ToLower())
            {
                case "urdu":
                    selectedBrailleMap = urduBrailleMap;
                    break;
                default:
                    selectedBrailleMap = defaultBrailleMap;
                    break;
            }

            return selectedBrailleMap;
        }

        //[HttpPost]
        //public IActionResult ConvertToBraille(string inputText)
        //{
        //    string brailleText = ConvertTextToBraille(inputText);

        //    ViewBag.InputText = inputText;
        //    ViewBag.BrailleText = brailleText;

        //    return View("Index");
        //}
        //private string ConvertTextToBraille(string text)
        //{
        //    Dictionary<char, string> brailleMap = new Dictionary<char, string>
        //    {
        //        {'a', "⠈"},
        //        {'b', "⠃"},
        //        {'c', "⠉"},
        //        {'d', "⠙"},
        //        {'e', "⠑"},
        //        {'f', "⠋"},
        //        {'g', "⠛"},
        //        {'h', "⠓"},
        //        {'i', "⠊"},
        //        {'j', "⠚"},
        //        {'k', "⠅"},
        //        {'l', "⠇"},
        //        {'m', "⠍"},
        //        {'n', "⠝"},
        //        {'o', "⠕"},
        //        {'p', "⠏"},
        //        {'q', "⠟"},
        //        {'r', "⠗"},
        //        {'s', "⠎"},
        //        {'t', "⠞"},
        //        {'u', "⠥"},
        //        {'v', "⠧"},
        //        {'w', "⠺"},
        //        {'x', "⠭"},
        //        {'y', "⠽"},
        //        {'z', "⠵"},
        //        {' ', "⠤"}
        //    };

        //    text = text.ToLower(); // Convert to lowercase for simplicity

        //    string brailleText = "";
        //    foreach (char c in text)
        //    {
        //        if (brailleMap.ContainsKey(c))
        //        {
        //            brailleText += brailleMap[c] + " "; // Add space for better visualization
        //        }
        //        else
        //        {
        //            // If the character is not in the map, just keep it as is
        //            brailleText += c;
        //        }
        //    }

        //    return brailleText.Trim(); // Trim to remove trailing space
        //}
    }
}
