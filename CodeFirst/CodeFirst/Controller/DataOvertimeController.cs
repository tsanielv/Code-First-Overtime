using System;
using CodeFirst.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Controller
{
    class DataOvertimeController
    {

        BaseContext _context = new BaseContext();
        public void Menu()
        {
            BaseContext _context = new BaseContext();
            int input;

            Console.Clear();
            System.Console.WriteLine("====================================");
            Console.WriteLine("1. Insert Data Overtime");
            Console.WriteLine("2. Lihat  Semua Data Overtime");
            Console.WriteLine("3. Get By ID Data Overtime");
            Console.WriteLine("4. Update Data Overtime");
            Console.WriteLine("5. Delete Data Overtime");
            Console.WriteLine("====================================");
            Console.Write("Pilih Menu = ");
            int pilih = Convert.ToInt32(Console.ReadLine());

            switch (pilih)
            {
                case 1:
                    Insert();
                    Console.ReadKey();
                    break;
                case 2:
                    GetAll();
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Clear();
                    Console.Write("Masukkan Kode Karyawan yang dicari : ");
                    input = Convert.ToInt32(Console.ReadLine());
                    GetById(input);
                    Console.ReadKey();
                    break;
                case 4:
                    Console.Clear();
                    Console.Write("Masukkan Id yang dicari : ");
                    input = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("===========================");
                    Console.WriteLine("Data Sebelum Diubah");
                    Console.WriteLine("===========================");
                    GetById(input);
                    Console.WriteLine("===========================");
                    Update(input);
                    Console.WriteLine("===========================");
                    Console.WriteLine("Data Setelah Diubah");
                    Console.WriteLine("===========================");
                    GetById(input);
                    Console.WriteLine("===========================");
                    Console.ReadKey();
                    break;
                case 5:
                    Console.Clear();
                    Console.Write("Masukkan Id yang didihapus : ");
                    input = Convert.ToInt32(Console.ReadLine());
                    Delete(input);
                    Console.ReadKey();
                    break;
            }
        }

        public void Insert()
        {
            Console.Write("Masukkan Nomor Karyawan  : ");
            int empID = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan Kode Jenis Pajak : ");
            int taxID = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan Kode Jenis Overtime : ");
            int overtimeID = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan Kode Customer : ");
            int customerID = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan Tanggal Overtime : ");
            DateTime tanggal = Convert.ToDateTime(Console.ReadLine());
            

            DataOvertime dataOvertime = new DataOvertime()
            {
                employeeID = empID,
                taxID = taxID,
                overtimeTypeID = overtimeID,
                customerID = customerID,
                date = tanggal,
                status = "Pending"
            };
            try
            {
                _context.DataOvertimes.Add(dataOvertime);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.Write(e.InnerException);
                Console.Write(e.Message);
                Console.Write(e.StackTrace);
            }
        }

        //Method GetAll untuk menampilkan semua data yang ada di tabel dataovertime sekaligus yang berrelasi dengannya
        public List<DataOvertime> GetAll()
        {
            Console.Clear();

            var getAll = _context.DataOvertimes.ToList();

            //var d digunakan untuk menampilkan semua data yang dibutuhkan dari tabel yang telah di-joinkan dengan foreign key
            var d = (from DataOvertime in _context.DataOvertimes
                     join Employee in _context.Employees on DataOvertime.employeeID equals Employee.id
                     join Tax in _context.Taxes on DataOvertime.taxID equals Tax.id
                     join OvertimeType in _context.OvertimeTypes on DataOvertime.overtimeTypeID equals OvertimeType.id
                     join Customer in _context.Customers on DataOvertime.customerID equals Customer.id
                     select new { Employee.name, DataOvertime.date, DataOvertime.status, OvertimeType.amount, OvertimeType.detail, CustName = Customer.name, TaxAmount = Tax.amount }).ToList();
            for(int i=0; i<d.Count(); i++)
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("Nama Karyawan       : " + d[i].name);
                Console.WriteLine("Penempatan          : " + d[i].CustName);
                Console.WriteLine("Detail Overtime     : " + d[i].detail);
                Console.WriteLine("Biaya Overtime      : " + d[i].amount);
                Console.WriteLine("Tanggal Overtime    : ");
                Console.WriteLine("Status Overtime     : " + d[i].status);
                Console.WriteLine("-------------------------");
            }
            return getAll;
        }

        //Method GetById digunakan untuk menampilkan data overtime milik seorang karyawan dengan parameter inputan Employee ID yang diinputkan oleh user
        public Employee GetById(int input)
        {
            Console.Clear();

            var employee = _context.Employees.FirstOrDefault(j => j.id == input);
            var d = (from DataOvertime in _context.DataOvertimes
                     join Employee in _context.Employees on DataOvertime.employeeID equals Employee.id
                     join Tax in _context.Taxes on DataOvertime.taxID equals Tax.id
                     join OvertimeType in _context.OvertimeTypes on DataOvertime.overtimeTypeID equals OvertimeType.id
                     join Customer in _context.Customers on DataOvertime.customerID equals Customer.id
                     select new { Employee.name, DataOvertime.date, DataOvertime.status, OvertimeType.amount, OvertimeType.detail, CustName = Customer.name,
                                  TaxAmount = Tax.amount }).ToList();
            for (int i = 0; i < d.Count(); i++)
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("Nama Karyawan       : " + d[i].name);
                Console.WriteLine("Penempatan          : " + d[i].CustName);
                Console.WriteLine("Detail Overtime     : " + d[i].detail);
                Console.WriteLine("Biaya Overtime      : " + d[i].amount);
                Console.WriteLine("Tanggal Overtime    : ");
                Console.WriteLine("Status Overtime     : " + d[i].status);
                Console.WriteLine("-------------------------");
            }
            return employee;
        }

        //Method SearchId untuk mencari Data Overtime yang ingin diupdate dengan parameter id dataovertime yang diinputkan oleh user
        public DataOvertime searchId(int input)
        {
            var dataovertime = _context.DataOvertimes.Find(input);
            if (dataovertime == null)
            {
                Console.WriteLine("Id yang dicari tidak ada");
            }

            return dataovertime;
        }

        //Method Update untuk mengupdate status pada tabel dataovertime
        public int Update(int input)
        {
            Console.Write("Masukkan Status Baru   :");
            string new_status = Console.ReadLine();

            var getover = _context.DataOvertimes.Find(input);
            if (getover == null)
            {
                Console.WriteLine("Id yang dicari tidak ada");
            }
            else
            {
                DataOvertime dataovertime = searchId(input);
                dataovertime.status = new_status;
                
                _context.Entry(dataovertime).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }
            return input;
        }

        //Method Delete digunakan untuk menghapus data dari tabel dataovertime
        public int Delete(int input)
        {
            DataOvertime dataovertime = _context.DataOvertimes.Find(input);
            _context.Entry(dataovertime).State = System.Data.Entity.EntityState.Deleted;
            _context.SaveChanges();

            return input;
        }

    }
}
