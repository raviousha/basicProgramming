using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static String batas = "=====================================================================================";
    public static void Main(string[] args)
    {
        int index = 0;
        int id = 0;
        String choice = "X";
        List<Product> shoesList = new List<Product>();
        shoesList.Add(new Product() { productName = "Air Jordan 1", productId = 1, productPrice = 150 });
        shoesList.Add(new Product() { productName = "Air Jordan MA2", productId = 2, productPrice = 100 });

    start:
        Console.Clear();
        MainMenu();
        Console.WriteLine();
        try
        {
            Console.Write("Masukkan pilihan: ");
            index = Convert.ToInt32(Console.ReadLine());
            switch (index)
            {
                case 1:
                    {
                        AddData(shoesList, choice, id);
                        goto start;
                    }
                case 2:
                    {
                        DeleteData(shoesList, choice);
                        goto start;
                    }
                case 3:
                    {
                        ShowData(shoesList);
                        ContinueCode();
                        goto start;
                    }
                case 4:
                    {
                        SellProduct(shoesList, choice, index);
                        goto start;
                    }
                case 5:
                    {
                        return;
                    }
                default:
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Menu tidak ditemukan / Input Salah");
                        Console.WriteLine();
                        ContinueCode();
                        goto start;
                    }
            }
        }
        catch (Exception e)
        {
            Console.Clear();
            Console.WriteLine($"Exception, {e.Message}");
            Console.WriteLine();
            ContinueCode();
            Main(args);
        }
        finally
        {
            Console.Clear();
            MainMenu();
            Console.WriteLine();
        }
    }

    static void Banner(String title)
    {
        Console.WriteLine();
        Console.WriteLine($"{title,50}");
        Console.WriteLine();
        Console.WriteLine(batas);
        Console.WriteLine();
    }

    static void MainMenu()
    {
        String title = "Sport Store";
        String[] menu = new string[5] { "Tambah Data", "Hapus Data", "Tampil Data", "Penjualan", "Exit" };
        Banner(title);
        for (int i = 0; i < menu.Length; i++)
        {
            Console.Write($"{i + 1,38}. {menu[i]}");
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.WriteLine(batas);
    }

    static void AddData(List<Product> shoesList, String choice, int id)
    {
        do
        {
            Console.Clear();
            Banner("Tambah Data");
            do
            {
                for (int a = 0; a < shoesList.Count; a++)
                {
                    Console.Write("Input ID: ");
                    id = Convert.ToInt32(Console.ReadLine());
                    if (shoesList[a].productId != id)
                    {
                        choice = "V";
                        Console.WriteLine(choice);
                        break;
                    }
                    else
                    {
                        choice = "X";
                        Console.WriteLine("ID Sudah ada");
                        Console.WriteLine();
                        Console.WriteLine(choice);
                        continue;
                    }
                }
            } while (choice == "X");
            Console.Write("Input Product Name: ");
            string name = Console.ReadLine();
            Console.Write("Input Price: ");
            int price = Convert.ToInt32(Console.ReadLine());
            shoesList.Add(new Product() { productId = id, productName = name, productPrice = price });
            Console.WriteLine();
            Console.Clear();
            Console.WriteLine($"{name} telah ditambahkan");
            Console.WriteLine();
            Console.WriteLine("Tambah Produk lagi? (Y/N)");
            choice = Console.ReadLine();
        } while (choice.ToUpper() == "Y");
    }

    static void DeleteData(List<Product> shoesList, String choice)
    {
        do
        {
            Console.Clear();
            Banner("Hapus Data");
            Console.Write("Input ID yang akan dihapus: ");
            int id = Convert.ToInt32(Console.ReadLine());
            shoesList.Remove(new Product() { productId = id });
            Console.Clear();
            Console.WriteLine("produk berhasil dihapus");
            Console.WriteLine();
            Console.Write("Hapus Produk lagi? (Y/N)");
            choice = Console.ReadLine();
        } while (choice.ToUpper() == "Y");
    }

    static void ShowData(List<Product> shoesList)
    {
        Console.Clear();
        Banner("Data Produk");
        Console.WriteLine($"{null,3} ID {null,5} {null,27}  Name {null,20} {null,7} Price {null,5} ");
        Console.WriteLine($"{null,3} __ {null,5} {null,27}  ____ {null,20} {null,7} _____ {null,5} ");
        Console.WriteLine();
        foreach (Product shoe in shoesList)
        {
            Console.WriteLine($"{shoe}");
        }
        Console.WriteLine();
        Console.WriteLine($"{batas}");
        Console.WriteLine();
    }

    static void SellProduct(List<Product> shoesList, String choice, int index)
    {
        int cash = 0;
        int total = 0;
        int count = 0;
        List<int> checkoutList = new List<int>();

        do
        {
            Console.Clear();
            Banner("Checkout");
            Console.Write("Input ID: ");
            Product[] shoeId = shoesList.ToArray();
            int id = Convert.ToInt32(Console.ReadLine());
            foreach (Product shoe in shoesList)
            {
                if (shoe.productId == id)
                {
                    checkoutList.Add(shoe.productPrice);
                }
                else
                {
                    Console.WriteLine("ID yang dimasukkan salah");
                }
            }
            while (count < checkoutList.Count)
            {
                total += checkoutList[count];
                count = count + 1;
            }
            Console.WriteLine(batas);
            foreach (var cl in checkoutList)
            {
                Console.WriteLine(cl);
            }
            Console.Clear();
            Console.WriteLine(batas);
            Console.WriteLine($"Total checkout: { total }");
            Console.WriteLine(batas);
            Console.WriteLine("Tambah Produk? (Y/N)");
            choice = Console.ReadLine();
        }
        while (choice.ToUpper() == "Y");
        {
            Console.Clear();
            Console.WriteLine($"Total checkout: { total }");
            while (cash < total)
            {
                Console.Write("Masukkan jumlah pembayaran: ");
                cash = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine("Pembayaran kurang");
            }
            Console.Clear();
            Console.WriteLine($"Total checkout: { total }");
            Console.WriteLine($"Jumlah pembayaran: {cash}");
            Console.WriteLine("Kembalian: " + kembalian(cash, total));
            Console.WriteLine();
            Console.WriteLine("Terima kasih telah berbelanja");
            Console.WriteLine();
            Console.WriteLine(batas);
            ContinueCode();
            Console.Clear();
        }
    }

    static int kembalian(int uang, int total)
    {
        int kembali = uang - total;
        return kembali;
    }

    static void ContinueCode()
    {
        Console.WriteLine();
        Console.WriteLine("press any key to continue");
        String next = Console.ReadLine();
        Console.Clear();
    }
}