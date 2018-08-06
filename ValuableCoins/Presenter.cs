using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq.Dynamic;
using System.ComponentModel;

namespace ValuableCoins
{
    class Presenter
    {
        private readonly IMainForm _view;

        private const string _tableUrl = "https://bank.gov.ua/control/uk/currentmoney/cmcoin/list";
        private const string _collectionFileName = "collection.txt";

        private List<Coin> _allCoinsList = new List<Coin>();
        public  List<Coin> AllCoinsList 
        {
            get => _allCoinsList;
            set 
            {
                _allCoinsList = value;
                OnPropertyChanged("AllCoinsList");
            }
        }
        private List<Coin> _collectionList = new List<Coin>();
        public  List<Coin> CollectionList {
            get => _collectionList;
            set 
            {
                _collectionList = value;
                OnPropertyChanged("CollectionList");
            }
        }

        private ListSortDirection _listSortDirection = ListSortDirection.Ascending;


        public Presenter(IMainForm view)
        {
            _view = view;

            // To make dgv not lag when they are scrolling
            _view.AllCoinsDgv.DoubleBuffered(true);
            _view.CollectionDgv.DoubleBuffered(true);

            _view.UpdateInfo                += _view_UpdateInfo;
            _view.AddCoinsToCollection      += _view_AddCoinsToCollection;
            _view.RemoveCoinsFromCollection += _view_RemoveCoinsFromCollection;
            _view.OpenAllCoinsMenu          += _view_OpenAllCoinsMenu;
            _view.OpenCollectionMenu        += _view_OpenCollectionMenu;

            _view.ColumnHeaderMouseClick += _view_ColumnHeaderMouseClick;

            _view.MainFormActivated += _view_MainFormActivated;
            _view.MainFormClosing   += _view_MainFormClosing;

            _view.AllCoinsDgv.DataSource   = AllCoinsList;
            _view.CollectionDgv.DataSource = CollectionList;
        } 

        // <---------- Event Methods ---------->
        private void OnPropertyChanged(string propertyName)
        {
            switch (propertyName)
            {
                case "AllCoinsList":
                    _view.ExecuteDelegateOnUIThread( new Action( 
                        () => 
                        {
                            _view.AllCoinsDgv.DataSource = typeof(List<Coin>);
                            _view.AllCoinsDgv.DataSource = AllCoinsList;
                            SetAllCoinsColorGreen();

                            if (AllCoinsList != null)
                            {
                                _view.LblAllCoinsPriceValue.Text = CalcSumOfPrices(AllCoinsList).ToString();
                                _view.LblAllCoinsCountValue.Text = AllCoinsList.Count.ToString();
                            }
                        }
                    ));
                    break;
                case "CollectionList":
                    _view.ExecuteDelegateOnUIThread( new Action( 
                        () => 
                        {
                            _view.CollectionDgv.DataSource = typeof(List<Coin>);
                            _view.CollectionDgv.DataSource = CollectionList;
                            SetAllCoinsColorGreen();


                            if (CollectionList != null)
                            {
                                FileManager fileManager = new FileManager(_collectionFileName);
                                fileManager.Save(CollectionList);

                                _view.LblCollectionPriceValue.Text = CalcSumOfPrices(CollectionList).ToString();
                                _view.LblCollectionCountValue.Text = CollectionList.Count.ToString();
                            }
                        }
                    ));
                    break;
                default:break;
            }
            
        }
        private void _view_MainFormClosing(object sender, EventArgs e)
        {
            FileManager fileManager = new FileManager(_collectionFileName);

            fileManager.Save(CollectionList);
        }

        private void _view_MainFormActivated(object sender, EventArgs e)
        {
            FileManager fileManager = new FileManager(_collectionFileName);

            CollectionList = (List<Coin>)fileManager.Load();

            if(CollectionList == null)
            {
                CollectionList = new List<Coin>();
            }

            if (CollectionList != null)
            {
                int sumPrice = 0;
                foreach (var coin in CollectionList)
                {
                    sumPrice += coin.Price;
                }
            }
        }

        private void _view_OpenCollectionMenu(object sender, EventArgs e)
        {
            _view.CollectionPanel.Show();
            _view.AllCoinsPanel.Hide();
        }

