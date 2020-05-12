using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using System.IO;

namespace Dip
{
    public partial class Glavnayaform : Form
    {
        public Glavnayaform()
        {
            InitializeComponent();
            cmbAllSelect.Visible = false;
            lblJurnal.Visible = false;
            string p = SystemInformation.UserName;
            string s = Environment.MachineName;
            string n = s + "/" + p;
            if (n == "DESKTOP-19IDELH/Ser")
            {
                cmbAllSelect.Visible = true;
                lblJurnal.Visible = true;
            }
            //Для комбобоксов отрисовка содержимого из БД
            cmbKafedra.DataSource = DBObject.Entites.Kafedra.ToList().Select(c => c.Name).Distinct().ToList();
            cmbKalendarniyGod.DataSource = DBObject.Entites.Zakupka.ToList().Select(c => c.God_zakupki).Distinct().ToList();
            dgvSpisokZakupok.DataSource = DBObject.Entites.Zakupka.ToList();

            Starfall();
        }
        public void Starfall()
        {
            dgvSpisokZakupok.Columns["Kafedra1"].Visible = false;
            dgvSpisokZakupok.Columns["Kbk1"].Visible = false;
            dgvSpisokZakupok.Columns["Kvr1"].Visible = false;
            dgvSpisokZakupok.Columns["Sroc_zakupki"].Visible = false;

            dgvSpisokZakupok.Columns["Name"].HeaderText = "Наименование";
            dgvSpisokZakupok.Columns["KBK"].HeaderText = "КБК";
            dgvSpisokZakupok.Columns["KVR"].HeaderText = "КВР";
            dgvSpisokZakupok.Columns["Total_sum_rub"].HeaderText = "Итоговая сумма";
            dgvSpisokZakupok.Columns["Sum_rub"].HeaderText = "Сумма";
            dgvSpisokZakupok.Columns["Deshifrovka_rashodov"].HeaderText = "Расшифровка расходов";
            dgvSpisokZakupok.Columns["Min_trebovaniya"].HeaderText = "Минимальные требования";
            dgvSpisokZakupok.Columns["Kolvo_edinic"].HeaderText = "Количество единиц";
            dgvSpisokZakupok.Columns["Srok_zakupki"].HeaderText = "Срок закупки";
            dgvSpisokZakupok.Columns["God_zakupki"].HeaderText = "Год закупки";
            dgvSpisokZakupok.Columns["Kafedra"].HeaderText = "Кафедра";
        }

