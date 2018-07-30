using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ValuableCoins
{
    public interface IMainForm
    {
        void ExecuteDelegateOnUIThread(Delegate action);

        BackgroundWorker BgWorker { get; set; }

        Label LblAllCoinsCountValue   { get; set; }
        Label LblAllCoinsPriceValue   { get; set; }
        Label LblCollectionCountValue { get; set; }
        Label LblCollectionPriceValue { get; set; }

        Panel AllCoinsPanel   { get; set; }
        Panel CollectionPanel { get; set; }

        DataGridView  AllCoinsDgv             { get; set; }
        DataGridView  CollectionDgv           { get; set; }

        ProgressBar   ProgressBar1 { get; set; }

        // Button events
        event EventHandler UpdateInfo;
        event EventHandler AddCoinsToCollection;
        event EventHandler RemoveCoinsFromCollection;
        event EventHandler OpenCollectionMenu;
        event EventHandler OpenAllCoinsMenu;

        // DataGridView header events
        event DataGridViewCellMouseEventHandler ColumnHeaderMouseClick;

        // Form events
        event EventHandler MainFormActivated;
        event EventHandler MainFormClosing;
    }
    public partial class MainForm : Form, IMainForm
    {
        public MainForm()
        {
            InitializeComponent();
            
            // Events subscription
            allCoinsDgv.ColumnHeaderMouseClick += Dgv_ColumnHeaderMouseClick;
            collectionDgv.ColumnHeaderMouseClick += Dgv_ColumnHeaderMouseClick;

            btnUpdateInfo.Click            += BtnUpdateInfo_Click;
            btnOpenAllCoins.Click          += BtnOpenAllCoins_Click;
            btnAddToCollection.Click       += BtnAddToCollection_Click;
            btnRemoveFromCollection.Click  += BtnRemoveFromCollection_Click; 
            btnOpenCollection.Click        += BtnOpenCollection_Click;

            Activated += MainForm_Activated;
            FormClosing += MainForm_FormClosing;
        }

        #region EventMethods
        private void BtnOpenCollection_Click(object sender, EventArgs e)
        {
            OpenCollectionMenu.Invoke(sender, e);
        }

        private void BtnAddToCollection_Click(object sender, EventArgs e)
        {
            AddCoinsToCollection.Invoke(sender, e);
        }
        private void BtnRemoveFromCollection_Click(object sender, EventArgs e)
        {
            RemoveCoinsFromCollection.Invoke(sender, e);
        }
        private void BtnOpenAllCoins_Click(object sender, EventArgs e)
        {
            OpenAllCoinsMenu.Invoke(sender, e);
        }

        private void Dgv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ColumnHeaderMouseClick.Invoke(sender, e);
        }

        private void BtnUpdateInfo_Click(object sender, EventArgs e)
        {
            UpdateInfo.Invoke(sender, e);
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainFormClosing.Invoke(sender, e);
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            MainFormActivated.Invoke(sender, e);
        }
        #endregion

        #region IMainForm
        public void ExecuteDelegateOnUIThread(Delegate action)
        {
            this.Invoke(action);
        }

        public BackgroundWorker BgWorker 
        {
            get => backgroundWorker1;
            set => backgroundWorker1 = value;
        }

        public Label LblAllCoinsCountValue 
        {
            get => lblAllCoinsCountValue;
            set => lblAllCoinsCountValue = value;
        }
        public Label LblAllCoinsPriceValue 
        {
            get => lblAllCoinsPriceValue;
            set => lblAllCoinsPriceValue = value;
        }
        public Label LblCollectionCountValue {
            get => lblCollectionCountValue;
            set => lblCollectionCountValue = value;
        }
        public Label LblCollectionPriceValue {
            get => lblCollectionPriceValue;
            set => lblCollectionPriceValue = value;
        }

        public Panel AllCoinsPanel 
        {
            get => allCoinsPanel;
            set => allCoinsPanel = value;
        }
        public Panel CollectionPanel {
            get => collectionPanel;
            set => collectionPanel = value;
        }
        public DataGridView AllCoinsDgv 
        {
            get => allCoinsDgv;
            set => allCoinsDgv = value;
        }
        public DataGridView CollectionDgv {
            get => collectionDgv;
            set => collectionDgv = value;
        }

        public ProgressBar ProgressBar1 {
            get => progressBar1;
            set => progressBar1 = value;
        }
        public event EventHandler UpdateInfo;
        public event DataGridViewCellMouseEventHandler ColumnHeaderMouseClick;
        public event EventHandler AddCoinsToCollection;
        public event EventHandler RemoveCoinsFromCollection;
        public event EventHandler OpenCollectionMenu;
        public event EventHandler OpenAllCoinsMenu;
        public event EventHandler MainFormActivated;
        public event EventHandler MainFormClosing;
        #endregion
    }
}