using Kendo.Mvc.Extensions;
using System.IO;
using System.Globalization;
using System.Linq;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Mvc.ViewFeatures;

namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Kendo UI TimePicker component
    /// </summary>
    public partial class TimePicker : WidgetBase
        
    {
        public TimePicker(ViewContext viewContext) : base(viewContext)
        {
            Animation = new PopupAnimation();
            Enabled = true;
        }

        public bool Enabled
        {
            get;
            set;
        }

        public PopupAnimation Animation
        {
            get;
            private set;
        }

        public CultureInfo CultureInfo
        {
            get
            {
                CultureInfo info = null;
                if (Culture.HasValue())
                {
                    info = new CultureInfo(Culture);
                }
                else
                {
                    info = CultureInfo.CurrentCulture;
                }

                return info;
            }
        }

        public override void ProcessSettings()
        {
            if (string.IsNullOrEmpty(Format))
            {
                Format = CultureInfo.DateTimeFormat.ShortTimePattern;
            }

            base.ProcessSettings();
        }

        protected override void WriteHtml(TextWriter writer)
        {
            var metadata = ExpressionMetadataProvider.FromStringExpression(Name, HtmlHelper.ViewData, HtmlHelper.MetadataProvider).Metadata;
            var tag = Generator.GenerateTimeInput(ViewContext, metadata, Id, Name, Value, Format, HtmlAttributes);

            if (!Enabled)
            {
                tag.MergeAttribute("disabled", "disabled");
            }

            tag.TagRenderMode = TagRenderMode.SelfClosing;
            tag.WriteTo(writer, HtmlEncoder);

            base.WriteHtml(writer);
        }

        public override void WriteInitializationScript(TextWriter writer)
        {
            var settings = SerializeSettings();

            var animation = Animation.ToJson();
            if (animation.Keys.Any())
            {
                settings["animation"] = animation["animation"];
            }

            writer.Write(Initializer.Initialize(Selector, "TimePicker", settings));
        }
    }
}
