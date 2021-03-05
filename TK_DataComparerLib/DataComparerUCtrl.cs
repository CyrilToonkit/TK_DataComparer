using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using TK_DataComparerLib;
using MiniLogger;
using TK.BaseLib;

namespace TK_DataComparerLib
{

    public partial class DataComparerUCtrl : UserControl
    {
        public Color EqualsColor = Color.FromArgb(0x99, 0xF0, 0x95);
        public Color EqualsLightColor = Color.FromArgb(0xC7, 0xF3, 0xC5);
        public Color DifferColor = Color.FromArgb(0xF5, 0x9C, 0x9C);
        public Color DifferLightMandatoryColor = Color.FromArgb(0xFB, 0xD4, 0xD4);
        public Color DifferLightColor = Color.FromArgb(0xF7, 0xE1, 0xB0);
        public Color EmptyColor = Color.FromArgb(0xCF, 0xCF, 0xCF);
        public Color EmptyDontColor = Color.FromArgb(0xA1, 0xA1, 0xA1);

        ComparisonBoard _comp = new ComparisonBoard();
        ComparableData _left;
        ComparableData _right;

        bool _muteEvents = true;
        bool _isNotLoaded = true;

        bool _showEquals = true;
        DataEntity _currentEntity = null;
        List<DataEntity> _currentEntities = new List<DataEntity>();
        List<string> _currentProperties = new List<string>();

        public DataComparerUCtrl()
        {
            InitializeComponent();
            InitColors();

            logUCtrl1.Bind(Logger.GetInstance());
        }

        public DataComparerUCtrl(ComparableData inLeft, ComparableData inRight)
        {
            InitializeComponent();
            InitColors();

            logUCtrl1.Bind(Logger.GetInstance());

            InitCompare(inLeft, inRight);
        }

        private void InitColors()
        {
            ListViewItem item = new ListViewItem("Equals (summary)");
            item.BackColor = EqualsColor;
            colorsLV.Items.Add(item);

            item = new ListViewItem("Equals");
            item.BackColor = EqualsLightColor;
            colorsLV.Items.Add(item);

            item = new ListViewItem("Differ (summary)");
            item.BackColor = DifferColor;
            colorsLV.Items.Add(item);

            item = new ListViewItem("Differ");
            item.BackColor = DifferLightMandatoryColor;
            colorsLV.Items.Add(item);

            item = new ListViewItem("Differ (otpional)");
            item.BackColor = DifferLightColor;
            colorsLV.Items.Add(item);

            item = new ListViewItem("Empty");
            item.BackColor = EmptyColor;
            colorsLV.Items.Add(item);

            item = new ListViewItem("Empty (don't associate)");
            item.BackColor = EmptyDontColor;
            colorsLV.Items.Add(item);
        }

        public void InitCompare(ComparableData inLeft, ComparableData inRight)
        {
            _left = inLeft;
            leftTB.Text = _left.Name == "" ? "NOTHING LOADED" : _left.Name;
            _right = inRight;
            rightTB.Text = _right.Name == "" ? "NOTHING LOADED" : _right.Name;
            Compare();
        }

        public void Compare()
        {
            _left.CollectEntities();
            _right.CollectEntities();

            leftSummaryLabel.Text = string.Format("{0} entities", _left.Entities.Count);
            rightSummaryLabel.Text = string.Format("{0} entities", _right.Entities.Count);

            _comp.CreateComparison(_left, _right);

            RefreshGrid();
        }

