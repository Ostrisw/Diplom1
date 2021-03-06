﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dip
{
    public partial class FormAddAndEditZakupka : Form
    {
        private Zakupka MyZakupka { get; }
        public FormAddAndEditZakupka(Zakupka zakupka)
        {
            InitializeComponent();
            MyZakupka = zakupka;
            if (DBObject.Entites.Zakupka.Where(t => t.Id == MyZakupka.Id).Count() > 0)
            {
                F2_closebtn.Visible = false;
            }
            else
            {
                F2_delbtn.Visible = false;
            }
            Fill();
        }
        
        public void Zapret()
        {
            //запрет редактировать поля
            F2_TxtBoxName.ReadOnly = true;

            F2_cmbBoxKBK.Enabled = false;
            F2_cmbBoxKVR.Enabled = false;
            F2_NumUpDownTotalSum.Enabled = false;
            F2_NumUpDownSum.Enabled = false;

            F2_TxtBoxRashifrovkaRashodov.ReadOnly = true;
            F2_TxtBoxMinTrebovaniya.ReadOnly = true;
            F2_TxtBoxKolvoEdinic.ReadOnly = true;
            F2_cmbBoxSrokZakupki.Enabled = false;
            F2_cmbBoxGodZakupki.Enabled = false;
            F2_TxtBoxKafedra.ReadOnly = true;
        }

        private void Fill()
        {
            F2_TxtBoxName.Text = MyZakupka.Name;
            F2_cmbBoxKBK.Text = Convert.ToString(MyZakupka.KBK);
            F2_cmbBoxKVR.Text = Convert.ToString(MyZakupka.KVR);
            F2_NumUpDownTotalSum.Value = Convert.ToDecimal(MyZakupka.Total_sum_rub);
            F2_NumUpDownSum.Value = Convert.ToDecimal(MyZakupka.Sum_rub);
            F2_TxtBoxRashifrovkaRashodov.Text = MyZakupka.Deshifrovka_rashodov;
            F2_TxtBoxMinTrebovaniya.Text = MyZakupka.Min_trebovaniya;
            F2_TxtBoxKolvoEdinic.Text = MyZakupka.Kolvo_edinic;
            F2_cmbBoxSrokZakupki.Text = MyZakupka.Srok_zakupki;
            F2_cmbBoxGodZakupki.Text = Convert.ToString(MyZakupka.God_zakupki);
            F2_TxtBoxKafedra.Text = MyZakupka.Kafedra;

            //Запрещает измененять информацию не текущего года
            DateTime date = DateTime.Today;
            if (F2_cmbBoxGodZakupki.Text == "0")
            {
                F2_cmbBoxGodZakupki.Text = Convert.ToString(date.Year);
            }
            //запрет в комбобоксе вписывать свою информацию
            F2_cmbBoxGodZakupki.DropDownStyle = ComboBoxStyle.DropDownList;
            if (date.Year > MyZakupka.God_zakupki)
            {
                F2_savebtn.Visible = false;
                F2_delbtn.Visible = false;

                //запрет редактировать поля
                Zapret();
            }
            //Проверка на администратора
            F2_cmbPoiskUsera.DataSource = DBObject.Entites.RoleUser();
            if (F2_cmbPoiskUsera.Text == "db_owner")
            {
            }
            else
            {
                //Если редактирование (ищем совпадение в кафедре, если не совпадает - запрет), если добавление - ничего не трогаем 
                if (F2_TxtBoxName.Text != "")
                {
                    string p = SystemInformation.UserName;
                    if (DBObject.Entites.User.Where(u => p == u.Login && F2_TxtBoxKafedra.Text == u.Kafedra).Count() > 0)
                    { }
                    else
                    {
                        Zapret();
                        F2_savebtn.Visible = false;
                        F2_savebtn.Visible = false;
                        F2_delbtn.Visible = false;
                    }
                }
                else { }
            }
            //F2_cmbBoxKafedra.DataSource = DBObject.Entites.Kafedra.ToList().Select(c => c.Name).Distinct().ToList();
        }

        private void F2_delbtn_Click(object sender, EventArgs e)
        {
            if (DBObject.Entites.Zakupka.Where(t => t.Id == MyZakupka.Id).Count() > 0)
            {
                DBObject.Entites.Zakupka.Remove(MyZakupka);
                DBObject.Entites.SaveChanges();
                this.Close();
            }
        }

        private void F2_savebtn_Click(object sender, EventArgs e)
        {
            DateTime dates = DateTime.Today;
            if (Convert.ToInt32(F2_cmbBoxGodZakupki.Text) < dates.Year) { MessageBox.Show("Год меньше текущего!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else
            {
                if (F2_NumUpDownTotalSum.Value != F2_NumUpDownSum.Value) { MessageBox.Show("Поля <Сумма> и <Сумма итого> должны быть одинаковы!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                else
                {
                    if (F2_cmbPoiskUsera.Text == "db_owner")
                    {
                        try
                        {
                            if (DBObject.Entites.Zakupka.Where(t => t.Id == MyZakupka.Id).Count() == 0)
                            {
                                DBObject.Entites.Zakupka.Add(MyZakupka);
                                DBObject.Entites.SaveChanges();
                            }
                            Close();
                        }
                        catch { MessageBox.Show("Некорректные данные! Заполните все строки!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                    else
                    {
                        string g = SystemInformation.UserName;
                        if (DBObject.Entites.User.Where(u => g == u.Login && F2_TxtBoxKafedra.Text == u.Kafedra).Count() == 0) { MessageBox.Show("Введите свою кафедру!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        else
                        {
                            try
                            {
                                if (DBObject.Entites.Zakupka.Where(t => t.Id == MyZakupka.Id).Count() == 0)
                                {
                                    DBObject.Entites.Zakupka.Add(MyZakupka);
                                    DBObject.Entites.SaveChanges();
                                }
                                Close();
                            }
                            catch { MessageBox.Show("Некорректные данные! Заполните все строки!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                    }
                }
            }
        }

        private void F2_closebtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void F2_TxtBoxName_TextChanged(object sender, EventArgs e)
        {
            MyZakupka.Name = F2_TxtBoxName.Text;
        }


        private void F2_cmbBoxKBK_SelectedIndexChanged(object sender, EventArgs e)
        {
            MyZakupka.KBK = Convert.ToInt32(F2_cmbBoxKBK.Text);
        }

        private void F2_cmbBoxKVR_SelectedIndexChanged(object sender, EventArgs e)
        {
            MyZakupka.KVR = Convert.ToInt32(F2_cmbBoxKVR.Text);
        }


        private void F2_NumUpDownTotalSum_ValueChanged(object sender, EventArgs e)
        {
            MyZakupka.Total_sum_rub = Convert.ToDecimal(F2_NumUpDownTotalSum.Value);
        }

        private void F2_NumUpDownSum_ValueChanged(object sender, EventArgs e)
        {
            MyZakupka.Sum_rub = Convert.ToDecimal(F2_NumUpDownSum.Value);
        }

        private void F2_TxtBoxRashifrovkaRashodov_TextChanged(object sender, EventArgs e)
        {
            MyZakupka.Deshifrovka_rashodov = F2_TxtBoxRashifrovkaRashodov.Text;
        }

        private void F2_TxtBoxMinTrebovaniya_TextChanged(object sender, EventArgs e)
        {
            MyZakupka.Min_trebovaniya = F2_TxtBoxMinTrebovaniya.Text;
        }

        private void F2_TxtBoxKolvoEdinic_TextChanged(object sender, EventArgs e)
        {
            MyZakupka.Kolvo_edinic = F2_TxtBoxKolvoEdinic.Text;
        }


        private void F2_cmbBoxSrokZakupki_SelectedIndexChanged(object sender, EventArgs e)
        {
            MyZakupka.Srok_zakupki = F2_cmbBoxSrokZakupki.Text;
        }

        private void F2_cmbBoxGodZakupki_SelectedIndexChanged(object sender, EventArgs e)
        {
            MyZakupka.God_zakupki = Convert.ToInt32(F2_cmbBoxGodZakupki.Text);
        }

        private void F2_TxtBoxKafedra_TextChanged(object sender, EventArgs e)
        {
            MyZakupka.Kafedra = F2_TxtBoxKafedra.Text;
            if (F2_TxtBoxKafedra.Text != "")
            {
                dgvKafedra.DataSource = DBObject.Entites.Kafedra.Where(c => c.Name.ToString() == F2_TxtBoxKafedra.Text).ToList();
            }
            dgvKafedra.Columns["Zakupka"].Visible = false;
            dgvKafedra.Columns["User"].Visible = false;
            dgvKafedra.Columns["Name"].HeaderText = "Кафедра:";
        }

        private void F2_TxtBoxKafedra_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsLetter(ch) && !char.IsControl(ch))
            {
                e.Handled = true;
            }
        }
    }
    
}
