using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Dart_Class_Generator
{
    public partial class Form1 : Form
    {
        readonly string LeftCurlyBraces = "{";
        readonly string RightCurlyBraces = "}";
        readonly string Apostrophe = "'";
        readonly string DoubleQuotes = '"'.ToString();
        string className;
        string lowerClassName;
        readonly List<string> parameters = new List<string>();
        readonly List<string> paramItems = new List<string>();
        readonly List<string> parameterTypes = new List<string>() { "int", "long", "String", "bool", "double", "decimal", "DateTime", "dynamic" };
        readonly string[] items = { "Manuel", "C# Class" };
        string type;

        public Form1()
        {
            InitializeComponent();
            RTB_Output.Font = new Font("Roboto", 10, FontStyle.Regular);
            RTB_Output.ReadOnly = true;

            CB_Source_Type.Items.AddRange(items);
            CB_Source_Type.SelectedIndex = 0;
            CB_Source_Type.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void B_Create_Click(object sender, EventArgs e)
        {
            CreateDartCode();
        }

        private void CreateDartCode()
        {
            if (string.IsNullOrEmpty(TB_Class_Name.Text.Trim()))
            {
                MessageBox.Show("Sınıf ismi boş geçilemez...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(RTB_Parameters.Text.Trim()))
            {
                MessageBox.Show("En az bir adet parametre eklemelisiniz...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if ((RTB_Parameters.Text.Contains("{") || RTB_Parameters.Text.Contains("}")) && CB_Source_Type.SelectedItem.ToString() == items[0])
            {
                MessageBox.Show($"Tip seçimi yanlış...\nSource Type => {items[1]} seçmelisiniz!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if ((!RTB_Parameters.Text.Contains("{") || !RTB_Parameters.Text.Contains("}")) && CB_Source_Type.SelectedItem.ToString() == items[1])
            {
                MessageBox.Show($"Tip seçimi yanlış...\nSource Type => {items[0]} seçmelisiniz!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            parameters.Clear();
            GetClassName();
            GetParameters();
            if (type == "ERROR")
            {
                return;
            }
            CreateCode();
            ColorCode();
        }

        private void GetClassName()
        {
            className = TB_Class_Name.Text.FirstCharToUpperCase();
            if (className == "") return;
            lowerClassName = className.FirstCharToLowerCase();
        }

        private void GetParameters()
        {
            foreach (var param in RTB_Parameters.Lines)
            {
                type = null;
                if (!string.IsNullOrEmpty(param.Trim()))
                {
                    if (CB_Source_Type.SelectedItem.ToString() == items[0])
                    {
                        type = CreateType(param.Trim());
                        parameters.Add(type);
                    }
                    else
                    {
                        type = CreateType(CreateType(param.Replace("private", "").Replace("public", "").Replace("{", "").Replace("}", "").Replace("get", "").Replace("set", "").Replace(";", "").Replace("?", "").Trim()));
                        parameters.Add(type);
                    }
                }
            }


        }

        private string CreateKey(string type)
        {
            switch (type)
            {
                case "decimal":
                    return "double";
                case "long":
                    return "int";
                default:
                    return type;
            }
        }

        private string CreateType(string text)
        {
            paramItems.Clear();

            foreach (var pi in text.Split(' '))
            {
                if (!string.IsNullOrEmpty(pi.Trim()))
                {
                    paramItems.Add(pi.Trim());
                }
            }

            if (paramItems.Count < 2)
            {
                MessageBox.Show("Lütfen geçerli bir parametre giriniz...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "ERROR";
            }

            foreach (var type in parameterTypes)
            {
                if (ComputeSimilarity.CalculateSimilarity(paramItems[0], type) >= 0.5)
                {
                    return $"{CreateKey(type)} {paramItems[1]}";
                }
            }

            if (ComputeSimilarity.CalculateSimilarity($"{paramItems[0].Split('<')[0]}<", "List<") >= 0.5 && (paramItems[0].Contains("<") || paramItems[0].Contains(">")))
            {
                foreach (var type in parameterTypes)
                {
                    if (ComputeSimilarity.CalculateSimilarity(text.TextBetweenCharacters("<", ">"), type) >= 0.5)
                    {
                        return $"List<{CreateKey(type)}?> {paramItems[1]}";
                    }
                }
                return $"List<{text.TextBetweenCharacters("<", ">")}?> {paramItems[1]}";
            }

            return text;
        }

        private string CreateFactoryValueCode(string text)
        {
            string[] paramItem = text.Split(' ');
            string paramWithQuotes = $"{DoubleQuotes}{paramItem[1]}{DoubleQuotes}";

            foreach (var type in parameterTypes)
            {
                if (ComputeSimilarity.CalculateSimilarity(paramItem[0], type) >= 0.5)
                {
                    return $"json[{paramWithQuotes}],";
                }

            }

            if (ComputeSimilarity.CalculateSimilarity($"{paramItem[0].Split('<')[0]}<", "List<") >= 0.5 && (paramItem[0].Contains("<") || paramItem[0].Contains(">")))
            {
                return $"json[{paramWithQuotes}] == null ? null : {paramItem[0]}.from(json[{paramWithQuotes}].map((x) => x)),";
            }

            return $"json[{paramWithQuotes}],";
        }

        private string CreateMapValueCode(string text)
        {
            string[] paramItem = text.Split(' ');
            string paramToLower = paramItem[1].FirstCharToLowerCase();

            foreach (var type in parameterTypes)
            {
                if (ComputeSimilarity.CalculateSimilarity(paramItem[0], type) >= 0.5)
                {
                    return $"{paramToLower},";
                }

            }

            if (ComputeSimilarity.CalculateSimilarity($"{paramItem[0].Split('<')[0]}<", "List<") >= 0.5 && (paramItem[0].Contains("<") || paramItem[0].Contains(">")))
            {
                return $"{paramToLower} == null ? null : List<dynamic>.from({paramToLower}!.map((x) => x)),";
            }

            return $"{paramToLower},";
        }

        private void CreateCode()
        {
            RTB_Output.Text = CodeText.HeaderText(className, lowerClassName);

            foreach (var param in parameters)
            {
                RTB_Output.AppendText($"\n    this.{param.Split(' ')[1].FirstCharToLowerCase()},");
            }

            RTB_Output.AppendText("\n  });\n");

            foreach (var param in parameters)
            {
                string[] paramItem = param.Split(' ');
                RTB_Output.AppendText($"\n  {paramItem[0]}? {paramItem[1].FirstCharToLowerCase()};");
            }

            RTB_Output.AppendText(CodeText.ToStringText(LeftCurlyBraces, className, Apostrophe));

            foreach (var param in parameters)
            {
                string[] paramItem = param.Split(' ');
                RTB_Output.AppendText($"{paramItem[1].FirstCharToLowerCase()}: ${paramItem[1].FirstCharToLowerCase()}, ");
            }

            RTB_Output.AppendText(CodeText.FactoryText(RightCurlyBraces, className, Apostrophe));

            foreach (var param in parameters)
            {
                string[] paramItem = param.Split(' ');
                RTB_Output.AppendText($"\n        {paramItem[1].FirstCharToLowerCase()}: {CreateFactoryValueCode(param)}");
            }

            RTB_Output.AppendText(CodeText.MapText());

            foreach (var param in parameters)
            {
                string[] paramItem = param.Split(' ');
                RTB_Output.AppendText($"\n        {DoubleQuotes}{paramItem[1]}{DoubleQuotes}: {CreateMapValueCode(param)}");
            }

            RTB_Output.AppendText(CodeText.EndText());
        }

        private void ColorCode()
        {
            CustomTextExtensions.ColorText(RTB_Output, className, Color.Green);
            string[] type = { "int", "String", "bool", "double", "DateTime", "dynamic" };
            CustomTextExtensions.ColorTextAll(RTB_Output, type, Color.Blue);
            string[] list = { "this", "factory", "=>", "?", "!", ":", "Map", "toString" };
            CustomTextExtensions.ColorTextAll(RTB_Output, list, Color.Purple);
            CustomTextExtensions.ColorQuotesText(RTB_Output, $"{DoubleQuotes}", Color.Brown);
        }

        private void B_Copy_All_Click(object sender, EventArgs e)
        {
            CopyCode();
        }

        private void CopyCode()
        {
            RTB_Output.SelectAll();
            RTB_Output.Copy();
        }

        private void RTB_Parameters_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.D)
            {
                DesignParameter();
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.G)
            {
                CreateDartCode();
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.K)
            {
                CopyCode();
            }
        }

        private void DesignParameter()
        {

            if (CB_Source_Type.SelectedItem.ToString() == items[0])
            {
                GetParameters();
                RTB_Parameters.Clear();
                foreach (var item in parameters)
                {
                    RTB_Parameters.AppendText($"{item.Trim()}\n");
                }
            }
            else
            {
                string[] paramList = RTB_Parameters.Lines;
                RTB_Parameters.Clear();

                foreach (var pl in paramList)
                {
                    RTB_Parameters.AppendText($"{pl.Trim()}\n");
                }
            }

            string[] type = { "public", "private", "get", "set" };
            CustomTextExtensions.ColorTextAll(RTB_Parameters, type, Color.Blue);
            string[] list = { "long", "int", "DateTime", "string", "String", "decimal", "double", "bool" };
            CustomTextExtensions.ColorTextAll(RTB_Parameters, list, Color.Purple);
        }

        private void B_Design_MouseHover(object sender, EventArgs e)
        {
            B_Tool_Tip.Show("Design : Ctrl+D", B_Design);
        }

        private void B_Copy_All_MouseHover(object sender, EventArgs e)
        {
            B_Tool_Tip.Show("Copy All : Ctrl+K", B_Copy_All);
        }

        private void B_Create_MouseHover(object sender, EventArgs e)
        {
            B_Tool_Tip.Show("Generate : Ctrl+G", B_Create);
        }

        private void LL_Author_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://sites.google.com/view/hsynpsdmr");
        }
    }
}