        public void RefreshGrid()
        {
            _muteEvents = true;
            ComparisonsDGV.Rows.Clear();

            if (_left.Entities.Count == 0)
            {
                ComparisonsDGV.ColumnCount = 0;
                //MessageBox.Show("No \"Left\" entities to compare !");

                return;
            }
            else if (_left.Entities[0].Properties.Count == 0)
            {
                ComparisonsDGV.ColumnCount = 0;
                //MessageBox.Show("No \"Left\" properties to compare !");

                return;
            }

            if (_right.Entities.Count == 0)
            {
                ComparisonsDGV.ColumnCount = 0;
                MessageBox.Show("No \"Right\" entities to compare !");

                return;
            }
            else if (_right.Entities[0].Properties.Count == 0)
            {
                ComparisonsDGV.ColumnCount = 0;
                MessageBox.Show("No \"Right\" properties to compare !");

                return;
            }

            //Columns (properties)

            propertiesLV.Items.Clear();

            int propCount = _left.GetActivePropertiesCount();

            ComparisonsDGV.ColumnCount = propCount * 2 + 1;
            int counter = 0;
            foreach (EntityProperty prop in _left.Entities[0].Properties)
            {
                ListViewItem item = propertiesLV.Items.Add(prop.Name);
                if (prop.Active)
                {
                    item.Checked = true;

                    ComparisonsDGV.Columns[counter].Name = prop.Name + (prop.Transferable ? "*" : "");
                    ComparisonsDGV.Columns[counter + propCount + 1].Name = prop.Name + (prop.Transferable ? "*" : "");
                    counter++;
                }
            }

            ComparisonsDGV.Columns[propCount].Name = "SUMMARY";

            int nbItems = 0;
            int nbTotal = 0;
            int nbDiffer = 0;

            //Rows

            //"Left" first
            List<DataEntity> associatedEntities = new List<DataEntity>();
            foreach (DataEntity comparedEntity in _comp.Comparisons.Keys)
            {
                if(comparedEntity.Comparable == _left)
                {
                    nbTotal++;

                    object[] row = new object[propCount * 2 + 1];
                    comparedEntity.GetValues().CopyTo(row, 0);

                    Comparison rowComp = Comparison.LeftOnly;

                    if (comparedEntity.AssociatedEntity != null)
                    {
                        rowComp = Comparison.Differ;
                        associatedEntities.Add(comparedEntity.AssociatedEntity);
                        comparedEntity.AssociatedEntity.GetValues().CopyTo(row, propCount + 1);
                        rowComp = _comp.GetSummary(comparedEntity, comparedEntity.AssociatedEntity);
                    }

                    row[propCount] = rowComp;
                    if (rowComp != Comparison.Equals)
                    {
                        nbDiffer++;
                    }

                    if (_showEquals || rowComp != Comparison.Equals)
                    {
                        DataGridViewRow newRow = ComparisonsDGV.Rows[ComparisonsDGV.Rows.Add(row)];
                        nbItems++;

                        counter = 0;
                        foreach (EntityProperty prop in comparedEntity.Properties)
                        {
                            if (!prop.Active)
                                continue;

                            Comparison curComp = Comparison.Differ;

                            if (comparedEntity.AssociatedEntity != null)
                            {
                                if (_comp.Comparisons[comparedEntity][comparedEntity.AssociatedEntity][prop.Name] >= 1.0)
                                {
                                    curComp = Comparison.Equals;
                                }
                                newRow.Cells[counter].Style.BackColor = newRow.Cells[counter + propCount + 1].Style.BackColor = (curComp == Comparison.Equals ? EqualsLightColor : (prop.Mandatory ? DifferLightMandatoryColor : DifferLightColor));
                            }
                            else
                            {
                                newRow.Cells[counter + propCount + 1].Style.BackColor = comparedEntity.DontAssociate ? EmptyDontColor : EmptyColor;
                                newRow.Cells[counter].Style.BackColor = prop.Mandatory ? DifferLightMandatoryColor : DifferLightColor;
                            }
                            counter++;
                        }

                        newRow.Cells[propCount].Style.BackColor = (rowComp == Comparison.Equals ? EqualsColor : DifferColor);
                    }
                }
            }

            //"Right" orphan entities
            foreach (DataEntity comparedEntity in _comp.Comparisons.Keys)
            {
                if (comparedEntity.Comparable == _right && !associatedEntities.Contains(comparedEntity))
                {
                    nbTotal++;
                    nbDiffer++;

                    object[] row = new object[propCount * 2 + 1];
                    comparedEntity.GetValues().CopyTo(row, propCount + 1);
                    row[propCount] = Comparison.RightOnly;

                    DataGridViewRow newRow = ComparisonsDGV.Rows[ComparisonsDGV.Rows.Add(row)];
                    nbItems++;

                    counter = 0;
                    foreach (EntityProperty prop in comparedEntity.Properties)
                    {
                        if (!prop.Active)
                            continue;

                        newRow.Cells[counter].Style.BackColor = comparedEntity.DontAssociate ? EmptyDontColor : EmptyColor;
                        newRow.Cells[counter + propCount + 1].Style.BackColor = prop.Mandatory ? DifferLightMandatoryColor : DifferLightColor;
                        counter++;
                    }

                    newRow.Cells[propCount].Style.BackColor = DifferColor;
                }
            }

            toolStripStatusLabel1.Text = string.Format("{0} items / {1} items total ({2} Differ)", nbItems, nbTotal, nbDiffer);
            _muteEvents = false;
        }

