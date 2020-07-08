using System;
using System.Globalization;
using MvvmHelpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PickerCollectionDetail.Models
{
    public partial class Category : ObservableObject
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

        private string name;
        [JsonProperty("Name")]
        public string Name
        {
            get { return name; }
            set
            {
                SetProperty(ref name, value);
            }
        }
    }

    public partial class Category
    {
        public static Category[] FromJson(string json) => JsonConvert.DeserializeObject<Category[]>(json, CategoryConverter.Settings);
    }

    public static class CategorySerialize
    {
        public static string ToJson(this Category[] self) => JsonConvert.SerializeObject(self, CategoryConverter.Settings);
    }

    internal static class CategoryConverter
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
