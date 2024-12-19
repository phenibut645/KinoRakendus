using KinoRakendus.core.controls.buttons;
using KinoRakendus.core.interfaces;
using KinoRakendus.core.models.database;
using KinoRakendus.core.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using KinoRakendus.core.models;
using KinoRakendus.core.enums;

namespace KinoRakendus.core.controls
{
    public partial class AdminDefaultManagerPage<T> : UserControl where T: Table, ITable, new()
    {
        public void InitAll()
        {
            InitSelectPanel();
            InitButtons();
            InitSelectedPanel();
        }
        public void InitSelectedPanel()
        {
            SelectedPanel = new Panel();
            SelectedPanel.Size = new Size(771, 805);
            SelectedPanel.BackColor = ColorManagment.DefaultPanelColor;
            SelectedPanel.Location = new Point(900, 49);
            this.Controls.Add(SelectedPanel);
        }
        public void InitSelectPanel()
        {
            SelectPanel = new Panel();
            SelectPanel.Size = new Size(771, 805);
            SelectPanel.BackColor = ColorManagment.DefaultPanelColor;
            SelectPanel.Location = new Point(49, 49);
            this.Controls.Add(SelectPanel);

            OptionsPanel = new Panel();
            OptionsPanel.Size = new Size(771, 734);
            OptionsPanel.AutoScroll = true;
            OptionsPanel.BackColor = ColorManagment.DefaultPanelColor;
            SelectPanel.Controls.Add(OptionsPanel);

            AddPanel = new Panel();
            AddPanel.Size = new Size(771, 71);
            AddPanel.Location = new Point(0, OptionsPanel.Height);
            AddPanel.BackColor = ColorManagment.DarkerDefaultPanelColor;
            SelectPanel.Controls.Add(AddPanel);

            AddButton = new Button();
            AddButton.Size = new Size(47, 47);
            AddButton.BackgroundImage = DefaultImages.GetDefaultImage("plus-hexagon.png");
            AddButton.BackgroundImageLayout = ImageLayout.Zoom;
            AddButton.BackColor = ColorManagment.InvisibleBackGround;
            AddButton.FlatStyle = FlatStyle.Flat;
            AddButton.FlatAppearance.BorderSize = 0;
            AddButton.Location = new Point(AddPanel.Width / 2 - AddButton.Width / 2, AddPanel.Height / 2 - AddButton.Height / 2);
            AddPanel.Controls.Add(AddButton);

        }
        public void InitButtons()
        {
            List<T> records = DBHandler.GetTableData<T>();
            int currentY = this.StartOptionPositionY;
            foreach(T record in records)
            {
                OptionButton<T> button = new OptionButton<T>(record, FieldName, OptionSize);
                Console.WriteLine("LINE");
                button.Location = new Point(SelectPanel.Width / 2 - button.Width / 2, currentY);
                OptionsPanel.Controls.Add(button);
                button.AddClickMethod(Selected);
                Buttons.Add(button);
                currentY += button.Height + GapBetweenButtons;
            }
        }
        public void OnSelectSubmitted<V>(AdvancedOption<V> control) where V : Table, ITable, new()
        {
            DBHandler.UpdateRecord<T>(SelectedButton.Record, control.Field, control.CurrentValue, new List<WhereField>() { new WhereField("id", control.CurrentRecord["id"]) });
        }
        public void InitAdvancedOptions()
        {
            foreach(Control control in SelectedPanel.Controls)
            {
                control.Dispose();
            }
            this.SelectedPanel.Controls.Clear();
            List<string> fields = SelectedButton.Record.GetKeys();
            int currentY = this.StartOptionPositionY;
            foreach(string field in fields)
            {
                if(field == "id") continue;
                List<string> response = DBHandler.CheckForForeign<T>(field);
                dynamic advancedOption;
                if(response.Count != 0)
                {
                    List<SelectOption> options = new List<SelectOption>();
                   
                    Type type = TablesManagment.GetRecordType(response[0]);
                    Console.WriteLine(type.Name);
                    var method = typeof(DBHandler).GetMethod("GetTableData");
                    var genericMethod = method.MakeGenericMethod(type);
                    object result = genericMethod.Invoke(null, null);

                    if(result is IEnumerable<Table> tableList)
                    {
                        foreach (Table tableInstance in tableList)
                        {
                            Console.WriteLine($"tableInstance {tableInstance["id"]}");
                            options.Add(new SelectOption(tableInstance["id"], tableInstance.OutValue));
                        }
                    }
                    var size = new List<int> { 681, 48 };
                    var fieldSize = new List<int> { 191, 48 };
                    var valueSize = new List<int> { 442, 48 };
                    var buttonSize = new List<int> { 48, 48 };

                    var advancedOptionType = typeof(AdvancedOption<>).MakeGenericType(type);
                    Console.WriteLine(advancedOptionType.Name);
                    advancedOption = Activator.CreateInstance(advancedOptionType, enums.AdvancedOptionType.Select, int.Parse(SelectedButton.Record["id"]), field, null, null, null, null, options);
                    Console.WriteLine(advancedOption);
                    var advMethod = advancedOptionType.GetMethod("AddMethodOnSubmitted");
                    var actionType = typeof(Action<>).MakeGenericType(advancedOptionType);
                    var action = Delegate.CreateDelegate(actionType, this, typeof(AdminDefaultManagerPage<T>).GetMethod(nameof(OnSelectSubmitted)).MakeGenericMethod(type));

                    object advResult = advMethod.Invoke(advancedOption, new object[] { action });

                }
                else
                {
                    advancedOption = new AdvancedOption<T>(enums.AdvancedOptionType.TextBox, int.Parse(SelectedButton.Record["id"]), field);
                }

                advancedOption.Location = new Point(SelectedPanel.Width / 2 - advancedOption.Width / 2, currentY);
                this.SelectedPanel.Controls.Add(advancedOption);

                currentY += advancedOption.Height + this.GapBetweenButtons;
            }
            
        }
    }
}