        private void propertiesLV_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (_muteEvents || _isNotLoaded)
                return;

            Dictionary<string, bool> propertiesStatuses = new Dictionary<string, bool>();

            foreach (ListViewItem item in propertiesLV.Items)
            {
                if(!propertiesStatuses.ContainsKey(item.Text))
                    propertiesStatuses.Add(item.Text, item.Checked);
            }
            _comp.SetPropertiesActivation(propertiesStatuses);
            _comp.CreateComparison(_left, _right);

            RefreshGrid();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            _showEquals = showEqualsToolStripMenuItem.Checked;
            RefreshGrid();
        }

        private void highlightSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> selEntities = new List<string>();
            foreach(DataGridViewCell cell in ComparisonsDGV.SelectedCells)
            {
                string id = ComparisonsDGV.Rows[cell.RowIndex].Cells[0].Value.ToString() + "|" + (cell.ColumnIndex < _left.Entities[0].Properties.Count ? "0" : "1");
                if (!selEntities.Contains(id))
                {
                    selEntities.Add(id);
                }
            }

            bool highlighted = false;
            DataEntity entity = null;

            foreach (string selEntity in selEntities)
            {
                string[] splitId = selEntity.Split('|');
                entity = _comp.GetEntity(splitId[0], splitId[1] == "0");

                if (entity != null)
                {
                    if(!highlighted)
                    {
                        highlighted = true;
                        entity.BeginHighlight();
                    }
                    entity.Highlight();
                }
            }

