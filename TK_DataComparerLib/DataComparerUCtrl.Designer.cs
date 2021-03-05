using System.Windows.Forms;
namespace TK_DataComparerLib
{
    partial class DataComparerUCtrl : UserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataComparerUCtrl));
            MiniLogger.LogPreferences logPreferences1 = new MiniLogger.LogPreferences();
            this.ComparisonsDGV = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.showEqualsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.highlightSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.transferSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transferAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveMappingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadMappingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.comparisonCtxt = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.associateWithToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAssociationWithToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.confirmAssociationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dontAssociateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.transferToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.highlightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshPropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.refreshCompareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.collapsibleGroup1 = new TK.GraphComponents.CollapsibleGroup();
            this.colorsLV = new System.Windows.Forms.ListView();
            this.collapsibleGroup3 = new TK.GraphComponents.CollapsibleGroup();
            this.logUCtrl1 = new MiniLogger.LogUCtrl();
            this.collapsibleGroup4 = new TK.GraphComponents.CollapsibleGroup();
            this.propertiesLV = new System.Windows.Forms.ListView();
            this.fastCompareBT = new System.Windows.Forms.CheckBox();
            this.collapsibleGroup2 = new TK.GraphComponents.CollapsibleGroup();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pickRightBT = new System.Windows.Forms.Button();
            this.rightSummaryLabel = new System.Windows.Forms.Label();
            this.leftTB = new System.Windows.Forms.TextBox();
            this.pickLeftBT = new System.Windows.Forms.Button();
            this.rightTB = new System.Windows.Forms.TextBox();
            this.leftSummaryLabel = new System.Windows.Forms.Label();
            this.pickBothBT = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ComparisonsDGV)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.comparisonCtxt.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.collapsibleGroup1.SuspendLayout();
            this.collapsibleGroup3.SuspendLayout();
            this.collapsibleGroup4.SuspendLayout();
            this.collapsibleGroup2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ComparisonsDGV
            // 
            this.ComparisonsDGV.AllowUserToAddRows = false;
            this.ComparisonsDGV.AllowUserToDeleteRows = false;
            this.ComparisonsDGV.AllowUserToResizeRows = false;
            this.ComparisonsDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ComparisonsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ComparisonsDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComparisonsDGV.Location = new System.Drawing.Point(3, 16);
            this.ComparisonsDGV.Name = "ComparisonsDGV";
            this.ComparisonsDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.ComparisonsDGV.Size = new System.Drawing.Size(529, 194);
            this.ComparisonsDGV.TabIndex = 0;
            this.ComparisonsDGV.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ComparisonsDGV_MouseUp);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripSplitButton1});
            this.statusStrip1.Location = new System.Drawing.Point(3, 210);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(529, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(420, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "n items / N items total (i Differ)";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showEqualsToolStripMenuItem,
            this.toolStripMenuItem3,
            this.highlightSelectionToolStripMenuItem,
            this.toolStripMenuItem6,
            this.transferSelectedToolStripMenuItem,
            this.transferAllToolStripMenuItem,
            this.toolStripMenuItem2,
            this.saveMappingToolStripMenuItem,
            this.loadMappingToolStripMenuItem,
            this.toolStripMenuItem5,
            this.refreshToolStripMenuItem,
            this.refreshCompareToolStripMenuItem});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(63, 20);
            this.toolStripSplitButton1.Text = "Actions";
            // 
            // showEqualsToolStripMenuItem
            // 
            this.showEqualsToolStripMenuItem.Checked = true;
            this.showEqualsToolStripMenuItem.CheckOnClick = true;
            this.showEqualsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showEqualsToolStripMenuItem.Name = "showEqualsToolStripMenuItem";
            this.showEqualsToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.showEqualsToolStripMenuItem.Text = "Show \"Equals\"";
            this.showEqualsToolStripMenuItem.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(205, 6);
            // 
            // highlightSelectionToolStripMenuItem
            // 
            this.highlightSelectionToolStripMenuItem.Name = "highlightSelectionToolStripMenuItem";
            this.highlightSelectionToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.highlightSelectionToolStripMenuItem.Text = "Highlight selection";
            this.highlightSelectionToolStripMenuItem.Click += new System.EventHandler(this.highlightSelectionToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(205, 6);
            // 
            // transferSelectedToolStripMenuItem
            // 
            this.transferSelectedToolStripMenuItem.Name = "transferSelectedToolStripMenuItem";
            this.transferSelectedToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.transferSelectedToolStripMenuItem.Text = "Transfer selected";
            this.transferSelectedToolStripMenuItem.Click += new System.EventHandler(this.transferSelectedToolStripMenuItem_Click);
            // 
            // transferAllToolStripMenuItem
            // 
            this.transferAllToolStripMenuItem.Name = "transferAllToolStripMenuItem";
            this.transferAllToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.transferAllToolStripMenuItem.Text = "Transfer all (Left to Right)";
            this.transferAllToolStripMenuItem.Click += new System.EventHandler(this.transferAllBT_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(205, 6);
            // 
            // saveMappingToolStripMenuItem
            // 
            this.saveMappingToolStripMenuItem.Name = "saveMappingToolStripMenuItem";
            this.saveMappingToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.saveMappingToolStripMenuItem.Text = "Save mapping...";
            this.saveMappingToolStripMenuItem.Click += new System.EventHandler(this.saveMappingToolStripMenuItem_Click);
            // 
            // loadMappingToolStripMenuItem
            // 
            this.loadMappingToolStripMenuItem.Name = "loadMappingToolStripMenuItem";
            this.loadMappingToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.loadMappingToolStripMenuItem.Text = "Load mapping...";
            this.loadMappingToolStripMenuItem.Click += new System.EventHandler(this.loadMappingToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(205, 6);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshBT_Click);
            // 
            // comparisonCtxt
            // 
            this.comparisonCtxt.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.associateWithToolStripMenuItem,
            this.removeAssociationWithToolStripMenuItem,
            this.toolStripMenuItem4,
            this.confirmAssociationToolStripMenuItem,
            this.dontAssociateToolStripMenuItem,
            this.toolStripMenuItem1,
            this.transferToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.toolStripMenuItem7,
            this.highlightToolStripMenuItem,
            this.toolStripMenuItem8,
            this.refreshPropertiesToolStripMenuItem});
            this.comparisonCtxt.Name = "comparisonCtxt";
            this.comparisonCtxt.Size = new System.Drawing.Size(206, 204);
            // 
            // associateWithToolStripMenuItem
            // 
            this.associateWithToolStripMenuItem.Name = "associateWithToolStripMenuItem";
            this.associateWithToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.associateWithToolStripMenuItem.Text = "Associate with";
            // 
            // removeAssociationWithToolStripMenuItem
            // 
            this.removeAssociationWithToolStripMenuItem.Name = "removeAssociationWithToolStripMenuItem";
            this.removeAssociationWithToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.removeAssociationWithToolStripMenuItem.Text = "Remove association with";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(202, 6);
            // 
            // confirmAssociationToolStripMenuItem
            // 
            this.confirmAssociationToolStripMenuItem.Name = "confirmAssociationToolStripMenuItem";
            this.confirmAssociationToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.confirmAssociationToolStripMenuItem.Text = "Confirm association";
            this.confirmAssociationToolStripMenuItem.Click += new System.EventHandler(this.confirmAssociationToolStripMenuItem_Click);
            // 
            // dontAssociateToolStripMenuItem
            // 
            this.dontAssociateToolStripMenuItem.CheckOnClick = true;
            this.dontAssociateToolStripMenuItem.Name = "dontAssociateToolStripMenuItem";
            this.dontAssociateToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.dontAssociateToolStripMenuItem.Text = "Don\'t associate";
            this.dontAssociateToolStripMenuItem.CheckedChanged += new System.EventHandler(this.dontAssociateToolStripMenuItem_CheckedChanged);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(202, 6);
            // 
            // transferToolStripMenuItem
            // 
            this.transferToolStripMenuItem.Name = "transferToolStripMenuItem";
            this.transferToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.transferToolStripMenuItem.Text = "Transfer";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(202, 6);
            // 
            // highlightToolStripMenuItem
            // 
            this.highlightToolStripMenuItem.Name = "highlightToolStripMenuItem";
            this.highlightToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.highlightToolStripMenuItem.Text = "Highlight";
            this.highlightToolStripMenuItem.Click += new System.EventHandler(this.highlightToolStripMenuItem_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(202, 6);
            // 
            // refreshPropertiesToolStripMenuItem
            // 
            this.refreshPropertiesToolStripMenuItem.Name = "refreshPropertiesToolStripMenuItem";
            this.refreshPropertiesToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.refreshPropertiesToolStripMenuItem.Text = "Refresh properties";
            this.refreshPropertiesToolStripMenuItem.Click += new System.EventHandler(this.refreshPropertiesToolStripMenuItem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ComparisonsDGV);
            this.groupBox2.Controls.Add(this.statusStrip1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 197);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(535, 235);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Compared entities";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Xml (*.xml)|*.xml";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Xml (*.xml)|*.xml";
            // 
            // refreshCompareToolStripMenuItem
            // 
            this.refreshCompareToolStripMenuItem.Name = "refreshCompareToolStripMenuItem";
            this.refreshCompareToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.refreshCompareToolStripMenuItem.Text = "RefreshCompare";
            this.refreshCompareToolStripMenuItem.Click += new System.EventHandler(this.refreshCompareToolStripMenuItem_Click);
            // 
            // collapsibleGroup1
            // 
            this.collapsibleGroup1.AllowResize = false;
            this.collapsibleGroup1.Collapsed = true;
            this.collapsibleGroup1.CollapseOnClick = true;
            this.collapsibleGroup1.Controls.Add(this.colorsLV);
            this.collapsibleGroup1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.collapsibleGroup1.DockingChanges = TK.GraphComponents.DockingPossibilities.All;
            this.collapsibleGroup1.Location = new System.Drawing.Point(0, 432);
            this.collapsibleGroup1.Name = "collapsibleGroup1";
            this.collapsibleGroup1.OpenedBaseHeight = 65;
            this.collapsibleGroup1.OpenedBaseWidth = 200;
            this.collapsibleGroup1.Size = new System.Drawing.Size(535, 33);
            this.collapsibleGroup1.TabIndex = 5;
            this.collapsibleGroup1.TabStop = false;
            this.collapsibleGroup1.Text = "Colors";
            // 
            // colorsLV
            // 
            this.colorsLV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorsLV.Location = new System.Drawing.Point(3, 16);
            this.colorsLV.Name = "colorsLV";
            this.colorsLV.Size = new System.Drawing.Size(529, 14);
            this.colorsLV.TabIndex = 1;
            this.colorsLV.UseCompatibleStateImageBehavior = false;
            // 
            // collapsibleGroup3
            // 
            this.collapsibleGroup3.AllowResize = true;
            this.collapsibleGroup3.Collapsed = true;
            this.collapsibleGroup3.CollapseOnClick = true;
            this.collapsibleGroup3.Controls.Add(this.logUCtrl1);
            this.collapsibleGroup3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.collapsibleGroup3.DockingChanges = TK.GraphComponents.DockingPossibilities.All;
            this.collapsibleGroup3.Location = new System.Drawing.Point(0, 465);
            this.collapsibleGroup3.Name = "collapsibleGroup3";
            this.collapsibleGroup3.OpenedBaseHeight = 59;
            this.collapsibleGroup3.OpenedBaseWidth = 200;
            this.collapsibleGroup3.Size = new System.Drawing.Size(535, 25);
            this.collapsibleGroup3.TabIndex = 7;
            this.collapsibleGroup3.TabStop = false;
            this.collapsibleGroup3.Text = "Log";
            // 
            // logUCtrl1
            // 
            this.logUCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logUCtrl1.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logUCtrl1.Location = new System.Drawing.Point(3, 16);
            logPreferences1.ShowErrors = true;
            logPreferences1.ShowInfos = true;
            logPreferences1.ShowLogs = true;
            logPreferences1.ShowWarnings = true;
            this.logUCtrl1.LoggingPreferences = logPreferences1;
            this.logUCtrl1.Name = "logUCtrl1";
            this.logUCtrl1.Size = new System.Drawing.Size(529, 6);
            this.logUCtrl1.TabIndex = 1;
            // 
            // collapsibleGroup4
            // 
            this.collapsibleGroup4.AllowResize = true;
            this.collapsibleGroup4.Collapsed = false;
            this.collapsibleGroup4.CollapseOnClick = true;
            this.collapsibleGroup4.Controls.Add(this.propertiesLV);
            this.collapsibleGroup4.Controls.Add(this.fastCompareBT);
            this.collapsibleGroup4.Dock = System.Windows.Forms.DockStyle.Top;
            this.collapsibleGroup4.DockingChanges = TK.GraphComponents.DockingPossibilities.All;
            this.collapsibleGroup4.Location = new System.Drawing.Point(0, 117);
            this.collapsibleGroup4.Name = "collapsibleGroup4";
            this.collapsibleGroup4.OpenedBaseHeight = 150;
            this.collapsibleGroup4.OpenedBaseWidth = 200;
            this.collapsibleGroup4.Size = new System.Drawing.Size(535, 80);
            this.collapsibleGroup4.TabIndex = 9;
            this.collapsibleGroup4.TabStop = false;
            this.collapsibleGroup4.Text = "Properties";
            // 
            // propertiesLV
            // 
            this.propertiesLV.CheckBoxes = true;
            this.propertiesLV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertiesLV.Location = new System.Drawing.Point(3, 16);
            this.propertiesLV.Name = "propertiesLV";
            this.propertiesLV.Size = new System.Drawing.Size(529, 44);
            this.propertiesLV.TabIndex = 1;
            this.propertiesLV.UseCompatibleStateImageBehavior = false;
            this.propertiesLV.View = System.Windows.Forms.View.List;
            this.propertiesLV.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.propertiesLV_ItemChecked);
            // 
            // fastCompareBT
            // 
            this.fastCompareBT.AutoSize = true;
            this.fastCompareBT.Checked = true;
            this.fastCompareBT.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fastCompareBT.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.fastCompareBT.ForeColor = System.Drawing.Color.Gainsboro;
            this.fastCompareBT.Location = new System.Drawing.Point(3, 60);
            this.fastCompareBT.Name = "fastCompareBT";
            this.fastCompareBT.Size = new System.Drawing.Size(529, 17);
            this.fastCompareBT.TabIndex = 2;
            this.fastCompareBT.Text = "Fast compare";
            this.fastCompareBT.UseVisualStyleBackColor = true;
            this.fastCompareBT.CheckedChanged += new System.EventHandler(this.fastCompareBT_CheckedChanged);
            // 
            // collapsibleGroup2
            // 
            this.collapsibleGroup2.AllowResize = false;
            this.collapsibleGroup2.Collapsed = false;
            this.collapsibleGroup2.CollapseOnClick = true;
            this.collapsibleGroup2.Controls.Add(this.tableLayoutPanel1);
            this.collapsibleGroup2.Controls.Add(this.pickBothBT);
            this.collapsibleGroup2.Dock = System.Windows.Forms.DockStyle.Top;
            this.collapsibleGroup2.DockingChanges = TK.GraphComponents.DockingPossibilities.None;
            this.collapsibleGroup2.Location = new System.Drawing.Point(0, 0);
            this.collapsibleGroup2.Name = "collapsibleGroup2";
            this.collapsibleGroup2.OpenedBaseHeight = 150;
            this.collapsibleGroup2.OpenedBaseWidth = 200;
            this.collapsibleGroup2.Size = new System.Drawing.Size(535, 117);
            this.collapsibleGroup2.TabIndex = 6;
            this.collapsibleGroup2.TabStop = false;
            this.collapsibleGroup2.Text = "Pick Objects";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.pickRightBT, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.rightSummaryLabel, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.leftTB, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pickLeftBT, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rightTB, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.leftSummaryLabel, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 39);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(529, 75);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pickRightBT
            // 
            this.pickRightBT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pickRightBT.Location = new System.Drawing.Point(265, 1);
            this.pickRightBT.Margin = new System.Windows.Forms.Padding(1);
            this.pickRightBT.Name = "pickRightBT";
            this.pickRightBT.Size = new System.Drawing.Size(263, 27);
            this.pickRightBT.TabIndex = 5;
            this.pickRightBT.Text = "Pick Right";
            this.pickRightBT.UseVisualStyleBackColor = true;
            this.pickRightBT.Click += new System.EventHandler(this.pickRightBT_Click);
            // 
            // rightSummaryLabel
            // 
            this.rightSummaryLabel.AutoSize = true;
            this.rightSummaryLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightSummaryLabel.Location = new System.Drawing.Point(267, 58);
            this.rightSummaryLabel.Name = "rightSummaryLabel";
            this.rightSummaryLabel.Size = new System.Drawing.Size(259, 17);
            this.rightSummaryLabel.TabIndex = 9;
            this.rightSummaryLabel.Text = "0 items";
            // 
            // leftTB
            // 
            this.leftTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftTB.Location = new System.Drawing.Point(3, 32);
            this.leftTB.Name = "leftTB";
            this.leftTB.ReadOnly = true;
            this.leftTB.Size = new System.Drawing.Size(258, 20);
            this.leftTB.TabIndex = 7;
            this.leftTB.Text = "NOTHING LOADED";
            // 
            // pickLeftBT
            // 
            this.pickLeftBT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pickLeftBT.Location = new System.Drawing.Point(1, 1);
            this.pickLeftBT.Margin = new System.Windows.Forms.Padding(1);
            this.pickLeftBT.Name = "pickLeftBT";
            this.pickLeftBT.Size = new System.Drawing.Size(262, 27);
            this.pickLeftBT.TabIndex = 4;
            this.pickLeftBT.Text = "Pick Left";
            this.pickLeftBT.UseVisualStyleBackColor = true;
            this.pickLeftBT.Click += new System.EventHandler(this.pickLeftBT_Click);
            // 
            // rightTB
            // 
            this.rightTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightTB.Location = new System.Drawing.Point(267, 32);
            this.rightTB.Name = "rightTB";
            this.rightTB.ReadOnly = true;
            this.rightTB.Size = new System.Drawing.Size(259, 20);
            this.rightTB.TabIndex = 6;
            this.rightTB.Text = "NOTHING LOADED";
            // 
            // leftSummaryLabel
            // 
            this.leftSummaryLabel.AutoSize = true;
            this.leftSummaryLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftSummaryLabel.Location = new System.Drawing.Point(3, 58);
            this.leftSummaryLabel.Name = "leftSummaryLabel";
            this.leftSummaryLabel.Size = new System.Drawing.Size(258, 17);
            this.leftSummaryLabel.TabIndex = 8;
            this.leftSummaryLabel.Text = "0 items";
            // 
            // pickBothBT
            // 
            this.pickBothBT.Dock = System.Windows.Forms.DockStyle.Top;
            this.pickBothBT.Location = new System.Drawing.Point(3, 16);
            this.pickBothBT.Name = "pickBothBT";
            this.pickBothBT.Size = new System.Drawing.Size(529, 23);
            this.pickBothBT.TabIndex = 1;
            this.pickBothBT.Text = "PICK BOTH";
            this.pickBothBT.UseVisualStyleBackColor = true;
            this.pickBothBT.Click += new System.EventHandler(this.pickBothBT_Click);
            // 
            // DataComparerUCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.collapsibleGroup1);
            this.Controls.Add(this.collapsibleGroup3);
            this.Controls.Add(this.collapsibleGroup4);
            this.Controls.Add(this.collapsibleGroup2);
            this.Name = "DataComparerUCtrl";
            this.Size = new System.Drawing.Size(535, 490);
            this.Load += new System.EventHandler(this.DataComparerUCtrl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ComparisonsDGV)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.comparisonCtxt.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.collapsibleGroup1.ResumeLayout(false);
            this.collapsibleGroup3.ResumeLayout(false);
            this.collapsibleGroup4.ResumeLayout(false);
            this.collapsibleGroup4.PerformLayout();
            this.collapsibleGroup2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ComparisonsDGV;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox leftTB;
        private System.Windows.Forms.Button pickLeftBT;
        private System.Windows.Forms.Button pickRightBT;
        private System.Windows.Forms.TextBox rightTB;
        private System.Windows.Forms.Label rightSummaryLabel;
        private System.Windows.Forms.Label leftSummaryLabel;
        private TK.GraphComponents.CollapsibleGroup collapsibleGroup1;
        private System.Windows.Forms.ListView colorsLV;
        private TK.GraphComponents.CollapsibleGroup collapsibleGroup2;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ContextMenuStrip comparisonCtxt;
        private System.Windows.Forms.ToolStripMenuItem associateWithToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeAssociationWithToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem transferToolStripMenuItem;
        private TK.GraphComponents.CollapsibleGroup collapsibleGroup3;
        private MiniLogger.LogUCtrl logUCtrl1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem showEqualsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem transferAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem highlightSelectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem confirmAssociationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dontAssociateToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem loadMappingToolStripMenuItem;
        private ToolStripMenuItem saveMappingToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem5;
        private SaveFileDialog saveFileDialog1;
        private OpenFileDialog openFileDialog1;
        private ToolStripSeparator toolStripMenuItem6;
        private ToolStripMenuItem transferSelectedToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem7;
        private ToolStripMenuItem highlightToolStripMenuItem;
        private TK.GraphComponents.CollapsibleGroup collapsibleGroup4;
        private ListView propertiesLV;
        private ToolStripSeparator toolStripMenuItem8;
        private ToolStripMenuItem refreshPropertiesToolStripMenuItem;
        private Button pickBothBT;
        private CheckBox fastCompareBT;
        private ToolStripMenuItem refreshCompareToolStripMenuItem;
    }
}
