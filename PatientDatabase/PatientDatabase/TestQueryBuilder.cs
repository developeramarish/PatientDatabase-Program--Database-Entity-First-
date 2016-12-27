using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatientDatabase
{
    public partial class TestQueryBuilder : Form
    {
        //#region gender
        //Panel panel_gender;
        //Panel panel_gender_title;
        //Label label_gender;
        //RadioButton rb_male;
        //RadioButton rb_female;
        //Button button_gender_include;
        //Button button_gender_exclude;
        //#endregion
        //#region age
        //Panel panel_age;
        //Panel panel_age_title;
        //Label label_age;
        //Button button_age_include;
        //Button button_age_exclude;
        //ComboBox cbo_age_conditions;
        //TextBox txt_age_1;
        //TextBox txt_age_2;
        //Label lbl_and;
        //#endregion
        //#region morphine equivalent dose
        //Panel panel_morphine_equivalent_dose;
        //Panel panel_morphine_equivalent_dose_title;
        //Label label_morphine_equivalent_dose;
        //Button button_morphine_equivalent_dose_include;
        //Button button_morphine_equivalent_dose_exclude;
        //ComboBox cbo_morphine_equivalent_dose_conditions;
        //TextBox txt_value_1_morphine_equivalent_dose;
        //TextBox txt_value_2_morphine_equivalent_dose;
        //Label lbl_and_morphine_equivalent_dose;
        //Label lbl_mg_1__morphine_equivalent_dose;
        //Label lbl_mg_2__morphine_equivalent_dose;
        //#endregion
        //#region medication
        //Panel panel_medication;
        //Panel panel_medication_title;
        //Label label_medication;
        //Button button_medication_include;
        //Button button_medication_exclude;
        //TextBox txt_medication_name;
        //Button button_add_medication;
        //Button button_information_medication;
        //ListBox lst_selected_medication;
        //Button button_remove_medication;
        //#endregion
        //#region medication dose
        //Panel panel_medication_dose;
        //Panel panel_medication_dose_title;
        //Label label_medication_dose;
        //Button button_medication_dose_include;
        //Button button_medication_dose_exclude;
        //TextBox txt_medication_dose_name;
        //Button button_add_medication_dose;
        //Button button_information_medication_dose;
        //ListBox lst_selected_medication_dose;
        //Button button_remove_medication_dose;

        //ComboBox cbo_medication_dose_conditions;
        //TextBox txt_value_1_medication_dose;
        //TextBox txt_value_2_medication_dose;
        //Label lbl_and_medication_dose;
        //Label lbl_mg_1__medication_dose;
        //Label lbl_mg_2__medication_dose;
        //#endregion

        Dictionary<string, int> conditionLocations;

        public TestQueryBuilder()
        {
            InitializeComponent();
            conditionLocations = new Dictionary<string, int>();
        }

        private void TestQueryBuilder_Load(object sender, EventArgs e)
        {
            GlobalFormManager.FormOpen();
           // Load_Controls();
           // Load_Tracker();
        }

        //public void Load_Controls()
        //{
        //    #region gender
        //    // button_gender_include
        //    button_gender_include = new Button();
        //    button_gender_include.BackgroundImage = Properties.Resources.checkmark;
        //    button_gender_include.BackgroundImageLayout = ImageLayout.Center;
        //    button_gender_include.Location = new Point(10, 38);
        //    button_gender_include.Name = "button_gender_include";
        //    button_gender_include.Size = new Size(36, 36);
        //    button_gender_include.TabIndex = 3;
        //    button_gender_include.UseVisualStyleBackColor = true;
        //    button_gender_include.Click += (s, e) => 
        //    {
        //        panel_gender_title.BackColor = Color.Green;
        //        updateTrackerColors("Gender", true);
        //    };

        //    // button_gender_exclude
        //    button_gender_exclude = new Button();
        //    button_gender_exclude.BackgroundImage = Properties.Resources.redxmark;
        //    button_gender_exclude.BackgroundImageLayout = ImageLayout.Center;
        //    button_gender_exclude.Location = new Point(10, 89);
        //    button_gender_exclude.Name = "button_gender_exclude";
        //    button_gender_exclude.Size = new Size(36, 36);
        //    button_gender_exclude.TabIndex = 4;
        //    button_gender_exclude.UseVisualStyleBackColor = true;
        //    button_gender_exclude.Click += (s, e) => 
        //    {
        //        panel_gender_title.BackColor = Color.DarkRed;
        //        updateTrackerColors("Gender", false);
        //    };

        //    // rb_male
        //    rb_male = new RadioButton();
        //    rb_male.AutoSize = true;
        //    rb_male.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        //    rb_male.Location = new Point(16, 57);
        //    rb_male.Name = "rb_male";
        //    rb_male.Size = new Size(61, 24);
        //    rb_male.TabIndex = 1;
        //    rb_male.TabStop = true;
        //    rb_male.Text = "Male";
        //    rb_male.UseVisualStyleBackColor = true;

        //    // rb_female
        //    rb_female = new RadioButton();
        //    rb_female.AutoSize = true;
        //    rb_female.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        //    rb_female.Location = new System.Drawing.Point(93, 57);
        //    rb_female.Name = "rb_female";
        //    rb_female.Size = new System.Drawing.Size(80, 24);
        //    rb_female.TabIndex = 2;
        //    rb_female.TabStop = true;
        //    rb_female.Text = "Female";
        //    rb_female.UseVisualStyleBackColor = true;

        //    // label_gender
        //    label_gender = new Label();
        //    label_gender.AutoSize = true;
        //    label_gender.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        //    label_gender.ForeColor = Color.White;
        //    label_gender.Location = new Point(3, 2);
        //    label_gender.Name = "label_gender";
        //    label_gender.Size = new Size(74, 24);
        //    label_gender.TabIndex = 0;
        //    label_gender.Text = "Gender";

        //    // panel_gender_title
        //    panel_gender_title = new Panel();
        //    panel_gender_title.Anchor = (AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
        //    panel_gender_title.BackColor = Color.DarkRed;
        //    panel_gender_title.Controls.Add(label_gender);
        //    panel_gender_title.Location = new Point(0, 0);
        //    panel_gender_title.Name = "panel_gender_title";
        //    panel_gender_title.Size = new Size(561, 29);
        //    panel_gender_title.TabIndex = 5;

        //    // panel_gender
        //    panel_gender = new Panel();
        //    panel_gender.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
        //    panel_gender.BorderStyle = BorderStyle.FixedSingle;
        //    panel_gender.Controls.Add(panel_gender_title);
        //    panel_gender.Controls.Add(rb_male);
        //    panel_gender.Controls.Add(rb_female);
        //    panel_gender.Location = new Point(56, 10);
        //    panel_gender.Name = "panel_gender";
        //    panel_gender.Size = new Size(562, 115);
        //    panel_gender.TabIndex = 0;

        //    panel_builder_controls.Controls.Add(panel_gender);
        //    panel_builder_controls.Controls.Add(button_gender_include);
        //    panel_builder_controls.Controls.Add(button_gender_exclude);
        //    #endregion
        //    #region age
        //    // button_age_include
        //    button_age_include = new Button();
        //    button_age_include.BackgroundImage = Properties.Resources.checkmark;
        //    button_age_include.BackgroundImageLayout = ImageLayout.Center;
        //    button_age_include.Location = new Point(10, 168);
        //    button_age_include.Name = "button_age_include";
        //    button_age_include.Size = new Size(36, 36);
        //    button_age_include.TabIndex = 3;
        //    button_age_include.UseVisualStyleBackColor = true;
        //    button_age_include.Click += (s, e) => 
        //    {
        //        panel_age_title.BackColor = Color.Green;
        //        updateTrackerColors("Age", true);
        //    };

        //    // button_age_exclude
        //    button_age_exclude = new Button();
        //    button_age_exclude.BackgroundImage = Properties.Resources.redxmark;
        //    button_age_exclude.BackgroundImageLayout = ImageLayout.Center;
        //    button_age_exclude.Location = new Point(10, 219);
        //    button_age_exclude.Name = "button_age_exclude";
        //    button_age_exclude.Size = new Size(36, 36);
        //    button_age_exclude.TabIndex = 4;
        //    button_age_exclude.UseVisualStyleBackColor = true;
        //    button_age_exclude.Click += (s, e) => 
        //    {
        //        panel_age_title.BackColor = Color.DarkRed;
        //        updateTrackerColors("Age", false);
        //    };

        //    // label_age
        //    label_age = new Label();
        //    label_age.AutoSize = true;
        //    label_age.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        //    label_age.ForeColor = Color.White;
        //    label_age.Location = new Point(3, 2);
        //    label_age.Name = "label_age";
        //    label_age.Size = new Size(74, 24);
        //    label_age.TabIndex = 0;
        //    label_age.Text = "Age";

        //    // panel_age_title
        //    panel_age_title = new Panel();
        //    panel_age_title.Anchor = (AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
        //    panel_age_title.BackColor = Color.DarkRed;
        //    panel_age_title.Controls.Add(label_age);
        //    panel_age_title.Location = new Point(0, 0);
        //    panel_age_title.Name = "panel_age_title";
        //    panel_age_title.Size = new Size(561, 29);
        //    panel_age_title.TabIndex = 5;

        //    // cbo_age_conditions
        //    cbo_age_conditions = new ComboBox();
        //    cbo_age_conditions.DropDownStyle = ComboBoxStyle.DropDownList;
        //    cbo_age_conditions.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        //    cbo_age_conditions.FormattingEnabled = true;
        //    cbo_age_conditions.Items.AddRange(new object[] {
        //    "Is Equal To",
        //    "Is Greater Than",
        //    "Is Less Than",
        //    "Is Between"});
        //    cbo_age_conditions.Location = new System.Drawing.Point(16, 55);
        //    cbo_age_conditions.Name = "cbo_age_conditions";
        //    cbo_age_conditions.Size = new System.Drawing.Size(164, 28);
        //    cbo_age_conditions.TabIndex = 6;
        //    cbo_age_conditions.SelectedIndex = 0;
        //    cbo_age_conditions.SelectedIndexChanged += (s, e) => 
        //    {
        //        if ((string)cbo_age_conditions.SelectedItem == "Is Between")
        //        {
        //            lbl_and.Visible = true;
        //            txt_age_2.Visible = true;
        //        }
        //        else
        //        {
        //            lbl_and.Visible = false;
        //            txt_age_2.Clear();
        //            txt_age_2.Visible = false;
        //        }
        //    };

        //    // txt_age_1
        //    txt_age_1 = new TextBox();
        //    txt_age_1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        //    txt_age_1.Location = new System.Drawing.Point(205, 57);
        //    txt_age_1.Name = "txt_age_1";
        //    txt_age_1.Size = new System.Drawing.Size(100, 26);
        //    txt_age_1.TabIndex = 7;

        //    // txt_age_2
        //    txt_age_2 = new TextBox();
        //    txt_age_2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        //    txt_age_2.Location = new Point(353, 57);
        //    txt_age_2.Name = "txt_age_2";
        //    txt_age_2.Size = new Size(100, 26);
        //    txt_age_2.TabIndex = 8;
        //    txt_age_2.Visible = false;

        //    // lbl_and
        //    lbl_and = new Label();
        //    lbl_and.AutoSize = true;
        //    lbl_and.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        //    lbl_and.Location = new Point(311, 60);
        //    lbl_and.Name = "lbl_and";
        //    lbl_and.Size = new Size(36, 20);
        //    lbl_and.TabIndex = 9;
        //    lbl_and.Text = "and";
        //    lbl_and.Visible = false;

        //    // panel_age
        //    panel_age = new Panel();
        //    panel_age.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
        //    panel_age.BorderStyle = BorderStyle.FixedSingle;
        //    panel_age.Controls.Add(panel_age_title);
        //    panel_age.Controls.Add(cbo_age_conditions);
        //    panel_age.Controls.Add(txt_age_1);
        //    panel_age.Controls.Add(txt_age_2);
        //    panel_age.Controls.Add(lbl_and);
        //    panel_age.Location = new Point(56, 140);
        //    panel_age.Name = "panel_age";
        //    panel_age.Size = new Size(562, 115);
        //    panel_age.TabIndex = 0;

        //    panel_builder_controls.Controls.Add(panel_age);
        //    panel_builder_controls.Controls.Add(button_age_include);
        //    panel_builder_controls.Controls.Add(button_age_exclude);
        //    #endregion
        //    #region morphine equivalent dose
        //    // button_morphine_equivalent_dose_include
        //    button_morphine_equivalent_dose_include = new Button();
        //    button_morphine_equivalent_dose_include.BackgroundImage = Properties.Resources.checkmark;
        //    button_morphine_equivalent_dose_include.BackgroundImageLayout = ImageLayout.Center;
        //    button_morphine_equivalent_dose_include.Location = new Point(10, 298);
        //    button_morphine_equivalent_dose_include.Name = "button_morphine_equivalent_dose_include";
        //    button_morphine_equivalent_dose_include.Size = new Size(36, 36);
        //    button_morphine_equivalent_dose_include.TabIndex = 3;
        //    button_morphine_equivalent_dose_include.UseVisualStyleBackColor = true;
        //    button_morphine_equivalent_dose_include.Click += (s, e) => 
        //    {
        //        panel_morphine_equivalent_dose_title.BackColor = Color.Green;
        //        updateTrackerColors("Morphine Equivalent Dose", true);
        //    };

        //    // button_morphine_equivalent_dose_exclude
        //    button_morphine_equivalent_dose_exclude = new Button();
        //    button_morphine_equivalent_dose_exclude.BackgroundImage = Properties.Resources.redxmark;
        //    button_morphine_equivalent_dose_exclude.BackgroundImageLayout = ImageLayout.Center;
        //    button_morphine_equivalent_dose_exclude.Location = new Point(10, 349);
        //    button_morphine_equivalent_dose_exclude.Name = "button_morphine_equivalent_dose_exclude";
        //    button_morphine_equivalent_dose_exclude.Size = new Size(36, 36);
        //    button_morphine_equivalent_dose_exclude.TabIndex = 4;
        //    button_morphine_equivalent_dose_exclude.UseVisualStyleBackColor = true;
        //    button_morphine_equivalent_dose_exclude.Click += (s, e) => 
        //    {
        //        panel_morphine_equivalent_dose_title.BackColor = Color.DarkRed;
        //        updateTrackerColors("Morphine Equivalent Dose", false);
        //    };

        //    // label_morphine_equivalent_dose
        //    label_morphine_equivalent_dose = new Label();
        //    label_morphine_equivalent_dose.AutoSize = true;
        //    label_morphine_equivalent_dose.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        //    label_morphine_equivalent_dose.ForeColor = Color.White;
        //    label_morphine_equivalent_dose.Location = new Point(3, 2);
        //    label_morphine_equivalent_dose.Name = "label_morphine_equivalent_dose";
        //    label_morphine_equivalent_dose.Size = new Size(74, 24);
        //    label_morphine_equivalent_dose.TabIndex = 0;
        //    label_morphine_equivalent_dose.Text = "Morphine Equivalent Dose";

        //    // panel_morphine_equivalent_dose_title
        //    panel_morphine_equivalent_dose_title = new Panel();
        //    panel_morphine_equivalent_dose_title.Anchor = (AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
        //    panel_morphine_equivalent_dose_title.BackColor = Color.DarkRed;
        //    panel_morphine_equivalent_dose_title.Controls.Add(label_morphine_equivalent_dose);
        //    panel_morphine_equivalent_dose_title.Location = new Point(0, 0);
        //    panel_morphine_equivalent_dose_title.Name = "panel_morphine_equivalent_dose_title";
        //    panel_morphine_equivalent_dose_title.Size = new Size(561, 29);
        //    panel_morphine_equivalent_dose_title.TabIndex = 5;

        //    // cbo_morphine_equivalent_dose_conditions
        //    cbo_morphine_equivalent_dose_conditions = new ComboBox();
        //    cbo_morphine_equivalent_dose_conditions.DropDownStyle = ComboBoxStyle.DropDownList;
        //    cbo_morphine_equivalent_dose_conditions.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        //    cbo_morphine_equivalent_dose_conditions.FormattingEnabled = true;
        //    cbo_morphine_equivalent_dose_conditions.Items.AddRange(new object[] {
        //    "Is Equal To",
        //    "Is Greater Than",
        //    "Is Less Than",
        //    "Is Between"});
        //    cbo_morphine_equivalent_dose_conditions.Location = new System.Drawing.Point(16, 55);
        //    cbo_morphine_equivalent_dose_conditions.Name = "cbo_morphine_equivalent_dose_conditions";
        //    cbo_morphine_equivalent_dose_conditions.Size = new System.Drawing.Size(164, 28);
        //    cbo_morphine_equivalent_dose_conditions.TabIndex = 6;
        //    cbo_morphine_equivalent_dose_conditions.SelectedIndex = 0;
        //    cbo_morphine_equivalent_dose_conditions.SelectedIndexChanged += (s, e) =>
        //    {
        //        if ((string)cbo_morphine_equivalent_dose_conditions.SelectedItem == "Is Between")
        //        {
        //            lbl_and_morphine_equivalent_dose.Visible = true;
        //            txt_value_2_morphine_equivalent_dose.Visible = true;
        //            lbl_mg_2__morphine_equivalent_dose.Visible = true;
        //        }
        //        else
        //        {
        //            lbl_and_morphine_equivalent_dose.Visible = false;
        //            txt_value_2_morphine_equivalent_dose.Visible = false;
        //            lbl_mg_2__morphine_equivalent_dose.Visible = false;
        //        }
        //    };

        //    // txt_value_1_morphine_equivalent_dose_1
        //    txt_value_1_morphine_equivalent_dose = new TextBox();
        //    txt_value_1_morphine_equivalent_dose.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        //    txt_value_1_morphine_equivalent_dose.Location = new System.Drawing.Point(205, 57);
        //    txt_value_1_morphine_equivalent_dose.Name = "txt_value_1_morphine_equivalent_dose";
        //    txt_value_1_morphine_equivalent_dose.Size = new System.Drawing.Size(100, 26);
        //    txt_value_1_morphine_equivalent_dose.TabIndex = 7;

        //    // txt_value_2__morphine_equivalent_dose
        //    txt_value_2_morphine_equivalent_dose = new TextBox();
        //    txt_value_2_morphine_equivalent_dose.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        //    txt_value_2_morphine_equivalent_dose.Location = new Point(390, 57);
        //    txt_value_2_morphine_equivalent_dose.Name = "txt_value_2_morphine_equivalent_dose";
        //    txt_value_2_morphine_equivalent_dose.Size = new Size(100, 26);
        //    txt_value_2_morphine_equivalent_dose.TabIndex = 8;
        //    txt_value_2_morphine_equivalent_dose.Visible = false;

        //    // lbl_and_morphine_equivalent_dose
        //    lbl_and_morphine_equivalent_dose = new Label();
        //    lbl_and_morphine_equivalent_dose.AutoSize = true;
        //    lbl_and_morphine_equivalent_dose.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        //    lbl_and_morphine_equivalent_dose.Location = new Point(348, 60);
        //    lbl_and_morphine_equivalent_dose.Name = "lbl_and_morphine_equivalent_dose";
        //    lbl_and_morphine_equivalent_dose.Size = new Size(36, 20);
        //    lbl_and_morphine_equivalent_dose.TabIndex = 9;
        //    lbl_and_morphine_equivalent_dose.Text = "and";
        //    lbl_and_morphine_equivalent_dose.Visible = false;

        //    // lbl_mg_1__morphine_equivalent_dose
        //    lbl_mg_1__morphine_equivalent_dose = new Label();
        //    lbl_mg_1__morphine_equivalent_dose.AutoSize = true;
        //    lbl_mg_1__morphine_equivalent_dose.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        //    lbl_mg_1__morphine_equivalent_dose.Location = new Point(311, 60);
        //    lbl_mg_1__morphine_equivalent_dose.Name = "lbl_mg_1__morphine_equivalent_dose";
        //    lbl_mg_1__morphine_equivalent_dose.Size = new Size(31, 20);
        //    lbl_mg_1__morphine_equivalent_dose.TabIndex = 10;
        //    lbl_mg_1__morphine_equivalent_dose.Text = "mg";

        //    // lbl_mg_2__morphine_equivalent_dose
        //    lbl_mg_2__morphine_equivalent_dose = new Label();
        //    lbl_mg_2__morphine_equivalent_dose.AutoSize = true;
        //    lbl_mg_2__morphine_equivalent_dose.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        //    lbl_mg_2__morphine_equivalent_dose.Location = new Point(496, 60);
        //    lbl_mg_2__morphine_equivalent_dose.Name = "lbl_mg_2__morphine_equivalent_dose";
        //    lbl_mg_2__morphine_equivalent_dose.Size = new Size(31, 20);
        //    lbl_mg_2__morphine_equivalent_dose.TabIndex = 11;
        //    lbl_mg_2__morphine_equivalent_dose.Text = "mg";
        //    lbl_mg_2__morphine_equivalent_dose.Visible = false;

        //     // panel_morphine_equivalent_dose
        //    panel_morphine_equivalent_dose = new Panel();
        //    panel_morphine_equivalent_dose.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
        //    panel_morphine_equivalent_dose.BorderStyle = BorderStyle.FixedSingle;
        //    panel_morphine_equivalent_dose.Controls.Add(panel_morphine_equivalent_dose_title);
        //    panel_morphine_equivalent_dose.Controls.Add(cbo_morphine_equivalent_dose_conditions);
        //    panel_morphine_equivalent_dose.Controls.Add(txt_value_1_morphine_equivalent_dose);
        //    panel_morphine_equivalent_dose.Controls.Add(txt_value_2_morphine_equivalent_dose);
        //    panel_morphine_equivalent_dose.Controls.Add(lbl_and_morphine_equivalent_dose);
        //    panel_morphine_equivalent_dose.Controls.Add(lbl_mg_1__morphine_equivalent_dose);
        //    panel_morphine_equivalent_dose.Controls.Add(lbl_mg_2__morphine_equivalent_dose);
        //    panel_morphine_equivalent_dose.Location = new Point(56, 270);
        //    panel_morphine_equivalent_dose.Name = "panel_morphine_equivalent_dose";
        //    panel_morphine_equivalent_dose.Size = new Size(562, 115);
        //    panel_morphine_equivalent_dose.TabIndex = 0;

        //    panel_builder_controls.Controls.Add(panel_morphine_equivalent_dose);
        //    panel_builder_controls.Controls.Add(button_morphine_equivalent_dose_include);
        //    panel_builder_controls.Controls.Add(button_morphine_equivalent_dose_exclude);
        //    #endregion
        //    #region medication
        //    // button_medication_include
        //    button_medication_include = new Button();
        //    button_medication_include.BackgroundImage = Properties.Resources.checkmark;
        //    button_medication_include.BackgroundImageLayout = ImageLayout.Center;
        //    button_medication_include.Location = new Point(10, 428);
        //    button_medication_include.Name = "button_medication_include";
        //    button_medication_include.Size = new Size(36, 36);
        //    button_medication_include.TabIndex = 3;
        //    button_medication_include.UseVisualStyleBackColor = true;
        //    button_medication_include.Click += (s, e) => 
        //    {
        //        panel_medication_title.BackColor = Color.Green;
        //        updateTrackerColors("Medication", true);
        //    };

        //    // button_medication_exclude
        //    button_medication_exclude = new Button();
        //    button_medication_exclude.BackgroundImage = Properties.Resources.redxmark;
        //    button_medication_exclude.BackgroundImageLayout = ImageLayout.Center;
        //    button_medication_exclude.Location = new Point(10, 479);
        //    button_medication_exclude.Name = "button_medication_exclude";
        //    button_medication_exclude.Size = new Size(36, 36);
        //    button_medication_exclude.TabIndex = 4;
        //    button_medication_exclude.UseVisualStyleBackColor = true;
        //    button_medication_exclude.Click += (s, e) => 
        //    {
        //        panel_medication_title.BackColor = Color.DarkRed;
        //        updateTrackerColors("Medication", false);
        //    };

        //    // label_medication
        //    label_medication = new Label();
        //    label_medication.AutoSize = true;
        //    label_medication.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        //    label_medication.ForeColor = Color.White;
        //    label_medication.Location = new Point(3, 2);
        //    label_medication.Name = "label_medication";
        //    label_medication.Size = new Size(74, 24);
        //    label_medication.TabIndex = 0;
        //    label_medication.Text = "Medication";

        //    // panel_medication_title
        //    panel_medication_title = new Panel();
        //    panel_medication_title.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
        //    panel_medication_title.BackColor = Color.DarkRed;
        //    panel_medication_title.Controls.Add(label_medication);
        //    panel_medication_title.Location = new Point(0, 0);
        //    panel_medication_title.Name = "panel_medication_title";
        //    panel_medication_title.Size = new Size(561, 29);
        //    panel_medication_title.TabIndex = 5;

        //    // txt_medication_name
        //    txt_medication_name = new TextBox();
        //    txt_medication_name.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        //    txt_medication_name.Location = new Point(16, 83);
        //    txt_medication_name.Name = "txt_medication_name";
        //    txt_medication_name.Size = new Size(138, 26);
        //    txt_medication_name.TabIndex = 6;

        //    // button_add_medication
        //    button_add_medication = new Button();
        //    button_add_medication.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        //    button_add_medication.Location = new Point(16, 115);
        //    button_add_medication.Name = "button_add_medication";
        //    button_add_medication.Size = new Size(138, 28);
        //    button_add_medication.TabIndex = 9;
        //    button_add_medication.Text = "Add";
        //    button_add_medication.UseVisualStyleBackColor = true;

        //    // button_information_medication
        //    button_information_medication = new Button();
        //    button_information_medication.BackgroundImage = Properties.Resources.information;
        //    button_information_medication.BackgroundImageLayout = ImageLayout.Center;
        //    button_information_medication.Location = new Point(160, 84);
        //    button_information_medication.Name = "button_information_medication";
        //    button_information_medication.Size = new Size(28, 23);
        //    button_information_medication.TabIndex = 7;
        //    button_information_medication.UseVisualStyleBackColor = true;

        //    // lst_selected_medication
        //    lst_selected_medication = new ListBox();
        //    lst_selected_medication.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        //    lst_selected_medication.FormattingEnabled = true;
        //    lst_selected_medication.HorizontalScrollbar = true;
        //    lst_selected_medication.ItemHeight = 20;
        //    lst_selected_medication.Location = new Point(214, 42);
        //    lst_selected_medication.Name = "lst_selected_medication";
        //    lst_selected_medication.Size = new Size(138, 104);
        //    lst_selected_medication.TabIndex = 8;

        //    // button_remove_medication
        //    button_remove_medication = new Button();
        //    button_remove_medication.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        //    button_remove_medication.Location = new Point(214, 152);
        //    button_remove_medication.Name = "button_remove_medication";
        //    button_remove_medication.Size = new Size(138, 28);
        //    button_remove_medication.TabIndex = 10;
        //    button_remove_medication.Text = "Remove";
        //    button_remove_medication.UseVisualStyleBackColor = true;

        //    // panel_medication
        //    panel_medication = new Panel();
        //    panel_medication.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
        //    panel_medication.BorderStyle = BorderStyle.FixedSingle;
        //    panel_medication.Controls.Add(panel_medication_title);
        //    panel_medication.Controls.Add(txt_medication_name);
        //    panel_medication.Controls.Add(button_add_medication);
        //    panel_medication.Controls.Add(button_information_medication);
        //    panel_medication.Controls.Add(lst_selected_medication);
        //    panel_medication.Controls.Add(button_remove_medication);
        //    panel_medication.Location = new Point(56, 400);
        //    panel_medication.Name = "panel_medication";
        //    panel_medication.Size = new Size(545, 196);
        //    panel_medication.TabIndex = 10;

        //    panel_builder_controls.Controls.Add(panel_medication);
        //    panel_builder_controls.Controls.Add(button_medication_include);
        //    panel_builder_controls.Controls.Add(button_medication_exclude);
        //    #endregion
        //    #region medication dose
        //    // button_medication_dose_include
        //    button_medication_dose_include = new Button();
        //    button_medication_dose_include.BackgroundImage = Properties.Resources.checkmark;
        //    button_medication_dose_include.BackgroundImageLayout = ImageLayout.Center;
        //    button_medication_dose_include.Location = new Point(10, 428);
        //    button_medication_dose_include.Name = "button_medication_dose_include";
        //    button_medication_dose_include.Size = new Size(36, 36);
        //    button_medication_dose_include.TabIndex = 3;
        //    button_medication_dose_include.UseVisualStyleBackColor = true;
        //    button_medication_dose_include.Click += (s, e) =>
        //    {
        //        panel_medication_dose_title.BackColor = Color.Green;
        //        updateTrackerColors("medication_dose", true);
        //    };

        //    // button_medication_dose_exclude
        //    button_medication_dose_exclude = new Button();
        //    button_medication_dose_exclude.BackgroundImage = Properties.Resources.redxmark;
        //    button_medication_dose_exclude.BackgroundImageLayout = ImageLayout.Center;
        //    button_medication_dose_exclude.Location = new Point(10, 479);
        //    button_medication_dose_exclude.Name = "button_medication_dose_exclude";
        //    button_medication_dose_exclude.Size = new Size(36, 36);
        //    button_medication_dose_exclude.TabIndex = 4;
        //    button_medication_dose_exclude.UseVisualStyleBackColor = true;
        //    button_medication_dose_exclude.Click += (s, e) =>
        //    {
        //        panel_medication_dose_title.BackColor = Color.DarkRed;
        //        updateTrackerColors("medication_dose", false);
        //    };

        //    // label_medication_dose
        //    label_medication_dose = new Label();
        //    label_medication_dose.AutoSize = true;
        //    label_medication_dose.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        //    label_medication_dose.ForeColor = Color.White;
        //    label_medication_dose.Location = new Point(3, 2);
        //    label_medication_dose.Name = "label_medication_dose";
        //    label_medication_dose.Size = new Size(74, 24);
        //    label_medication_dose.TabIndex = 0;
        //    label_medication_dose.Text = "Medication Dose";

        //    // panel_medication_dose_title
        //    panel_medication_dose_title = new Panel();
        //    panel_medication_dose_title.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
        //    panel_medication_dose_title.BackColor = Color.DarkRed;
        //    panel_medication_dose_title.Controls.Add(label_medication_dose);
        //    panel_medication_dose_title.Location = new Point(0, 0);
        //    panel_medication_dose_title.Name = "panel_medication_dose_title";
        //    panel_medication_dose_title.Size = new Size(561, 29);
        //    panel_medication_dose_title.TabIndex = 5;

        //    // txt_medication_dose_name
        //    txt_medication_dose_name = new TextBox();
        //    txt_medication_dose_name.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        //    txt_medication_dose_name.Location = new Point(16, 48);
        //    txt_medication_dose_name.Name = "txt_medication_dose_name";
        //    txt_medication_dose_name.Size = new Size(138, 26);
        //    txt_medication_dose_name.TabIndex = 6;

        //    // button_add_medication_dose
        //    button_add_medication_dose = new Button();
        //    button_add_medication_dose.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        //    button_add_medication_dose.Location = new Point(16, 137);
        //    button_add_medication_dose.Name = "button_add_medication_dose";
        //    button_add_medication_dose.Size = new Size(138, 28);
        //    button_add_medication_dose.TabIndex = 9;
        //    button_add_medication_dose.Text = "Add";
        //    button_add_medication_dose.UseVisualStyleBackColor = true;

        //    // button_information_medication_dose
        //    button_information_medication_dose = new Button();
        //    button_information_medication_dose.BackgroundImage = Properties.Resources.information;
        //    button_information_medication_dose.BackgroundImageLayout = ImageLayout.Center;
        //    button_information_medication_dose.Location = new Point(160, 49);
        //    button_information_medication_dose.Name = "button_information_medication_dose";
        //    button_information_medication_dose.Size = new Size(28, 23);
        //    button_information_medication_dose.TabIndex = 7;
        //    button_information_medication_dose.UseVisualStyleBackColor = true;

        //    // lst_selected_medication_dose
        //    lst_selected_medication_dose = new ListBox();
        //    lst_selected_medication_dose.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        //    lst_selected_medication_dose.FormattingEnabled = true;
        //    lst_selected_medication_dose.HorizontalScrollbar = true;
        //    lst_selected_medication_dose.ItemHeight = 20;
        //    lst_selected_medication_dose.Location = new Point(358, 40);
        //    lst_selected_medication_dose.Name = "lst_selected_medication_dose";
        //    lst_selected_medication_dose.Size = new Size(138, 144);
        //    lst_selected_medication_dose.TabIndex = 8;
        //    lst_selected_medication_dose.Visible = false;

        //    // cbo_medication_dose_conditions
        //    cbo_medication_dose_conditions = new ComboBox();
        //    cbo_medication_dose_conditions.DropDownStyle = ComboBoxStyle.DropDownList;
        //    cbo_medication_dose_conditions.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        //    cbo_medication_dose_conditions.FormattingEnabled = true;
        //    cbo_medication_dose_conditions.Items.AddRange(new object[] {
        //    "Is Equal To",
        //    "Is Greater Than",
        //    "Is Less Than",
        //    "Is Between" });
        //    cbo_medication_dose_conditions.Location = new Point(16, 97);
        //    cbo_medication_dose_conditions.Name = "cbo_medication_dose_conditions";
        //    cbo_medication_dose_conditions.Size = new Size(164, 28);
        //    cbo_medication_dose_conditions.TabIndex = 12;
        //    cbo_morphine_equivalent_dose_conditions.SelectedIndex = 0;
        //    cbo_morphine_equivalent_dose_conditions.SelectedIndexChanged += (s, e) =>
        //    {
        //        if ((string)cbo_morphine_equivalent_dose_conditions.SelectedItem == "Is Between")
        //        {
        //            lbl_and_morphine_equivalent_dose.Visible = true;
        //            txt_value_2_morphine_equivalent_dose.Visible = true;
        //            lbl_mg_2__morphine_equivalent_dose.Visible = true;
        //        }
        //        else
        //        {
        //            lbl_and_morphine_equivalent_dose.Visible = false;
        //            txt_value_2_morphine_equivalent_dose.Visible = false;
        //            lbl_mg_2__morphine_equivalent_dose.Visible = false;
        //        }
        //    };

        //    // txt_value_1_medication_dose
        //    txt_value_1_medication_dose = new TextBox();
        //    txt_value_1_medication_dose.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        //    txt_value_1_medication_dose.Location = new Point(201, 97);
        //    txt_value_1_medication_dose.Name = "txt_value_1_medication_dose";
        //    txt_value_1_medication_dose.Size = new Size(100, 26);
        //    txt_value_1_medication_dose.TabIndex = 18;

        //    // lbl_mg_1__medication_dose
        //    lbl_mg_1__medication_dose = new Label();
        //    lbl_mg_1__medication_dose.AutoSize = true;
        //    lbl_mg_1__medication_dose.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        //    lbl_mg_1__medication_dose.Location = new Point(307, 100);
        //    lbl_mg_1__medication_dose.Name = "lbl_mg_1__medication_dose";
        //    lbl_mg_1__medication_dose.Size = new Size(31, 20);
        //    lbl_mg_1__medication_dose.TabIndex = 19;
        //    lbl_mg_1__medication_dose.Text = "mg";

        //    // lbl_and_medication_dose
        //    lbl_and_medication_dose = new Label();
        //    lbl_and_medication_dose.AutoSize = true;
        //    lbl_and_medication_dose.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        //    lbl_and_medication_dose.Location = new Point(344, 100);
        //    lbl_and_medication_dose.Name = "lbl_and_medication_dose";
        //    lbl_and_medication_dose.Size = new Size(36, 20);
        //    lbl_and_medication_dose.TabIndex = 15;
        //    lbl_and_medication_dose.Text = "and";
        //   // lbl_and_medication_dose.Visible = false;

        //    // button_remove_medication_dose
        //    button_remove_medication_dose = new Button();
        //    button_remove_medication_dose.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        //    button_remove_medication_dose.Location = new Point(358, 190);
        //    button_remove_medication_dose.Name = "button_remove_medication_dose";
        //    button_remove_medication_dose.Size = new Size(138, 28);
        //    button_remove_medication_dose.TabIndex = 10;
        //    button_remove_medication_dose.Text = "Remove";
        //    button_remove_medication_dose.UseVisualStyleBackColor = true;

        //    // panel_medication_dose
        //    panel_medication_dose = new Panel();
        //    panel_medication_dose.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
        //    panel_medication_dose.BorderStyle = BorderStyle.FixedSingle;
        //    panel_medication_dose.Controls.Add(panel_medication_dose_title);
        //    panel_medication_dose.Controls.Add(txt_medication_dose_name);
        //    panel_medication_dose.Controls.Add(button_add_medication_dose);
        //    panel_medication_dose.Controls.Add(button_information_medication_dose);
        //    panel_medication_dose.Controls.Add(lst_selected_medication_dose);
        //    panel_medication_dose.Controls.Add(button_remove_medication_dose);
        //    panel_medication_dose.Controls.Add(cbo_medication_dose_conditions);
        //    panel_medication_dose.Controls.Add(txt_value_1_medication_dose);
        //    panel_medication_dose.Controls.Add(lbl_mg_1__medication_dose);
        //    panel_medication_dose.Controls.Add(lbl_and_medication_dose);
        //    panel_medication_dose.Location = new Point(56, 612);
        //    panel_medication_dose.Name = "panel_medication_dose";
        //    panel_medication_dose.Size = new Size(545, 231);
        //    panel_medication_dose.TabIndex = 10;

        //    panel_builder_controls.Controls.Add(panel_medication_dose);
        //    panel_builder_controls.Controls.Add(button_medication_dose_include);
        //    panel_builder_controls.Controls.Add(button_medication_dose_exclude);
        //    #endregion

        //    panel_builder_controls.Controls.Add(new TextBox() { Location = new Point(2000, 2000) });
        //}

        //public void Load_Tracker()
        //{
        //    dgv_builder_tracker.Rows.Add("Gender");
        //    dgv_builder_tracker.Rows.Add("Age");
        //    dgv_builder_tracker.Rows.Add("Morphine Equivalent Dose");
        //    dgv_builder_tracker.Rows.Add("Medication");
        //    foreach (DataGridViewRow row in dgv_builder_tracker.Rows)
        //    {
        //        row.MinimumHeight = 50;
        //        row.DefaultCellStyle.BackColor = Color.DarkRed;
        //        row.DefaultCellStyle.ForeColor = Color.White;
        //    }
        //    setCellBackgroundColor();
        //    loadConditionLocations();
        //}

        private void TestQueryBuilder_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlobalFormManager.FormClose();
        }

        private void dgv_builder_tracker_SelectionChanged(object sender, EventArgs e)
        {
            setCellBackgroundColor();
        }

        private void updateTrackerColors(string value, bool activate)
        {                
            if (activate)
            {
                dgv_builder_tracker.Rows[conditionLocations[value]].DefaultCellStyle.BackColor = Color.Green;
            }
            else
            {
                dgv_builder_tracker.Rows[conditionLocations[value]].DefaultCellStyle.BackColor = Color.DarkRed;
            }
            setCellBackgroundColor();
        }

        private void setCellBackgroundColor()
        {
            if (dgv_builder_tracker.Rows[dgv_builder_tracker.CurrentRow.Index].DefaultCellStyle.BackColor == Color.DarkRed)
            {
                dgv_builder_tracker.DefaultCellStyle.SelectionBackColor = Color.IndianRed;
            }
            else if (dgv_builder_tracker.Rows[dgv_builder_tracker.CurrentRow.Index].DefaultCellStyle.BackColor == Color.Green)
            {
                dgv_builder_tracker.DefaultCellStyle.SelectionBackColor = Color.SeaGreen;
            }
        }

        private void loadConditionLocations()
        {
            conditionLocations.Add("Gender", 0);
            conditionLocations.Add("Age", 1);
            conditionLocations.Add("Morphine Equivalent Dose", 2);
            conditionLocations.Add("Medication", 3);
        }

        private void TestQueryBuilder_Activated(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
        }

        private void dgv_builder_tracker_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Scrolling Locations
            if ((string)dgv_builder_tracker.Rows[dgv_builder_tracker.CurrentRow.Index].Cells[dgv_builder_tracker.CurrentCell.ColumnIndex].Value == "Gender")
            {
                panel_builder_controls.AutoScrollPosition = new Point(0, 0);
            }
            else if ((string)dgv_builder_tracker.Rows[dgv_builder_tracker.CurrentRow.Index].Cells[dgv_builder_tracker.CurrentCell.ColumnIndex].Value == "Age")
            {
                panel_builder_controls.AutoScrollPosition = new Point(0, 130);
            }
            else if ((string)dgv_builder_tracker.Rows[dgv_builder_tracker.CurrentRow.Index].Cells[dgv_builder_tracker.CurrentCell.ColumnIndex].Value == "Morphine Equivalent Dose")
            {
                panel_builder_controls.AutoScrollPosition = new Point(0, 260);
            }
            else if ((string)dgv_builder_tracker.Rows[dgv_builder_tracker.CurrentRow.Index].Cells[dgv_builder_tracker.CurrentCell.ColumnIndex].Value == "Medication")
            {
                panel_builder_controls.AutoScrollPosition = new Point(0, 390);
            }
            #endregion
        }
    }
}
