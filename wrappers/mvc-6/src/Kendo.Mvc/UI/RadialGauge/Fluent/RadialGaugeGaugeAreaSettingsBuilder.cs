using System;
using System.Collections.Generic;

namespace Kendo.Mvc.UI.Fluent
{
    /// <summary>
    /// Defines the fluent API for configuring RadialGaugeGaugeAreaSettings
    /// </summary>
    public partial class RadialGaugeGaugeAreaSettingsBuilder : IHideObjectMembers
        
    {
        public RadialGaugeGaugeAreaSettingsBuilder(RadialGaugeGaugeAreaSettings container)
        {
            Container = container;
        }

        protected RadialGaugeGaugeAreaSettings Container
        {
            get;
            private set;
        }

        /// <summary>
        /// Sets the gauge area margin.
        /// </summary>
        /// <param name="top">The gauge area top margin.</param>
        /// <param name="right">The gauge area right margin.</param>
        /// <param name="bottom">The gauge area bottom margin.</param>
        /// <param name="left">The gauge area left margin.</param>
        /// <example>
        /// <code lang="CS">
        /// &lt;% Html.Kendo().LinearGauge()
        ///           .Name("linearGauge")
        ///           .GaugeArea(gaugeArea => gaugeArea.Margin(0, 5, 5, 0))
        ///           .Render();
        /// %&gt;
        /// </code>
        /// </example>        
        public RadialGaugeGaugeAreaSettingsBuilder Margin(int top, int right, int bottom, int left)
        {
            Container.Margin.Top = top;
            Container.Margin.Right = right;
            Container.Margin.Bottom = bottom;
            Container.Margin.Left = left;

            return this;
        }

        /// <summary>
        /// Sets the gauge area margin.
        /// </summary>
        /// <param name="margin">The gauge area margin.</param>         
        public RadialGaugeGaugeAreaSettingsBuilder Margin(int margin)
        {
            Container.Margin = new ChartSpacing(margin);
            return this;
        }

        /// <summary>
        /// Sets the gauge area border.
        /// </summary>
        /// <param name="width">The border width.</param>
        /// <param name="color">The border color (CSS syntax).</param>
        /// <param name="dashType">The border dash type.</param>
        /// <example>
        /// <code lang="CS">
        /// &lt;% Html.Kendo().LinearGauge()
        ///           .Name("linearGauge")
        ///           .GaugeArea(gaugeArea => gaugeArea.Border(1, "#000", ChartDashType.Dot))
        ///           .Render();
        /// %&gt;
        /// </code>
        /// </example>        
        public RadialGaugeGaugeAreaSettingsBuilder Border(int width, string color, ChartDashType dashType)
        {
            Container.Border = new ChartElementBorder(width, color, dashType);
            return this;
        }

        /// <summary>
        /// Configures the gauge area border
        /// </summary>
        /// <param name="configurator">The border configuration action</param>
        public RadialGaugeGaugeAreaSettingsBuilder Border(Action<ChartBorderBuilder> configurator)
        {
            configurator(new ChartBorderBuilder(Container.Border));
            return this;
        }
    }
}