        private void startToolStripButton_Click(object sender, EventArgs e)
        {
            // Создаём объект документа
            Word.Document doc = null;
            try
            {
                // Создаём объект приложения
                Word.Application app = new Word.Application();
                // Путь до шаблона документа
                string source =Environment.CurrentDirectory+"//kibox.docx";

                // Открываем
                doc = app.Documents.Open(source);
                doc.Activate();

                // Добавляем информацию
                // wBookmarks содержит все закладки
                Word.Bookmarks wBookmarks = doc.Bookmarks;
                Word.Range wRange;


                foreach (Word.Bookmark mark in wBookmarks)
                {
                    int g = dgvSpisokZakupok.Rows.Count;
                    wRange = mark.Range;
                    Object defaultTableBehavior =
                       Word.WdDefaultTableBehavior.wdWord9TableBehavior;
                    Object autoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitWindow;
                    //Добавляем таблицу и получаем объект wordtable      || +2 т.к. считается каждая строка в шаблоне (шапка и подвал)
                    Word.Table wordtable = doc.Tables.Add(wRange, dgvSpisokZakupok.Rows.Count + 2, 10,
                                      ref defaultTableBehavior, ref autoFitBehavior);

                    //Верхние колонки
                    Word.Range wordcellrange = doc.Tables[1].Cell(1, 1).Range;
                    wordcellrange.Text = "№ п/п";
                    //Номера первого столбца
                    for(int i = 0; i < g; i++)
                    {
                        Word.Range rana = doc.Tables[1].Cell(i+2, 1).Range;
                        rana.Text = Convert.ToString(i+1);
                    }

                    Word.Range rams = doc.Tables[1].Cell(g+2, 1).Range;
                    rams.Text = Convert.ToString(g + 1);
                    //Названия первой строки всех стоблцов
                    Word.Range wordcellranges = doc.Tables[1].Cell(1, 2).Range;
                    wordcellranges.Text = "Наименование";
                    Word.Range wordcellranger = doc.Tables[1].Cell(1, 3).Range;
                    wordcellranger.Text = "КБК";
                    Word.Range wordcellrangee = doc.Tables[1].Cell(1, 4).Range;
                    wordcellrangee.Text = "КВР";
                    Word.Range wordcellrangy = doc.Tables[1].Cell(1, 5).Range;
                    wordcellrangy.Text = "Сумма итого по коду (руб.)";
                    Word.Range wordcellrangys = doc.Tables[1].Cell(1, 6).Range;
                    wordcellrangys.Text = "Сумма (руб.)";
                    Word.Range wordcellrangyp = doc.Tables[1].Cell(1, 7).Range;
                    wordcellrangyp.Text = "Расшифровка расходов (по видам расходов)";
                    Word.Range wordcellrangyh = doc.Tables[1].Cell(1, 8).Range;
                    wordcellrangyh.Text = "Минимально необходимые требования";
                    Word.Range wordcellrany = doc.Tables[1].Cell(1, 9).Range;
                    wordcellrany.Text = "Количество, ед.изм.";
                    Word.Range wordcellragy = doc.Tables[1].Cell(1, 10).Range;
                    wordcellragy.Text = "Предполагаемый срок закупки (месяц)";
                    //Редактор каждой колонки
                    wordcellrange.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    wordcellrange.Font.Bold = 0;
                    wordcellranges.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    wordcellranger.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    wordcellrangee.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    wordcellrangy.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;

                    //Наименование
                    for (int i = 0; i < g; i++)
                    {


                        Word.Range wordcellrang = doc.Tables[1].Cell(i+2, 2).Range;
                        wordcellrang.Text = Convert.ToString(dgvSpisokZakupok[1, i].Value);
                        wordcellrang.ParagraphFormat.Alignment =
                       Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    }

                    //КБК 
                    for (int i = 0; i < g; i++)
                    {
                        Word.Range wordcellra = doc.Tables[1].Cell(i+2, 3).Range;
                        wordcellra.Text = Convert.ToString(dgvSpisokZakupok[2, i].Value);
                        wordcellra.ParagraphFormat.Alignment =
                       Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    }

                    //КВР
                    for (int i = 0; i < g; i++)
                    {
                        Word.Range wordcellra = doc.Tables[1].Cell(i + 2, 4).Range;
                        wordcellra.Text = Convert.ToString(dgvSpisokZakupok[3, i].Value);
                        wordcellra.ParagraphFormat.Alignment =
                       Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    }

                    //Итоговая сумма
                    for (int i = 0; i < g; i++)
                    {
                        Word.Range wordcellra = doc.Tables[1].Cell(i + 2, 5).Range;
                        wordcellra.Text = Convert.ToString(dgvSpisokZakupok[4, i].Value);
                        wordcellra.ParagraphFormat.Alignment =
                       Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    }

                    //Сумма
                    for (int i = 0; i < g; i++)
                    {
                        Word.Range wordcellra = doc.Tables[1].Cell(i + 2, 6).Range;
                        wordcellra.Text = Convert.ToString(dgvSpisokZakupok[5, i].Value);
                        wordcellra.ParagraphFormat.Alignment =
                       Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    }

                    //Расшифровка расходов
                    for (int i = 0; i < g; i++)
                    {
                        Word.Range wordcera = doc.Tables[1].Cell(i+2, 7).Range;
                        wordcera.Text = Convert.ToString(dgvSpisokZakupok[6, i].Value);
                        wordcera.ParagraphFormat.Alignment =
                       Word.WdParagraphAlignment.wdAlignParagraphLeft;
                        wordcera.Font.Size = 9;
                    }

                    //Минимальные требования
                    for (int i = 0; i < g; i++)
                    {
                        Word.Range wordcellra = doc.Tables[1].Cell(i + 2, 8).Range;
                        wordcellra.Text = Convert.ToString(dgvSpisokZakupok[7, i].Value);
                        wordcellra.ParagraphFormat.Alignment =
                       Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    }

                    //Количество
                    for (int i = 0; i < g; i++)
                    {
                        Word.Range wordcellra = doc.Tables[1].Cell(i + 2, 9).Range;
                        wordcellra.Text = Convert.ToString(dgvSpisokZakupok[8, i].Value);
                        wordcellra.ParagraphFormat.Alignment =
                       Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    }

                    //Срок закупки
                    for (int i = 0; i < g; i++)
                    {
                        Word.Range wordcellra = doc.Tables[1].Cell(i + 2, 10).Range;
                        wordcellra.Text = Convert.ToString(dgvSpisokZakupok[9, i].Value);
                        wordcellra.ParagraphFormat.Alignment =
                       Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    }

                    ///////

                    //Выделение ячеек первого столбца
                    object begCell = wordtable.Cell(2, 1).Range.Start;
                        object endCell = wordtable.Cell(g+2, 1).Range.End;

                        Word.Range range = doc.Range(ref begCell, ref endCell);
                        range.Select();

                        //обращение первым способом
                        range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        range.Font.Bold = 0;
                        range.Columns[1].Width = 20;
                        range.Rows[1].Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                        range.Rows[2].Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                        range.Rows[3].Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                        //Значения по середине колонки
                        range.Columns[1].Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                    //range.Columns.SetWidth(5,Word.WdRulerStyle.wdAdjustNone);           

                    //-------------------------------------------------------------------

                    //Выделение верхних ячеек
                    object begsCell = wordtable.Cell(1, 1).Range.Start;
                        object endsCell = wordtable.Cell(1, 10).Range.End;

                        Word.Range rangek = doc.Range(ref begsCell, ref endsCell);
                        rangek.Select();

                        //обращение первым способом
                        rangek.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        rangek.Font.Bold = 1;
                        rangek.Rows[1].Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                    //rangek.Rows[2].Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                    //--------------------------------------------

                    //Выделение ячеек третьего столбца
                    object begysoCell = wordtable.Cell(2, 2).Range.Start;
                    object endysoCell = wordtable.Cell(g + 2, 2).Range.End;

                    Word.Range rangyso = doc.Range(ref begysoCell, ref endysoCell);
                    rangyso.Select();

                    //обращение первым способом
                    rangyso.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    //В столбце 3 значения будут по середине колонки находиться
                    rangyso.Columns[2].Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                    //range.Columns.SetWidth(5,Word.WdRulerStyle.wdAdjustNone);           

                    //-------------------------------------------------------------------


                    //Выделение ячеек третьего столбца
                    object begysCell = wordtable.Cell(2, 3).Range.Start;
                        object endysCell = wordtable.Cell(g+2, 3).Range.End;

                        Word.Range rangys = doc.Range(ref begysCell, ref endysCell);
                        rangys.Select();

                        //обращение первым способом
                        rangys.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        rangys.Font.Bold = 0;
                        rangys.Columns[3].Width = 20;
                        //В столбце 3 значения будут по середине колонки находиться
                        rangek.Columns[3].Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                    //range.Columns.SetWidth(5,Word.WdRulerStyle.wdAdjustNone);           

                    //-------------------------------------------------------------------

                    //Выделение ячеек четвёртого столбца
                    object begatCell = wordtable.Cell(2, 4).Range.Start;
                        object endatCell = wordtable.Cell(g+2, 4).Range.End;

                        Word.Range rangat = doc.Range(ref begatCell, ref endatCell);
                        rangat.Select();

                        //обращение первым способом
                        rangat.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        rangat.Font.Bold = 0;
                        rangat.Columns[4].Width = 20;
                        //Значение по середине колонки
                        rangat.Columns[4].Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                    //range.Columns.SetWidth(5,Word.WdRulerStyle.wdAdjustNone);           

                    //-------------------------------------------------------------------

                    //Выделение ячеек пятого столбца
                    object begyxCell = wordtable.Cell(2, 5).Range.Start;
                        object endyxCell = wordtable.Cell(g+2, 5).Range.End;

                        Word.Range rangyx = doc.Range(ref begyxCell, ref endyxCell);
                        rangyx.Select();

                        //обращение первым способом
                        rangyx.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        rangyx.Font.Bold = 0;
                        rangyx.Columns[5].Width = 100;
                    //Значение по середине колонки
                    rangyx.Columns[5].Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                    //range.Columns.SetWidth(5,Word.WdRulerStyle.wdAdjustNone);           

                    //-------------------------------------------------------------------

                    //Выделение ячеек шестого столбца
                    object begyzCell = wordtable.Cell(2, 6).Range.Start;
                        object endyzCell = wordtable.Cell(g+2, 6).Range.End;

                        Word.Range rangyz = doc.Range(ref begyzCell, ref endyzCell);
                        rangyz.Select();

                        //обращение первым способом
                        rangyz.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        rangyz.Font.Bold = 0;
                        rangyz.Columns[6].Width = 80;
                        //Значение по середине колонки
                        rangyz.Columns[6].Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                    //range.Columns.SetWidth(5,Word.WdRulerStyle.wdAdjustNone);           

                    //-------------------------------------------------------------------

                    //Выделение ячеек седьмого столбца
                    object begytCell = wordtable.Cell(2, 7).Range.Start;
                        object endytCell = wordtable.Cell(g+2, 7).Range.End;

                        Word.Range rangyt = doc.Range(ref begytCell, ref endytCell);
                        rangyt.Select();

                        //обращение первым способом
                        rangyt.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        rangyt.Font.Bold = 0;
                        rangyt.Columns[7].Width = 144;
                    //Значение по середине колонки
                        rangyt.Columns[7].Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                    //range.Columns.SetWidth(5,Word.WdRulerStyle.wdAdjustNone);           

                    //-------------------------------------------------------------------

                    //Выделение ячеек восьмого столбца
                    object begymCell = wordtable.Cell(2, 8).Range.Start;
                        object endymCell = wordtable.Cell(g+2, 8).Range.End;

                        Word.Range rangym = doc.Range(ref begymCell, ref endymCell);
                        rangym.Select();

                        //обращение первым способом
                        rangym.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        rangym.Font.Bold = 0;
                        rangym.Columns[8].Width = 144;
                    //Значение по середине колонки
                        rangym.Columns[8].Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                    //range.Columns.SetWidth(5,Word.WdRulerStyle.wdAdjustNone);           

                    //-------------------------------------------------------------------

                    //Выделение ячеек девятого столбца
                    object begyCell = wordtable.Cell(2, 9).Range.Start;
                        object endyCell = wordtable.Cell(g+2, 9).Range.End;

                        Word.Range rangy = doc.Range(ref begyCell, ref endyCell);
                        rangy.Select();

                        //обращение первым способом
                        rangy.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        rangy.Font.Bold = 0;
                        rangy.Columns[9].Width = 50;
                    //Значение по середине колонки
                        rangy.Columns[9].Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                    //range.Columns.SetWidth(5,Word.WdRulerStyle.wdAdjustNone);           

                    //-------------------------------------------------------------------


                    //Выделение ячеек последнего столбца
                    object begeCell = wordtable.Cell(2, 10).Range.Start;
                        object endeCell = wordtable.Cell(g+2, 10).Range.End;

                        Word.Range rangee = doc.Range(ref begeCell, ref endeCell);
                        rangee.Select();

                        //обращение первым способом
                        rangee.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        rangee.Font.Bold = 0;
                        rangee.Columns[10].Width = 100;
                    //Значение по середине колонки
                        rangee.Columns[10].Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                    //range.Columns.SetWidth(5,Word.WdRulerStyle.wdAdjustNone);           


                    //Последняя строка итоговая 
                    //-------------------------------------------------------------------
                    Word.Range ramli = doc.Tables[1].Cell(g + 2, 2).Range;

                    ramli.Font.Bold = 1;
                    ramli.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                    ramli.Text = "ВСЕГО:";
                    //------------------------------------------------------------
                    Word.Range ramlij = doc.Tables[1].Cell(g + 2, 5).Range;

                    ramlij.Font.Bold = 1;
                    ramlij.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    decimal bb = 0;
                    for (int i = 0; i < g; i++)
                    {
                        bb += Convert.ToDecimal(dgvSpisokZakupok[5, i].Value);
                        ramlij.Text = Convert.ToString(bb) + " ₽";
                    }
                    //------------------------------------------------------------
                }

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Сохранить файл";

                sfd.Filter = "Документ MS Word|*.docx";

                sfd.FileName = "План закупок";

                DialogResult DR;
                do
                {
                    DR = sfd.ShowDialog();
                    if (DR == DialogResult.OK)
                    {

                    }
                }
                while (DR != DialogResult.OK);

                doc.SaveAs(sfd.FileName);

                app.Visible = true;
            }
            
            catch (Exception error)
            {
                // Если произошла ошибка, то
                // закрываем документ и выводим информацию
                doc.Close();
                doc = null;
                Console.WriteLine("Во время выполнения произошла ошибка!");
                Console.ReadLine();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dipDataSet.Report". При необходимости она может быть перемещена или удалена.
            this.reportTableAdapter.Fill(this.dipDataSet.Report);

        }

        private void dgvSpisokZakupok_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Zakupka zakupka = (Zakupka)dgvSpisokZakupok.Rows[e.RowIndex].DataBoundItem;
                FormAddAndEditZakupka form = new FormAddAndEditZakupka(zakupka);
                form.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Ошибка","Выберите строку!");
            }
        }

