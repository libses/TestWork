using CsvHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp12
{
    public partial class Form1 : Form
    {
        RichTextBox xBoxPolygon;
        RichTextBox yBoxPolygon;
        RichTextBox xBoxPoint;
        RichTextBox yBoxPoint;
        RichTextBox bigBox;
        Model model;
        List<Vector> prePolygon;
        
        public void OpenFile(object sender, EventArgs e)
        {
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var fileStream = openFileDialog.OpenFile();
                    using (var reader = new StreamReader(fileStream))
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        prePolygon = csv.GetRecords<Vector>().ToList();
                    }
                }
            }
        }
        public void LogPoly(object sender, EventArgs e)
        {
            try
            {
                var x = double.Parse(xBoxPolygon.Text);
                var y = double.Parse(yBoxPolygon.Text);
                prePolygon.Add(new Vector(x, y));
                bigBox.AppendText(x + " " + y + " добавлена в полигон\n");
            }
            catch
            {
                bigBox.AppendText("Вы ввели неправильную точку. Возможно, стоит поменять точку на запятую\n");
            }
        }
        public void LogPoint(object sender, EventArgs e)
        {
            try
            {
                var x = double.Parse(xBoxPoint.Text);
                var y = double.Parse(yBoxPoint.Text);
                bigBox.AppendText(x + " " + y + " подготовлена к тесту\n");
                model = new Model(new Polygon(prePolygon), new Vector(x, y));
                var str = model.MakeChecks();
                if (str == "inside") { bigBox.AppendText("Точка внутри полигона\n"); }
                else { bigBox.AppendText("Точка снаружи полигона\n"); }
            }
            catch
            {
                bigBox.AppendText("Вы ввели неправильную точку. Возможно, стоит поменять точку на запятую\n");
            }
        }
        public Form1()
        {
            prePolygon = new List<Vector>();
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
            xBoxPolygon = new RichTextBox() { Dock = DockStyle.Fill, Text = "X polygon"};
            yBoxPolygon = new RichTextBox() { Dock = DockStyle.Fill, Text = "Y polygon" };
            var buttonPolygon = new Button() { Dock = DockStyle.Fill, Text = "Добавить точку полигона" };
            buttonPolygon.Click += LogPoly;
            xBoxPoint = new RichTextBox() { Dock = DockStyle.Fill };
            xBoxPoint.Text = "X point";
            yBoxPoint = new RichTextBox() { Dock = DockStyle.Fill };
            yBoxPoint.Text = "Y point";
            var buttonPoint = new Button() { Dock = DockStyle.Fill, Text = "Протестировать точку"};
            buttonPoint.Click += LogPoint;
            bigBox = new RichTextBox() { Dock = DockStyle.Fill };
            var csvButton = new Button() { Dock = DockStyle.Fill, Text = "Добавить из CSV" };
            csvButton.Click += OpenFile;
            table.Controls.Add(xBoxPolygon, 0, 0);
            table.Controls.Add(yBoxPolygon, 1, 0);
            table.Controls.Add(buttonPolygon, 2, 0);
            table.Controls.Add(bigBox, 3, 1);
            table.Controls.Add(xBoxPoint, 0, 2);
            table.Controls.Add(yBoxPoint, 1, 2);
            table.Controls.Add(buttonPoint, 2, 2);
            table.Controls.Add(csvButton, 3, 2);
            Controls.Add(table);
            InitializeComponent();
        }
    }
}