        private void _view_OpenAllCoinsMenu(object sender, EventArgs e)
        {
            _view.AllCoinsPanel.Show();
            _view.CollectionPanel.Hide();
        }

        private void _view_AddCoinsToCollection(object sender, EventArgs e)
        {
            var dgvSelectedRows = _view.AllCoinsDgv.SelectedRows;

            var collectionList = CollectionList.Select(coin => new Coin(coin)).ToList();
            for (int i = 0; i < dgvSelectedRows.Count; i++)
            {
                int index = dgvSelectedRows[i].Index;

                dgvSelectedRows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Green;
                dgvSelectedRows[i].Selected = false;

                Coin coin = AllCoinsList[index];
                collectionList.Add(coin);
            }
            CollectionList = collectionList;
        }

        private void _view_RemoveCoinsFromCollection(object sender, EventArgs e)
        {
            var dgvSelectedRows = _view.CollectionDgv.SelectedRows;

            var collectionList = CollectionList.Select(coin => new Coin(coin)).ToList();

            for (int i = 0; i < dgvSelectedRows.Count; i++)
            {
                collectionList.RemoveAt(dgvSelectedRows[i].Index);
            }
            CollectionList = collectionList;
        }

        private void _view_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var dataGridView = (DataGridView)sender;
            string propertyName = dataGridView.Columns[e.ColumnIndex].DataPropertyName;

            var coins = (List<Coin>)dataGridView.DataSource;
            SetAllCoinsColorWhite();

            switch (propertyName)
                {
                    case "Name":
                        if (_listSortDirection == ListSortDirection.Ascending)
                        {
                            coins = coins.OrderBy(p => p.Name).ToList();
                            _listSortDirection = ListSortDirection.Descending;
                        }
                        else
                        {
                            coins = coins.OrderByDescending(p => p.Name).ToList();
                            _listSortDirection = ListSortDirection.Ascending;
                        }
                        break;
                    case "Metal":
                        if (_listSortDirection == ListSortDirection.Ascending)
                        {
                            coins = coins.OrderBy(p => p.Metal).ToList();
                            _listSortDirection = ListSortDirection.Descending;
                        }
                        else
                        {
                            coins = coins.OrderByDescending(p => p.Metal).ToList();
                            _listSortDirection = ListSortDirection.Ascending;
                        }
                        break;
                    case "Par":
                        if (_listSortDirection == ListSortDirection.Ascending)
                        {
                            coins = coins.OrderBy(p => p.Par).ToList();
                            _listSortDirection = ListSortDirection.Descending;
                        }
                        else
                        {
                            coins = coins.OrderByDescending(p => p.Par).ToList();
                            _listSortDirection = ListSortDirection.Ascending;
                        }
                        break;
                    case "Price":
                        if (_listSortDirection == ListSortDirection.Ascending)
                        {
                            coins = coins.OrderBy(p => p.Price).ToList();
                            _listSortDirection = ListSortDirection.Descending;
                        }
                        else
                        {
                            coins = coins.OrderByDescending(p => p.Price).ToList();
                            _listSortDirection = ListSortDirection.Ascending;
                        }
                        break;
                    case "Date":
                        if (_listSortDirection == ListSortDirection.Ascending)
                        {
                            coins = coins.OrderBy(p => p.Date).ToList();
                            _listSortDirection = ListSortDirection.Descending;
                        }
                        else
                        {
                            coins = coins.OrderByDescending(p => p.Date).ToList();
                            _listSortDirection = ListSortDirection.Ascending;
                        }
                        break;
                    default: break;
                }
            switch (((DataGridView)sender).Name)
            {
                case "allCoinsDgv":
                    AllCoinsList = coins;
                    break;
                case "collectionDgv":
                    CollectionList = coins;
                    break;
                default:break;
            }

            SetAllCoinsColorGreen();
        }

        private void _view_UpdateInfo(object sender, EventArgs e)
        {
            UpdateInfo();
        }

