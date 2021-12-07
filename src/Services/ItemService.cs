using System.Threading.Tasks;
using D2RDropCalc.Server.Services.Interfaces;
using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;
using D2RDropCalc.Server.Models.ExcelFileModels;
using CsvHelper;
using System.Globalization;
using CsvHelper.Configuration;
using Newtonsoft.Json;
using D2RDropCalc.Server.Models.DTOs.Shared;

namespace D2RDropCalc.Server.Services
{
    public class ItemService : IItemService
    {
        CsvConfiguration _csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            NewLine = Environment.NewLine,
            Delimiter = "\t",
            PrepareHeaderForMatch = args => args.Header.Replace(" ", "")
        };
        public ItemService() { }

        public async Task<bool> GenerateDropRates(string name, Difficulty difficulty, int players, int mf, MonsterType monsterType)
        {
            var armor = GetArmorEntries();
            var weapons = GetWeaponEntries();
            var sets = GetSetEntries();
            var misc = GetMiscEntries();
            var uniques = GetUniqueEntries();
            var treasureClasses = GetTreasureClassEntries();
            var itemNames = GetItemNames();
            return true;
        }

        private List<D2Armor> GetArmorEntries()
        {
            using (var reader = new StreamReader("..\\Lib\\D2Files\\armor.txt"))
            using (var csv = new CsvReader(reader, _csvConfig))
            {
                return csv.GetRecords<D2Armor>().ToList();
            }
        }

        private List<D2Weapon> GetWeaponEntries()
        {
            using (var reader = new StreamReader("..\\Lib\\D2Files\\weapons.txt"))
            using (var csv = new CsvReader(reader, _csvConfig))
            {
                return csv.GetRecords<D2Weapon>().ToList();
            }
        }

        private List<D2Misc> GetMiscEntries()
        {
            using (var reader = new StreamReader("..\\Lib\\D2Files\\misc.txt"))
            using (var csv = new CsvReader(reader, _csvConfig))
            {
                return csv.GetRecords<D2Misc>().ToList();
            }
        }

        private List<D2SetItem> GetSetEntries()
        {
            using (var reader = new StreamReader("..\\Lib\\D2Files\\setitems.txt"))
            using (var csv = new CsvReader(reader, _csvConfig))
            {
                return csv.GetRecords<D2SetItem>().ToList();
            }
        }

        private List<D2UniqueItem> GetUniqueEntries()
        {
            using (var reader = new StreamReader("..\\Lib\\D2Files\\uniqueitems.txt"))
            using (var csv = new CsvReader(reader, _csvConfig))
            {
                return csv.GetRecords<D2UniqueItem>().ToList();
            }
        }

        private List<D2TreasureClass> GetTreasureClassEntries()
        {
            using (var reader = new StreamReader("..\\Lib\\D2Files\\treasureclassex.txt"))
            using (var csv = new CsvReader(reader, _csvConfig))
            {
                return csv.GetRecords<D2TreasureClass>().ToList();
            }
        }

        private List<D2ItemName> GetItemNames()
        {
            using (StreamReader r = new StreamReader("..\\Lib\\D2Files\\item-names.json"))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<D2ItemName>>(json);
            }
        }
    }
}