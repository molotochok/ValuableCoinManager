using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Linq.Dynamic;
using System.ComponentModel;

namespace ValuableCoins
{
    class Presenter
    {
        private const string _rootUrl  = "https://bank.gov.ua";
        private const string _tableUrl = _rootUrl + "/control/uk/currentmoney/cmcoin/list";

        private const string _collectionFileName = "collection.txt";
        private readonly IMainForm _view;

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

                            _view.LblAllCoinsPriceValue.Text = CalcSumOfPrices(AllCoinsList).ToString();
                            _view.LblAllCoinsCountValue.Text = AllCoinsList.Count.ToString();
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

                            _view.LblCollectionPriceValue.Text = CalcSumOfPrices(CollectionList).ToString();
                            _view.LblCollectionCountValue.Text = CollectionList.Count.ToString();

                            FileManager fileManager = new FileManager(_collectionFileName);

                            fileManager.Save(CollectionList);
                        }
                    ));
                    break;
                default:break;
            }
            
        }

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

        // <---------- Event Methods ---------->
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
            //var coinFullDescriptionList  = await GetCoinFullDescriptionList(coinList);
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
            foreach(var l in list)
            {
                sum += l.Price;
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
                    Coin coin = new Coin(k, row[0], row[1], row[2], ParseInt(row[3]), ParseDate(row[4]));
                    coinList.Add(coin);
                    k++;
                }
                return coinList;
            }
        }
        private async Task<List<CoinFullDescription>> GetCoinFullDescriptionList(List<Coin> coinList)
        {
            List<string> urlFromRootList = new List<string>();
            // Get all urls
            using (var client = new HttpClient())
            {
                var html = await client.GetStringAsync(_tableUrl);
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);

                var table = doc.DocumentNode.SelectSingleNode("//table[@id='coins_table']");
                var urls =  table.Descendants("tr")
                            .Skip(1)
                            .Select(tr => tr.SelectSingleNode("td")
                                            .SelectSingleNode("a"))
                            .Select(a  => WebUtility.HtmlDecode(a.GetAttributeValue("href","")))
                            .ToList();

                // Given urls are like /control/uk/currentmoney... so that we should add root to the beginning
                foreach (var url in urls)
                {
                    urlFromRootList.Add(_rootUrl + url);
                }
                return await GetInfoFromUrlList(urlFromRootList, coinList);
            }
        }
        private async Task<List<CoinFullDescription>> GetInfoFromUrlList(List<string> urlList, List<Coin> coinList)
        {
            List<CoinFullDescription> coinFullDescriptions = new List<CoinFullDescription>();

            int index = 0;
            foreach (var url in urlList)
            {
                using (var client = new HttpClient())
                {
                    var html = await client.GetStringAsync(url);
                    var doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(html);

                    var contentDiv = doc.DocumentNode.SelectSingleNode("//div[@class='content']");

                    var infoStr = contentDiv.Descendants("table").ToList()[3].SelectNodes("tr").Select(td => WebUtility.HtmlDecode(td.InnerText)).ToList()[1];
                    var infoArr = infoStr.Split(new char[] { '\n'}, StringSplitOptions.RemoveEmptyEntries);
                    
                    var list2 = contentDiv.Descendants("table").ToList()[4].SelectNodes("tr").Select(td => WebUtility.HtmlDecode(td.InnerText)).ToList();

                    List<string> infoList = new List<string>();
                    foreach (var a in list2)  { infoList.Add(a); }
                    foreach (var a in infoArr){ infoList.Add(a); }
                    infoList = RemoveSpaces(infoList, true);
                    CoinFullDescription coinFullDescription = null;
                    try
                    {
                        coinFullDescription = new CoinFullDescription(coinList[index],
                                                                                          ParseFloat(infoList[9]),
                                                                                          ParseFloat(infoList[11]),
                                                                                          infoList[12],
                                                                                          infoList[0],
                                                                                          ParseInt(infoList[13]),
                                                                                          infoList[1],
                                                                                     infoList[3]);
                    }catch(Exception ex)
                    {
                        Console.WriteLine(index);
                    }
                    coinFullDescriptions.Add(coinFullDescription);
                }
                index++;
            }
            return coinFullDescriptions;
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

        // Parse values
        private int ParseInt(string str)
        {
            int number = 0;
            int.TryParse(str, out number);
            return number;
        }
        private float ParseFloat(string str)
        {
            float number = 0f;
            float.TryParse(str, out number);
            return number;
        }
        private DateTime ParseDate(string str)
        {
            // Parse str to change ukrainian words to english
            string oldMonth = "";
            for(int i = 0; i < str.Length; i++)
            {
                if (char.IsLetter(str[i]))
                {
                    // Checks if char equals i (english) and store in oldMonth i (ukrainian)
                    if (str[i].Equals('i'))
                    {
                        str = str.Replace(str[i], 'і');
                    }
                    oldMonth += str[i];
                }
            }
            oldMonth = oldMonth.ToLower();

            string newMonth = "";
            switch (oldMonth)
            {
                case "січня": newMonth = "january"; break;
                case "лютого": newMonth = "february"; break;
                case "березня": newMonth = "march"; break;
                case "квітня": newMonth = "april"; break;
                case "травня": newMonth = "may"; break;
                case "червня": newMonth = "june"; break;
                case "липня": newMonth = "july"; break;
                case "серпня": newMonth = "august"; break;
                case "вересня": newMonth = "september"; break;
                case "жовтня": newMonth = "october"; break;
                case "листопада": newMonth = "november"; break;
                case "грудня": newMonth = "december"; break;
                default:break;
            }
            str =  str.Replace(oldMonth, newMonth);
            DateTime dateTime = new DateTime();

            DateTime.TryParse(str, out dateTime);

            return dateTime;
        }
        #endregion
    }
}