        #region Helpful Methods
        // <---------- Update Info ---------->
        private async void UpdateInfo()
        {
            // Get info and make progressBar change it style to show that program is working
            _view.ProgressBar1.Style = ProgressBarStyle.Marquee;
            
            AllCoinsList = await GetCoinList();
            // Print info in dataGridView

            _view.ProgressBar1.Style = ProgressBarStyle.Blocks;
        }

        private void SetAllCoinsColorWhite()
        {
            for(int i = 0; i < AllCoinsList.Count;i++)
            {
                _view.AllCoinsDgv.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.White;
            }
        }
        private void SetAllCoinsColorGreen()
        {
            if (CollectionList != null)
            {
                foreach (var row in CollectionList)
                {
                    if (AllCoinsList.Any(c => c.Id == row.Id))
                    {
                        int index = 0;
                        for(int i = 0;i < _view.AllCoinsDgv.RowCount; i++)
                        {
                            if(((List<Coin>)(_view.AllCoinsDgv.DataSource))[i].Id == row.Id)
                            { 
                                index = i;
                                break;
                            }
                        }
                        _view.AllCoinsDgv.Rows[index].DefaultCellStyle.BackColor = System.Drawing.Color.Green;
                    }
                }
            }
        }

        private int CalcSumOfPrices(List<Coin> list)
        {
            int sum = 0;

            if (list != null)
            {
                foreach (var l in list)
                {
                    sum += l.Price;
                }
            }
            return sum;
        }

        private async Task<List<Coin>> GetCoinList()
        {
            using (var client = new HttpClient())
            {
                // Load information from offisial site
                var html = await client.GetStringAsync(_tableUrl);
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);

                var table = doc.DocumentNode.SelectSingleNode("//table[@id='coins_table']");

                var infoListMatrix = table.Descendants("tr")
                                .Skip(2)
                                .Select(tr => tr.Descendants("td")
                                                .Select(td => WebUtility.HtmlDecode(td.InnerText))
                                                .ToList())
                                .ToList();

                // Create list of objects Coin which consists of loaded previous information
                infoListMatrix = RemoveSpaces(infoListMatrix, false);

                List<Coin> coinList = new List<Coin>();
                int k = 0;
                foreach (var row in infoListMatrix)
                {
                    Coin coin = new Coin(k, row[0], row[1], row[2], TypeParser.ParseInt(row[3]), TypeParser.ParseDate(row[4]));
                    coinList.Add(coin);
                    k++;
                }
                return coinList;
            }
        }

        private List<string> RemoveSpaces(List<string> arr, bool doRemoveEmptyRows)
        {
            var result = new List<string>();
            for (int i = 0; i < arr.Count; i++)
            {
                string temp = "";
                for (int j = 0; j < arr[i].Length; j++)
                {
                    if (char.IsLetterOrDigit(arr[i][j]) || arr[i][j] == ' ' || char.IsPunctuation(arr[i][j]))
                    {
                        if (j != 0 && j != arr[i].Length - 1)
                        {
                            if (arr[i][j] == ' ')
                            {
                                if ((char.IsLetterOrDigit(arr[i][j - 1]) || char.IsPunctuation(arr[i][j-1])) && (char.IsLetterOrDigit(arr[i][j + 1]) || char.IsPunctuation(arr[i][j + 1])))
                                {
                                    temp += arr[i][j];
                                }
                            }
                            else
                            {
                                temp += arr[i][j];
                            }
                        }
                        else
                        {
                            if (arr[i][j] != ' ' && char.IsLetterOrDigit(arr[i][j]))
                            {
                                temp += arr[i][j];
                            }
                        }
                    }
                }
                arr[i] = temp;
                if (doRemoveEmptyRows)
                {
                    if (arr[i] != "")
                    {
                        result.Add(arr[i]);
                    }
                }
                else
                {
                    result.Add(arr[i]);
                }
            }
            return result;
        }
        private List<List<string>> RemoveSpaces(List<List<string>> matrix, bool doRemoveEmptyRows)
        {
            var result = new List<List<string>>();
            for(int i = 0; i < matrix.Count;i++)
            {
                result.Add(RemoveSpaces(matrix[i], doRemoveEmptyRows));
            }
            return result;
        }
        #endregion
    }
}