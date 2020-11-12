using IB1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IB1.Services
{
    public class FileService : IDisposable
    {
        // DES - симметричный, блочный, итеративный алгоритм шифрования.
        // 
        // * Симметричным алгоритм является, тогда когда для операции
        //   шифрования и дешифрования используется всего один ключ.
        // * Блочный алгоритм, исходный набор бит делит на блоки фиксированной длины,
        //   выполняет преобразование каждого блока используя для этого ключ.
        // * Итеративный блочный алгоритм выполняет итеративное шифрование каждого блока,
        //   каждый этап итерации называется раундом.
        //
        // * DES реализует сеть Фейстеля. Работа сети Фейстеля заключается в разбиении исходного
        //   массива бит на левый блок и правый. На каждом раунде, левый блок встаёт на место правого,
        //   а правый встаёт на место левого после того как над ним выполнили операцию XOR с левым блоком
        //   проебразованным с помощью K(i)-ого ключа, который формируется на каждом Раунде.
        //
        // * CBC мод - перед шифрованием каждого блока открытого текста он объединяется с зашифрованным
        //   текстом предыдущего блока с помощью побитовой операции "исключающего ИЛИ".
        //
        // * OFB мод - вместо преобразования всего блока в шифрованный текст
        //   преобразуются небольшие фрагменты открытого текста.

        private DES desGlobal;
        private String Key = "IB 1 key";
        private String AccessFilePath = "";
        private String CryptoProgramm = "";
        private String TempFilePath = "";
        private String Root = "";
        private UserListModel UserList = new UserListModel();

        public UserListModel AuthorizedUsers { get { return UserList; } }
        public String AdminUsername { get { return "ADMIN"; } }


        public FileService()
        {
            desGlobal = DES.Create();
            var bytes = Encoding.ASCII.GetBytes(Key);
            desGlobal.Key = bytes;
            desGlobal.IV = bytes;
            Root = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            AccessFilePath = Path.Combine(new String[] {
                Root,
                "IB1",
                "Data",
                "user.json"
            });
            CryptoProgramm = Path.Combine(new String[] {
               Root,
               "IB1",
               "Crypto",
               "main.exe"
            });
            TempFilePath = Path.Combine(new String[] {
                Root,
                "IB1",
                "Data",
                "temp.json"
            });
            var admin = new UserModel() { UserName = "ADMIN", Password = string.Empty, Lockout = AccountLockout.OK, PasswordRestriction = PasswordRestriction.MustBe };
            if (!CreateAccessFile())
            {
                try
                {
                    UserList.Add(admin);
                    var add = UserList.GetUser(admin);
                    RunGolangAndWriteFile();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    System.Environment.Exit(0);
                }
            }
            else
            {
                try
                {
                    RunGolangAndReadFile();
                    var add = UserList.GetUser(admin);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    System.Environment.Exit(0);
                }
            }
            
        }

        // -> Exception
        private void RunGolangAndReadFile() {
            CreateTempFile();
            String input = RunGolang("-r");
            String decrypted = ReadTempFile();
            UserList = JsonConvert.DeserializeObject<UserListModel>(decrypted);
            DeleteTempFile();
        }

        // -> Exception
        private void RunGolangAndWriteFile()
        {
            CreateTempFile();
            String output = JsonConvert.SerializeObject(UserList);
            WriteTempFile(output);
            String input = RunGolang("-w");
            DeleteTempFile();
        }

        // -> Exception
        private String RunGolang(String flag) {
            StringBuilder sb = new StringBuilder();
            sb.Append(flag);
            sb.Append(" ");
            sb.Append(AccessFilePath);
            sb.Append(" ");
            sb.Append(TempFilePath);
            String args = sb.ToString();
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = CryptoProgramm,
                    Arguments = args,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            proc.Start();
            String input = "";
            while (!proc.StandardOutput.EndOfStream)
            {
                if (input.Contains("error:"))
                {
                    throw new Exception(input);
                }
                input += proc.StandardOutput.ReadLine();
            }
            return input;
        }

        private Boolean CreateAccessFile()
        {
            if (!File.Exists(AccessFilePath))
            {
                try
                {
                    FileStream accessFile = File.Create(AccessFilePath);
                    accessFile.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                return false;
            }
            return true;
        }

        // -> Exception
        private void CreateTempFile()
        {
            FileStream tempFile = File.Create(TempFilePath);
            tempFile.Close();
        }

        // -> Exception
        private void DeleteTempFile()
        {
            File.Delete(TempFilePath);
        }

        // -> Exception
        private String ReadTempFile()
        {
            return File.ReadAllText(TempFilePath);
        }

        // -> Exception
        private void WriteTempFile(String data)
        {
            File.WriteAllText(TempFilePath, data);
        }

        // -> Exception
        private void BaseDESDecode()
        {
            if (!File.Exists(AccessFilePath))
            {
                throw new Exception("File isn't exist.");
            }
            DES des = DES.Create();
            des.Mode = CipherMode.CFB;
            FileStream fileStream = File.Open(AccessFilePath, FileMode.Open);
            CryptoStream cryptoStream = new CryptoStream(
               fileStream,
               des.CreateDecryptor(desGlobal.Key, desGlobal.IV),
               CryptoStreamMode.Read
            );
            StreamReader streamReader = new StreamReader(cryptoStream);
            String input = streamReader.ReadLine();
            streamReader.Close();
            cryptoStream.Close();
            fileStream.Close();
            UserList = JsonConvert.DeserializeObject<UserListModel>(input);
        }

        // -> Exception
        private void BaseDESEncode()
        {
            if (!File.Exists(this.AccessFilePath))
            {
                throw new Exception("File isn't exist.");
            }
            String output = JsonConvert.SerializeObject(UserList);
            DES des = DES.Create();
            des.Mode = CipherMode.CFB;
            FileStream fileStream = File.Open(AccessFilePath, FileMode.Open);
            CryptoStream cryptoStream = new CryptoStream(
                fileStream,
                des.CreateEncryptor(desGlobal.Key, desGlobal.IV),
                CryptoStreamMode.Write
            );
            StreamWriter streamWriter = new StreamWriter(cryptoStream);
            streamWriter.WriteLine(output);
            streamWriter.Close();
            cryptoStream.Close();
            fileStream.Close();
        }


        // -> Exception
        private void ClearFile()
        {
            File.WriteAllBytes(AccessFilePath, new byte[] { });
        }

        public void Dispose()
        {
            RunGolangAndWriteFile();
        }

        ~FileService()
        {
            RunGolangAndWriteFile();
        }
    }
}