        private void создатьToolStripButton_Click(object sender, EventArgs e)
        {
            Zakupka zakupka = new Zakupka();
            FormAddAndEditZakupka form = new FormAddAndEditZakupka(zakupka);
            form.ShowDialog();
            try
            {
                dgvSpisokZakupok.DataSource = DBObject.Entites.Zakupka.ToList();
            }
            catch
            {
                MessageBox.Show("Что то пошло не так!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void сохранитьToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                DBObject.Entites.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Некорректные данные в таблице!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Кнопка обновить
        private void UpdatetoolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                dgvSpisokZakupok.DataSource = DBObject.Entites.Zakupka.ToList();

                //Ещё раз отрисовывается вся таблица и очищаются поля фильтрации
                Starfall();
                cmbKalendarniyGod.Text = "";
                cmbKafedra.Text = "";
                startToolStripButton.Enabled = true;

            }
            catch
            {
                MessageBox.Show("Ошибка!", "Что то пошло не так!");
            }
        }

        private void cmbKalendarniyGod_TextChanged(object sender, EventArgs e)
        {
            if (cmbKalendarniyGod.Text != "")
            {
                dgvSpisokZakupok.DataSource = DBObject.Entites.Zakupka.Where(c => c.God_zakupki.ToString() == cmbKalendarniyGod.Text).ToList();
            }
        }
        private void cmbKafedra_TextChanged(object sender, EventArgs e)
        {
            if (cmbKafedra.Text != "")
            {
                dgvSpisokZakupok.DataSource = DBObject.Entites.Zakupka.Where(c => c.Kafedra.ToString() == cmbKafedra.Text).ToList();
            }
        }

        private void cmbAllSelect_TextChanged_1(object sender, EventArgs e)
        {
            startToolStripButton.Enabled = false;
            if (cmbAllSelect.Text == "Kafedra_Jurnal")
            {
                dgvSpisokZakupok.DataSource = DBObject.Entites.Kafedra_Jurnal.ToList();
            }
            if (cmbAllSelect.Text == "Kbk_Jurnal")
            {
                dgvSpisokZakupok.DataSource = DBObject.Entites.Kbk_Jurnal.ToList();
            }
            if (cmbAllSelect.Text == "Kvr_Jurnal")
            {
                dgvSpisokZakupok.DataSource = DBObject.Entites.Kvr_Jurnal.ToList();
            }
            if (cmbAllSelect.Text == "Sroc_Zakupki_Jurnal")
            {
                dgvSpisokZakupok.DataSource = DBObject.Entites.Sroc_zakupki_Jurnal.ToList();
            }
            if (cmbAllSelect.Text == "Zakupka_Jurnal")
            {
                dgvSpisokZakupok.DataSource = DBObject.Entites.Zakupka_Jurnal.ToList();
            }
        }
    }
}
