using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace EmeSta
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow 
    {
        public MainWindow()
        {
            InitializeComponent();

            List<Urawa> list = new List<Urawa>();
            list.Add(new Urawa()
            {
                ID = 22,
                CD = "Abe",
                Pos = "DF"
            });
            list.Add(new Urawa()
            {
                ID = 11,
                CD = "Sekiguchi",
                Pos = "Wing"
            });

            //★拡張メソッド
            var linqTest = list.Where(n => n.CD == "Abe");   //n.CD == "22"がプレディケート（Func<Urawa, bool> Predicate)
            //list自身が抽出処理を行い結果を返すことができる。

            //☆匿名クラス
            var test = list.Where(n => n.CD != "Nasu").Select(n => new { seban = n.ID, task = n.Pos });
            //クラスを宣言してないのに加工できる。
            foreach (var senshu in test)
            {
                if (senshu.task == "Any") { }
            }

            //②関数CheckDataを、デリゲートオブジェクト（ここではPredicate）にラッピングしてFindAllをかける。
            //FindAllに渡しているのが関数ポインタ。
            var linqtest2 = list.FindAll(new Predicate<Urawa>(CheckData));

            //③簡単な式で関数宣言したくない→匿名メソッド化
            var linqtest3 = list.FindAll(delegate(Urawa red) { return (red.ID == 18); });

            //④ラムダ化
            var linqtest4 = list.Where(red => red.ID == 18);
            var linqtest5 = list.Where(n => n.ID == 18);            
        }

        //③匿名メソッドがまだない時とか、関数宣言したい場合はこちらを関数ポインタを渡す。
        private bool CheckData(Urawa red)
        {
            return (red.ID == 18);
        }

        public class Urawa
        { 
            public Int64 ID { get; set; }
            public string CD { get; set; }
            public string Pos { get; set; }
        }


        #region "プライベートメソッド"

        private void ShowBigButton()
        {
            btnPortfolio.Visibility = System.Windows.Visibility.Visible;
            btnAmeba.Visibility = System.Windows.Visibility.Visible;
            btnProgram.Visibility = System.Windows.Visibility.Visible;
            btnData.Visibility = System.Windows.Visibility.Visible;
        }

        private void HideBigButton(Button btn)
        {
            btn.Visibility = System.Windows.Visibility.Hidden;
        }
        #endregion

        #region "イベント（分類ボタン押下）"

        private void btnPortfolio_Click(object sender, RoutedEventArgs e)
        {
            ShowBigButton();
            HideBigButton((System.Windows.Controls.Button)sender);
        }

        private void btnAmeba_Click(object sender, RoutedEventArgs e)
        {
            ShowBigButton();
            HideBigButton((System.Windows.Controls.Button)sender);
        }

        private void btnProgram_Click(object sender, RoutedEventArgs e)
        {
            ShowBigButton();
            HideBigButton((System.Windows.Controls.Button)sender);
        }

        private void btnData_Click(object sender, RoutedEventArgs e)
        {
            ShowBigButton();
            HideBigButton((System.Windows.Controls.Button)sender);
        }

        #endregion

        #region "イベント（ポートフォリオ項目ボタン押下）"

        private void btnEverNote_Click(object sender, RoutedEventArgs e)
        {
            string act = @"C:\Program Files\Evernote\Evernote\Evernote.exe";
            Process.Start(act);
        }

        private void btnKoseigaku_Click(object sender, RoutedEventArgs e)
        {
            string act = @"C:\OnUse\data\four\個性学.xls";
            Process.Start(act);
        }

        #endregion

        #region "イベント（アメ項目ボタン押下）"

        private void btnMow_Click(object sender, RoutedEventArgs e)
        {
            string act = @"http://mypage.ameba.jp/";
            Process.Start(act);
        }

        private void btnCha_Click(object sender, RoutedEventArgs e)
        {
            string act = @"C:\Program Files\Mozilla Firefox\firefox.exe ";
            string parameter = @"http://mypage.ameba.jp/";
            Process.Start(act, parameter);
            ;
        }

        private void btnWebli_Click(object sender, RoutedEventArgs e)
        {
            string act = @"C:\Program Files\Mozilla Firefox\firefox.exe ";
            string parameter = @"https://bblog.sso.biglobe.ne.jp/ap/tool/statusdisplay.do";
            Process.Start(act, parameter);
        }

        #endregion

        #region "イベント（プログラム項目ボタン押下）"

        private void btnOtherData_Click(object sender, RoutedEventArgs e)
        {
            string act = @"C:\OnUse\Data\four";
            Process.Start(act);
        }

        private void btnOtherProgram_Click(object sender, RoutedEventArgs e)
        {
            string act = @"C:\OnUse\shortcut";
            Process.Start(act);
        }

        private void btnBackUp_Click(object sender, RoutedEventArgs e)
        {
            string act = @"C:\Program Files\4shared Desktop\desktop.exe";
            Process.Start(act);
        }

        #endregion

        #region "イベント（データ項目ボタン押下）"

        private void btnSkyDrive_Click(object sender, RoutedEventArgs e)
        {
            string act = @"C:\Program Files\Mozilla Firefox\firefox.exe ";
            string parameter = @"https://skydrive.live.com/";
            Process.Start(act, parameter);
        }

        private void btnPicFolder_Click(object sender, RoutedEventArgs e)
        {
            string act = @"C:\Documents and Settings\Administrator\My Documents\My Pictures";
            Process.Start(act);
        }

        private void btnDropBox_Click(object sender, RoutedEventArgs e)
        {
            string act = @"C:\Documents and Settings\Administrator\Application Data\Dropbox\bin\Dropbox.exe";
            string parameter = @"/ home";
            Process.Start(act, parameter);
        }

        private void btnDropBoxFolder_Click(object sender, RoutedEventArgs e)
        {
            string act = @"C:\OnUse\Data\Dropbox";
            Process.Start(act);
        }

        private void btnMail_Click(object sender, RoutedEventArgs e)
        {
            string act = @"C:\Program Files\Mozilla Firefox\firefox.exe ";
            string parameter = @"www.hotmail.com/?mkt=ja-jp";
            Process.Start(act, parameter);
        }

        #endregion
        
    }
}
