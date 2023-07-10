using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using MySql.Data.MySqlClient.Memcached;
using MySqlX.XDevAPI;

namespace graduate_work
{
    public partial class Form1 : Form
    {
        ComboBox cb;
        BTranslator bt;
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedItem = "Казахский";
            comboBox1.SelectedItem = "Английский";
            cb = new ComboBox();
            bt = new BTranslator();
            #region Коллекция языков резерного ComboBox
            cb.Items.AddRange(new object[] {
            "Азербайджанский",
            "Албанский",
            "Английский",
            "Арабский",
            "Армянский",
            "Африкаанс",
            "Баскский",
            "Башкирский",
            "Белорусский",
            "Бенгальский",
            "Болгарский",
            "Боснийский",
            "Валлийский",
            "Венгерский",
            "Вьетнамский",
            "Гаитянский",
            "Галисийский",
            "Голландский",
            "Горномарийский",
            "Греческий",
            "Грузинский",
            "Гуджарати",
            "Датский",
            "Иврит",
            "Идиш",
            "Индонезийский",
            "Ирландский",
            "Испанский",
            "Итальянский",
            "Исландский",
            "Казахский",
            "Каннада",
            "Каталанский",
            "Киргизский",
            "Китайский",
            "Корейский",
            "Коса",
            "Кхмерский",
            "Лаосский",
            "Латынь",
            "Латышский",
            "Литовский",
            "Люксембургский",
            "Македонский",
            "Малагасийский",
            "Малайский",
            "Малаялам",
            "Мальтийский",
            "Маори",
            "Маратхи",
            "Марийский",
            "Монгольский",
            "Немецкий",
            "Непальский",
            "Нидерландский",
            "Норвежский",
            "Панджаби",
            "Папьяменто",
            "Персидский",
            "Польский",
            "Португальский",
            "Румынский",
            "Русский",
            "Себуанский",
            "Сербский",
            "Сингальский",
            "Словацкий",
            "Словенский",
            "Суахили",
            "Сунданский",
            "Тагальский",
            "Таджикский",
            "Тайский",
            "Тамильский",
            "Татарский",
            "Телугу",
            "Турецкий",
            "Удмуртский",
            "Узбекский",
            "Украинский",
            "Урду",
            "Финский",
            "Французский",
            "Хинди",
            "Хорватский",
            "Чешский",
            "Чувашский",
            "Шведский",
            "Шотландский (Гэльский)",
            "Эльфийский (Синдарин)",
            "Эмодзи",
            "Эсперанто",
            "Эстонский",
            "Яванский",
            "Якутский",
            "Японский"});

            #endregion
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = "Казахский";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = "Английский";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            comboBox2.SelectedItem = "Русский";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            comboBox2.SelectedItem = "Французский";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();

            richTextBox2.Text = bt.Translator(richTextBox1.Text, bt.GetLangPair(comboBox1.SelectedItem.ToString(), comboBox2.SelectedItem.ToString()));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cb.SelectedItem = comboBox2.SelectedItem;
            comboBox2.SelectedItem = comboBox1.SelectedItem;
            comboBox1.SelectedItem = cb.SelectedItem;
        }
        private void AppendTextClick(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                var endpoint = new Uri("https://fish-text.ru/get?format=html&number=1");
                var result = client.GetAsync(endpoint).Result;
                var json = result.Content.ReadAsStringAsync().Result;
                richTextBox1.AppendText(json);
                richTextBox2.Text = bt.Translator(richTextBox1.Text, bt.GetLangPair(comboBox1.SelectedItem.ToString(), comboBox2.SelectedItem.ToString()));
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            comboBox3.SelectedItem = "Русский";
        }
    }
}
