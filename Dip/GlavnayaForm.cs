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
            dgvSpisokZakupok.DataSource = DBObject.Entites.Zakupka.ToList();
            //dataGridView1.Columns["Kalendarniy_god"].Visible = false;
            //dataGridView1.Columns["Name_kafedra"].Visible = false;
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

                //openFileDialog1.Filter = "*.docx|документы docx";
                //DialogResult result = openFileDialog1.ShowDialog();

                //try
                //{
                //    if (result == DialogResult.OK)
                //    {
                //        source = openFileDialog1.FileName;
                //    }
                //    if (result == DialogResult.Cancel)
                //    {

                //    }
                //}
                //catch { MessageBox.Show("Откройте файл формата .doc", "Формат не соответствует требуемому", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
                    //Word.Range wordcellrange = doc.Tables[1].Cell(1, 1).Range;
                    //for (int m = 0; m < wordtable.Rows.Count; m++)
                    //    for (int n = 0; n < wordtable.Columns.Count; n++)
                    //    {
                    //        wordcellrange = wordtable.Cell(m + 1, n + 1).Range;
                    //        wordcellrange.Text = "Ячейка" + Convert.ToString(m + 1) + " "
                    //                                 + Convert.ToString(n + 1);
                    //    }


                    //Верхние колонки
                    Word.Range wordcellrange = doc.Tables[1].Cell(1, 1).Range;
                    wordcellrange.Text = "№ п/п";
                    //Номера первого столбца
                    for(int i = 0; i < g; i++)
                    {
                        Word.Range rana = doc.Tables[1].Cell(i+2, 1).Range;
                        rana.Text = Convert.ToString(i+1);
                    }
                    //Word.Range ran = doc.Tables[1].Cell(2, 1).Range;
                    //ran.Text = "1";
                    //Word.Range ra = doc.Tables[1].Cell(3, 1).Range;
                    //ra.Text = "2";
                    //Word.Range rami = doc.Tables[1].Cell(4, 1).Range;
                    //rami.Text = "3";
                    //Word.Range ram = doc.Tables[1].Cell(5, 1).Range;
                    //ram.Text = "4";
                    //Word.Range raml = doc.Tables[1].Cell(6, 1).Range;
                    //raml.Text = "5";
                    //Word.Range ramli = doc.Tables[1].Cell(7, 1).Range;
                    //ramli.Text = "6";
                    //Word.Range ramjo = doc.Tables[1].Cell(8, 1).Range;
                    //ramjo.Text = "7";
                    //Word.Range ramo = doc.Tables[1].Cell(9, 1).Range;
                    //ramo.Text = "8";
                    //Word.Range rama = doc.Tables[1].Cell(10, 1).Range;
                    //rama.Text = "9";
                    //Word.Range ramf = doc.Tables[1].Cell(11, 1).Range;
                    //ramf.Text = "10";
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

                    // Word.Range wordcellranh = doc.Tables[1].Cell(3, 2).Range;
                    // wordcellranh.Text = Convert.ToString(dgvSpisokZakupok[1, 1].Value);
                    // wordcellranh.ParagraphFormat.Alignment =
                    //Word.WdParagraphAlignment.wdAlignParagraphCenter;

                    //     Word.Range wordcellran = doc.Tables[1].Cell(4, 2).Range;
                    //     wordcellran.Text = Convert.ToString(dgvSpisokZakupok[1, 2].Value);
                    //     wordcellran.ParagraphFormat.Alignment =
                    //    Word.WdParagraphAlignment.wdAlignParagraphCenter;


                    //КБК 
                    for (int i = 0; i < g; i++)
                    {
                        Word.Range wordcellra = doc.Tables[1].Cell(i+2, 3).Range;
                        wordcellra.Text = Convert.ToString(dgvSpisokZakupok[2, i].Value);
                        wordcellra.ParagraphFormat.Alignment =
                       Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    }
                    // Word.Range wordcellr = doc.Tables[1].Cell(3, 3).Range;
                    // wordcellr.Text = Convert.ToString(dgvSpisokZakupok[2, 1].Value);
                    // wordcellr.ParagraphFormat.Alignment =
                    //Word.WdParagraphAlignment.wdAlignParagraphCenter;

                    // Word.Range wordcell = doc.Tables[1].Cell(4, 3).Range;
                    // wordcell.Text = Convert.ToString(dgvSpisokZakupok[2, 2].Value);
                    // wordcell.ParagraphFormat.Alignment =
                    //Word.WdParagraphAlignment.wdAlignParagraphCenter;

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
                    // Word.Range wordcellre = doc.Tables[1].Cell(3, 7).Range;
                    // wordcellre.Text = Convert.ToString(dgvSpisokZakupok[6, 1].Value);
                    // wordcellre.ParagraphFormat.Alignment =
                    //Word.WdParagraphAlignment.wdAlignParagraphLeft;
                    // wordcellre.Font.Size = 9;

                    // Word.Range wordcellrer = doc.Tables[1].Cell(4, 7).Range;
                    // wordcellrer.Text = Convert.ToString(dgvSpisokZakupok[6, 2].Value);
                    // wordcellrer.ParagraphFormat.Alignment =
                    //Word.WdParagraphAlignment.wdAlignParagraphLeft;
                    // wordcellrer.Font.Size = 9;

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


                /// Закрываем документ и сохраняем изменения
                ///doc.Close();
                ///doc = null;
                //---------Открытие нового---------------
                //Word.Document doc = app.Documents.Add();
                //doc.Paragraphs[1].Range.Text = this.textBox1.Text;

                //app.Visible = true;




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

                //doc.Close(ref falseObj, ref missingObj, ref missingObj);
                //app.Quit(ref missingObj, ref missingObj, ref missingObj);

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
               // dgvSpisokZakupok.DataSource = DBObject.Entites.Zakupka.ToList();
                form.ShowDialog();
                //DateTime date = DateTime.Today;
                //if (date.Year != zakupka.God_zakupki)
                //{
                //    ;
                //}
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
                MessageBox.Show("Ошибка!", "Что то пошло не так!");
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
                MessageBox.Show("Ошибка!", "Что то пошло не так!");
            }
        }
        //Кнопка обновить
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                dgvSpisokZakupok.DataSource = DBObject.Entites.Zakupka.ToList();

                //Ещё раз отрисовывается вся таблица и очищаются поля фильтрации
                Starfall();
                cmbKalendarniyGod.Text = "";
                cmbKafedra.Text = "";

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
            switch (cmbKafedra.Text)
            {
                case "ФиПМ":
                    {
                        dgvSpisokZakupok.DataSource = DBObject.Entites.Zakupka
                           .Where(t => t.Kafedra.ToString().Contains(cmbKafedra.Text)).ToList();
                        Starfall();
                        break;
                    }
                case "КиТП":
                    {
                        dgvSpisokZakupok.DataSource = DBObject.Entites.Zakupka
                           .Where(t => t.Kafedra.ToString().Contains(cmbKafedra.Text)).ToList();
                        Starfall();
                        break;
                    }
            }
        }
    }
}
