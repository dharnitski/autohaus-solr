using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Converters;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data;
using Sitecore.Links;
using Sitecore.StringExtensions;

namespace Autohaus.Data.Models
{

    [DebuggerDisplay("Name={Name}, TemplateName={TemplateName}, Version={Version}, Language={Language}")]
    public class SearchResultItemTest
    {
        private readonly Dictionary<string, object> fields = new Dictionary<string, object>();

        [IndexField("__smallcreateddate")]
        public DateTime CreatedDate { get; set; }

        [IndexField("urllink")]
        public string Url { get; set; }

        [IndexField("_creator")]
        public string CreatedBy { get; set; }

        [TypeConverter(typeof (IndexFieldIDValueConverter))]
        [IndexField("_group")]
        public ID ItemId { get; set; }

        [IndexField("_language")]
        public string Language { get; set; }

        [IndexField("_name")]
        public string Name { get; set; }

        [IndexField("_fullpath")]
        public string Path { get; set; }

        [TypeConverter(typeof (IndexFieldEnumerableConverter))]
        [IndexField("_path")]
        public IEnumerable<ID> Paths { get; set; }

        [IndexField("_parent")]
        public ID Parent { get; set; }

        [TypeConverter(typeof (IndexFieldIDValueConverter))]
        [IndexField("_template")]
        public ID TemplateId { get; set; }

        [IndexField("_templatename")]
        public string TemplateName { get; set; }

        [IndexField("_database")]
        public string DatabaseName { get; set; }

        [IndexField("__smallupdateddate")]
        public DateTime Updated { get; set; }

        [IndexField("_content")]
        public string Content { get; set; }

        [TypeConverter(typeof (IndexFieldEnumerableConverter))]
        [IndexField("__semantics")]
        public IEnumerable<ID> Semantics { get; set; }

        public string this[string key]
        {
            get
            {
                if (key == null)
                    throw new ArgumentNullException("key");
                else
                    return this.fields[key.ToLowerInvariant()].ToString();
            }
            set
            {
                if (key == null)
                    throw new ArgumentNullException("key");
                this.fields[key.ToLowerInvariant()] = (object)value;
            }
        }

        public object this[ObjectIndexerKey key]
        {
            get
            {
                if (key == null)
                    throw new ArgumentNullException("key");
                else
                    return this.fields[key.ToString().ToLowerInvariant()];
            }
            set
            {
                if (key == null)
                    throw new ArgumentNullException("key");
                this.fields[key.ToString().ToLowerInvariant()] = value;
            }
        }

        [IndexField("_uniqueid")]
        public string UriStr { get; set; }

        [XmlIgnore]
        public ItemUri Uri
        {
            get { return ItemUri.Parse(UriStr); }
        }
    }

    //inheritance from SearchResultItem throws Invalid cast from 'System.String' to 'Sitecore.Data.ItemUri' error for Uri field
    public class Car : SearchResultItemTest
    {
        #region Fields

        private string friendlyUrl;
        private string fullModelName;

        #endregion

        #region Basic string fields

        [IndexField("modelkey")]
        public string ModelId { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string Trim { get; set; }

        #endregion

        #region Non-string Properties

        public DateTime ManufactureDate { get; set; }

        public int EngineCC { get; set; }

        public int NumCylinders { get; set; }

        public int ValvesPerCyl { get; set; }

        public int EnginePower { get; set; }

        public bool SoldInUS { get; set; }

        public int Seats { get; set; }

        public IEnumerable<int> Doors { get; set; }

        public float Weight { get; set; }

        public float Length { get; set; }

        public float Width { get; set; }

        public float Height { get; set; }

        public float Wheelbase { get; set; }

        public float MileageHwy { get; set; }

        public float MileageCity { get; set; }

        public float MileageMixed { get; set; }

        public int TopSpeed { get; set; }

        public float ZeroToHundred { get; set; }

        public float FuelCapacity { get; set; }

        public int EnginePowerRPM { get; set; }

        public int EngineTorqueNM { get; set; }

        public float EngineBoreMM { get; set; }

        public float EngineStrokeMM { get; set; }

        public string EngineCompression { get; set; }

        #endregion

        #region Reference Fields

        public string TransmissionType { get; set; }

        public string DriveType { get; set; }

        public string BodyType { get; set; }

        public string EnginePosition { get; set; }

        public string EngineType { get; set; }

        public string EngineFuel { get; set; }

        #endregion

        #region Computed Properties

        [DataMember]
        public string FullModelName
        {
            get
            {
                if (string.IsNullOrEmpty(fullModelName))
                {
                    fullModelName = "{0} {1} {2} {3}".FormatWith(ManufactureDate.Year, Make, Model, Trim);
                }

                return fullModelName;
            }

            set { fullModelName = value; }
        }

        [DataMember]
        public string FriendlyUrl
        {
            get
            {
                if (friendlyUrl.IsNullOrEmpty())
                {
                    //friendlyUrl = "http://www.sitecore.net/";
                    friendlyUrl = Uri == null ? string.Empty : LinkManager.GetItemUrl(Database.GetItem(Uri));
                }

                return friendlyUrl;
            }

            set { friendlyUrl = value; }
        }

        #endregion
    }
}