using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp12
{
    public partial class Form1 : Form
    {
        Model model;
        public Form1()
        {
            var table = new TableLayoutPanel() { Dock = DockStyle.Fill };
            table.ColumnStyles.Clear();
            table.RowStyles.Clear();
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 10));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 80));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 10));
            var xBoxPolygon = new RichTextBox() { Dock = DockStyle.Fill, Text = "X polygon"};
            var yBoxPolygon = new RichTextBox() { Dock = DockStyle.Fill, Text = "Y polygon" };
            var buttonPolygon = new Button() { Dock = DockStyle.Fill, Text = "Добавить точку полигона" };
            var xBoxPoint = new RichTextBox() { Dock = DockStyle.Fill };
            xBoxPoint.Text = "X point";
            var yBoxPoint = new RichTextBox() { Dock = DockStyle.Fill };
            yBoxPoint.Text = "Y point";
            var buttonPoint = new Button() { Dock = DockStyle.Fill, Text = "Протестировать точку"};
            var bigBox = new RichTextBox() { Dock = DockStyle.Fill };
            table.Controls.Add(xBoxPolygon, 0, 0);
            table.Controls.Add(yBoxPolygon, 1, 0);
            table.Controls.Add(buttonPolygon, 2, 0);
            table.Controls.Add(bigBox, 3, 1);
            table.Controls.Add(xBoxPoint, 0, 2);
            table.Controls.Add(yBoxPoint, 1, 2);
            table.Controls.Add(buttonPoint, 2, 2);
            Controls.Add(table);
            InitializeComponent();
        }
    }
}
