using System.Globalization;
using MvvmHelpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PickerCollectionDetail.Models
{
    public partial class Item : ObservableObject
    {
        private string id;
        [JsonProperty("Id")]
        public string Id
        {
            get { return id; }
            set
            {
                SetProperty(ref id, value);
            }
        }

        private string text;
        [JsonProperty("Text")]
        public string Text
        {
            get { return text; }
            set
            {
                SetProperty(ref text, value);
            }
        }

        private string description;
        [JsonProperty("Description")]
        public string Description
        {
            get { return description; }
            set
            {
                SetProperty(ref description, value);
            }
        }

        private string categoryId;
        [JsonProperty("CategoryId")]
        public string CategoryId
        {
            get { return categoryId; }
            set
            {
                SetProperty(ref categoryId, value);
            }
        }
    }

    public partial class Item
    {
        public static Item[] FromJson(string json) => JsonConvert.DeserializeObject<Item[]>(json, ItemConverter.Settings);
    }

    public static class ItemSerialize
    {
        public static string ToJson(this Item[] self) => JsonConvert.SerializeObject(self, ItemConverter.Settings);
    }

    internal static class ItemConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
        {
            new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
        },
        };
    }
}