            if (entity != null)
            {
                entity.EndHighlight();
            }
        }

        private void pickLeftBT_Click(object sender, EventArgs e)
        {
            if (_left.Pick())
            {
                leftTB.Text = _left.Name;
                Compare();
            }
        }

        private void pickRightBT_Click(object sender, EventArgs e)
        {
            if (_right.Pick())
            {
                rightTB.Text = _right.Name;
                Compare();
            }
        }

        private void pickBothBT_Click(object sender, EventArgs e)
        {
            List<string> sel = _left.PickBoth();

            if (sel.Count == 2)
            {
                _left.Name = leftTB.Text = sel[0];
                _right.Name = rightTB.Text = sel[1];

                Compare();
            }
        }

        private void refreshBT_Click(object sender, EventArgs e)
        {
            Compare();
        }

        public void Associate_OnClick(object sender, EventArgs e)
        {
            if (_currentEntity != null)
            {
                ToolStripItem item = sender as ToolStripItem;

                _comp.Associate(_currentEntity.Id, item.Text, _currentEntity.Comparable == _left);

                _currentEntity = null;
                RefreshGrid();
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentEntities != null && _currentEntities.Count > 0)
            {
                ToolStripItem item = sender as ToolStripItem;
                foreach (DataEntity entity in _currentEntities)
                {
                    entity.Copy(entity.Comparable == _left ? _right : _left);
                }
                
                Compare();
            }
            else if (_currentEntity != null)
            {
                ToolStripItem item = sender as ToolStripItem;

                _currentEntity.Copy(_currentEntity.Comparable == _left ? _right : _left);

                _currentEntity = null;
                Compare();
            }
        }

        public void DeAssociate_OnClick(object sender, EventArgs e)
        {
            if (_currentEntity != null)
            {
                ToolStripItem item = sender as ToolStripItem;

                _comp.DeAssociate(_currentEntity.Id, item.Text, _currentEntity.Comparable == _left);

                _currentEntity = null;
                RefreshGrid();
            }
        }

        public void Transfer_OnClick(object sender, EventArgs e)
        {
            List<string> properties = new List<string>();

            if (_currentEntities != null && _currentEntities.Count > 0)
            {
                ToolStripItem item = sender as ToolStripItem;
                
                if (item.Text.StartsWith("All sel"))
                {
                    string props = item.Text.Substring(item.Text.IndexOf("(") + 1);
                    props = props.Substring(0, props.Length - 1);

                    properties = new List<string>(props.Split(','));
                }
                else
                {
                    properties.Add(item.Text);
                }

                List<DataEntity> changedEntities = new List<DataEntity>();

                foreach (DataEntity entity in _currentEntities)
                {
                    if (entity.AssociatedEntity != null)
                    {
                        foreach (string currentProp in properties)
                        {
                            if (_comp.Comparisons[entity][entity.AssociatedEntity][currentProp] < 1.0)
                            {
                                if (transfer(entity, currentProp) && !changedEntities.Contains(entity.AssociatedEntity))
                                {
                                    changedEntities.Add(entity.AssociatedEntity);
                                }
                            }
                            else
                            {
                                Logger.Log(string.Format("No need to transfer \"{0}.{1}\" on \"{2}\" already equals", entity.Id, currentProp, entity.AssociatedEntity.Id), LogSeverities.Log);
                            }
                        }
                    }
                }

                if (changedEntities.Count > 0)
                {
                    foreach (DataEntity entity in changedEntities)
                    {
                        entity.CreateProperties();
                    }

                    _comp.Compare();
                    RefreshGrid();
                }
            }
            else if (_currentEntity != null)
            {
                ToolStripItem item = sender as ToolStripItem;
                bool changed = false;
                foreach (string currentProp in properties)
                {
                    if (transfer(_currentEntity, currentProp))
                    {
                        changed = true;
                    }
                }

                if (changed)
                {
                    _currentEntity.AssociatedEntity.CreateProperties();
                    _comp.Compare();
                    RefreshGrid();
                }

                _currentEntity = null;
            }
        }

        public bool transfer(DataEntity entity, string propertyName)
        {
            EntityProperty prop = entity.GetProperty(propertyName);

            if (prop != null)
            {
                if (!prop.Transfer(entity.AssociatedEntity))
                {
                    Logger.Log(string.Format("Can't transfer \"{0}.{1}\" on \"{2}\"", entity.Id, propertyName, entity.AssociatedEntity.Id), LogSeverities.Error);
                }
                else
                {
                    Logger.Log(string.Format("Transfer \"{0}.{1}\" on \"{2}\" successfull", entity.Id, propertyName, entity.AssociatedEntity.Id), LogSeverities.Info);
                    return true;
                }
            }
            else
            {
                Logger.Log(string.Format("Can't fin property \"{0}\" on \"{1}\"", propertyName, entity.Id), LogSeverities.Error);
            }

            return false;
        }

        public void TransferAll_OnClick(object sender, EventArgs e)
        {
            List<DataEntity> changedEntities = new List<DataEntity>();

            if (_currentEntities != null && _currentEntities.Count > 0)
            {
                foreach (DataEntity entity in _currentEntities)
                {
                    if (EntityTransferAll(entity))
                    {
                        changedEntities.Add(entity.AssociatedEntity);
                    }
                }
            }
            else if (_currentEntity != null)
            {
                if(EntityTransferAll(_currentEntity))
                {
                    changedEntities.Add(_currentEntity.AssociatedEntity);
                }

                _currentEntity = null;
            }

            if (changedEntities.Count > 0)
            {
                foreach (DataEntity entity in changedEntities)
                {
                    entity.CreateProperties();
                }

                _comp.Compare();
                RefreshGrid();
            }
        }

        private void refreshPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentEntities != null && _currentEntities.Count > 0)
            {
                ToolStripItem item = sender as ToolStripItem;
                foreach (DataEntity entity in _currentEntities)
                {
                    entity.CreateProperties();
                }

                _comp.Compare();
                RefreshGrid();
            }
        }

        private void confirmAssociationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentEntity != null)
            {
                _comp.Associate(_currentEntity, _currentEntity.AssociatedEntity);

                _currentEntity = null;
            }
        }

        private void dontAssociateToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (_currentEntity != null && _currentEntity.DontAssociate != dontAssociateToolStripMenuItem.Checked)
            {
                _currentEntity.DontAssociate = dontAssociateToolStripMenuItem.Checked;
                _comp.AssociateEntities();
                RefreshGrid();

                _currentEntity = null;
            }
        }

        private bool EntityTransferAll(DataEntity currentEntity)
        {
            if (currentEntity.AssociatedEntity == null)
            {
                return false;
            }

            Logger.Log(string.Format("EntityTransferAll : \"{0}\"", currentEntity.Id), LogSeverities.Log);

            string[] transferables = _comp.GetTransferables(currentEntity);

            if (transferables.Length > 0)
            {
                bool needRefresh = false;

                foreach (string transferable in transferables)
                {
                    if (_comp.Comparisons[currentEntity][currentEntity.AssociatedEntity][transferable] < 1.0)
                    {
                        EntityProperty prop = currentEntity.GetProperty(transferable);

                        if (prop != null)
                        {
                            if (!prop.Transfer(currentEntity.AssociatedEntity))
                            {
                                Logger.Log(string.Format("Can't transfer \"{0}.{1}\" on \"{2}\"", currentEntity.Id, transferable, currentEntity.AssociatedEntity.Id), LogSeverities.Error);
                            }
                            else
                            {
                                Logger.Log(string.Format("Transfer \"{0}.{1}\" on \"{2}\" successfull", currentEntity.Id, transferable, currentEntity.AssociatedEntity.Id), LogSeverities.Info);
                                needRefresh = true;
                            }
                        }
                        else
                        {
                            Logger.Log(string.Format("Can't find property \"{0}\" on \"{1}\"", transferable, currentEntity.Id), LogSeverities.Error);
                        }
                    }
                    else
                    {
                        Logger.Log(string.Format("No need to transfer \"{0}.{1}\" on \"{2}\" already equals", currentEntity.Id, transferable, currentEntity.AssociatedEntity.Id), LogSeverities.Log);
                    }
                }

                return needRefresh;
            }
            else
            {
                Logger.Log(string.Format("Nothing to transfer on \"{0}\"", currentEntity.Id), LogSeverities.Warning);
            }

            return false;
        }

        private void transferSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> managedProps = new List<string>();

            bool refresh = false;

            foreach(DataGridViewCell cell in ComparisonsDGV.SelectedCells)
            {
                bool left = cell.ColumnIndex < _left.Entities[0].Properties.Count;
                DataEntity entity = _comp.GetEntity((string)ComparisonsDGV.Rows[cell.RowIndex].Cells[left ? 0 : _left.Entities[0].Properties.Count + 1].Value, left);

                if (entity == null)
                {
                    continue;
                }

                string currentProperty = _left.Entities[0].Properties[left ? cell.ColumnIndex : (cell.ColumnIndex - 1 - _left.Entities[0].Properties.Count)].Name;

                if (managedProps.Contains(currentProperty + cell.RowIndex.ToString()))
                {
                    continue;
                }

                if (transfer(entity, currentProperty))
                {
                    refresh = true;
                }
            }

            if (refresh)
            {
                Compare();
            }
        }

        private void ComparisonsDGV_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                System.Windows.Forms.DataGridView.HitTestInfo hit = ComparisonsDGV.HitTest(e.X, e.Y);

                if (hit.Type ==  DataGridViewHitTestType.Cell && hit.ColumnIndex != _left.Entities[0].Properties.Count)
                {
                    DataGridViewCell cell = ComparisonsDGV.Rows[hit.RowIndex].Cells[hit.ColumnIndex];

                    associateWithToolStripMenuItem.DropDownItems.Clear();
                    removeAssociationWithToolStripMenuItem.DropDownItems.Clear();
                    transferToolStripMenuItem.DropDownItems.Clear();

                    bool left = hit.ColumnIndex < _left.Entities[0].Properties.Count;
                    _currentEntity = _comp.GetEntity((string)ComparisonsDGV.Rows[hit.RowIndex].Cells[left ? 0 : _left.Entities[0].Properties.Count + 1].Value, left);
                    if (_currentEntity == null)
                    {
                        return;
                    }

                    List<string> entitiesList = new List<string>();
                    _currentEntities = new List<DataEntity>() { _currentEntity };
                    string currentProperty = _left.Entities[0].Properties[left ? hit.ColumnIndex : (hit.ColumnIndex - 1 - _left.Entities[0].Properties.Count)].Name;
                    _currentProperties = new List<string>() { currentProperty };

                    entitiesList.Add((string)_currentEntity.Properties[0].Value);

                    foreach (DataGridViewCell curCell in ComparisonsDGV.SelectedCells)
                    {
                        if ((left && curCell.ColumnIndex < _left.Entities[0].Properties.Count) || (!left && curCell.ColumnIndex > _left.Entities[0].Properties.Count))
                        {
                            DataEntity entity = _comp.GetEntity((string)ComparisonsDGV.Rows[curCell.RowIndex].Cells[left ? 0 : _left.Entities[0].Properties.Count + 1].Value, left);
                            if (!_currentEntities.Contains(entity))
                            {
                                _currentEntities.Add(entity);
                                entitiesList.Add((string)entity.Properties[0].Value);
                            }
                            string propName = _left.Entities[0].Properties[left ? curCell.ColumnIndex : (curCell.ColumnIndex - 1 - _left.Entities[0].Properties.Count)].Name;
                            if (!_currentProperties.Contains(propName))
                            {
                                _currentProperties.Add(propName);
                            }
                        }
                    }

                    Logger.Log(TypesHelper.Join(entitiesList) + " " + TypesHelper.Join(_currentProperties), LogSeverities.Info);

                    string[] confirmedAssocs = _comp.GetConfirmedAssociations(_currentEntity.Id, left);
                    foreach (string assoc in confirmedAssocs)
                    {
                        removeAssociationWithToolStripMenuItem.DropDownItems.Add(assoc, null, new EventHandler(DeAssociate_OnClick));
                    }

                    string[] assocs = _comp.GetPossibleAssociations(_currentEntity.Id, left);

                    foreach (string assoc in assocs)
                    {
                        associateWithToolStripMenuItem.DropDownItems.Add(assoc, null, new EventHandler(Associate_OnClick));
                    }

                    dontAssociateToolStripMenuItem.Checked = _currentEntity.DontAssociate;

                    toolStripMenuItem1.Visible = false;
                    transferToolStripMenuItem.Visible = false;

                    DataEntity currentAssociatedEntity = _currentEntity.AssociatedEntity;

                    if (currentAssociatedEntity != null)
                    {
                        string[] transferables = _comp.GetTransferables(_currentEntity);

                        if (transferables.Length > 0)
                        {
                            bool canTransfer = false;

                            if (ArrayContains(transferables, currentProperty) && _comp.Comparisons[_currentEntity][currentAssociatedEntity][currentProperty] < 1.0)
                            {
                                transferToolStripMenuItem.DropDownItems.Add(currentProperty, null, new EventHandler(Transfer_OnClick));
                                transferToolStripMenuItem.DropDownItems.Add("-", null, null);
                                transferToolStripMenuItem.DropDownItems.Add("All sel. props ("+TypesHelper.Join(_currentProperties)+")", null, new EventHandler(Transfer_OnClick));
                                transferToolStripMenuItem.DropDownItems.Add("-", null, null);
                                transferToolStripMenuItem.DropDownItems.Add("All", null, new EventHandler(TransferAll_OnClick));

                                canTransfer = true;
                            }
                            else
                            {
                                foreach (string transferable in transferables)
                                {
                                    foreach (DataEntity currentEntity in _currentEntities)
                                    {
                                        if (_comp.Comparisons[currentEntity][currentEntity.AssociatedEntity][transferable] < 1.0)
                                        {
                                            transferToolStripMenuItem.DropDownItems.Add("All sel. props (" + TypesHelper.Join(_currentProperties) + ")", null, new EventHandler(Transfer_OnClick));
                                            transferToolStripMenuItem.DropDownItems.Add("-", null, null); 
                                            transferToolStripMenuItem.DropDownItems.Add("All", null, new EventHandler(TransferAll_OnClick));
                                            canTransfer = true;
                                            break;
                                        }
                                    }
                                    if (canTransfer)
                                    {
                                        break;
                                    }
                                }
                            }

                            if (canTransfer)
                            {
                                toolStripMenuItem1.Visible = true;
                                transferToolStripMenuItem.Visible = true;
                            }
                        }
                    }

                    comparisonCtxt.Show(ComparisonsDGV.PointToScreen(new Point(e.X, e.Y)));
                }
            }
        }

        private bool ArrayContains(string[] transferables, string currentProperty)
        {
            foreach (string transferable in transferables)
            {
                if (transferable == currentProperty)
                {
                    return true;
                }
            }

            return false;
        }

        private void transferAllBT_Click(object sender, EventArgs e)
        {
            bool needRefresh = false;

            foreach (DataEntity entity in _comp.Comparisons.Keys)
            {
                if (entity.Comparable == _left)
                {
                    if (EntityTransferAll(entity))
                    {
                        needRefresh = true;
                    }
                }
            }

            if (needRefresh)
            {
                Compare();
            }
        }

        private void saveMappingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _comp.SaveMappings(saveFileDialog1.FileName);
            }
        }

        private void loadMappingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _comp.LoadMappings(openFileDialog1.FileName);
                RefreshGrid();
            }
        }

        private void highlightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            highlightSelectionToolStripMenuItem_Click(sender, e);
        }

        private void DataComparerUCtrl_Load(object sender, EventArgs e)
        {
            _isNotLoaded = false;
        }

        private void fastCompareBT_CheckedChanged(object sender, EventArgs e)
        {
            _comp.FastCompare = fastCompareBT.Checked;
        }

        private void refreshCompareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _comp.Compare();
            _comp.AssociateEntities();
        }
    }
}
