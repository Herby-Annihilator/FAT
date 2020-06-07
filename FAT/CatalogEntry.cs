using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAllocationTable.FAT
{
    /// <summary>
    /// Каталожная запись 32 байта
    /// </summary>
    internal class CatalogEntry
    {
        /// <summary>
        /// Имя файла
        /// </summary>
        private string name;
        /// <summary>
        /// Возвращает или устанавливает имя файла (8 символов), если пустая строка или строка из пробелов,
        /// то установит стандартное имя NEWFILE
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value.Length > 8)
                {
                    string uppercaseSrting = "";
                    for (int i = 0; i < 8; i++)
                    {
                        uppercaseSrting += value[i];
                        name = uppercaseSrting.ToUpper();
                    }
                }
                else if (string.IsNullOrEmpty(value))
                {
                    name = "NEWFILE";
                }
                else
                {
                    name = value.ToUpper();
                }
            }
        }
        /// <summary>
        /// Расширение
        /// </summary>
        private string extension;
        /// <summary>
        /// Возвращает или устанавливает расширение файла (3 символа), если пустая строка 
        /// или строка из пробелов установит стандартное расширение EXT
        /// </summary>
        public string Extension
        {
            get
            {
                return extension;
            }
            set
            {
                if (value.Length > 3)
                {
                    string uppercaseSrting = "";
                    for (int i = 0; i < 3; i++)
                    {
                        uppercaseSrting += value[i];
                        extension = uppercaseSrting.ToUpper();
                    }
                }
                else if (string.IsNullOrEmpty(value))
                {
                    extension = "EXT";
                }
                else
                {
                    extension = value.ToUpper();
                }
            }
        }
        /// <summary>
        /// Атрибуты файла/каталога
        /// </summary>
        private Attributes attributes;
        /// <summary>
        /// Возвращает или устанавливает атрибуты каталога/файла
        /// </summary>
        public Attributes Attributes { get; set; }
        /// <summary>
        /// Возвращает или устанавливает дату и время создания файла/каталога
        /// </summary>
        public Date DateOfCreation { get; set; } = new Date();
        /// <summary>
        /// Возвращает или задает дату создания файла/каталога
        /// </summary>
        public Time TimeOfCreation { get; set; } = new Time();
        /// <summary>
        /// Возвращает или задает дату последнего доступа
        /// </summary>
        public Date LastAccessDate { get; set; } = new Date();
        /// <summary>
        /// Возвращает или задает время последней записи в файл/каталог
        /// </summary>
        public Time LastTimeRecorded { get; set; } = new Time();
        /// <summary>
        /// Возвращает или задает дату последней записи в файл/каталог
        /// </summary>
        public Date LastDateRecorded { get; set; } = new Date();
        
        /// <summary>
        /// Номер первого блока в таблице FAT
        /// </summary>
        private int firstBlockNumber;
        /// <summary>
        /// Возвращает или устанавливает номер первого блока в таблице FAT
        /// </summary>
        public int FirstBlockNumber
        {
            get
            {
                return firstBlockNumber;
            }
            set
            {
                if (value > GlobalConstants.FIRST_BLOCK_MAX_NUMBER)
                {
                    firstBlockNumber = GlobalConstants.FIRST_BLOCK_MAX_NUMBER;
                }
                else if (value < 0)
                {
                    firstBlockNumber = 0;
                }
                else
                {
                    firstBlockNumber = value;
                }
            }
        }

        /// <summary>
        /// Размер файла
        /// </summary>
        private int fileSize;
        /// <summary>
        /// Возвращает или задает размер файла/каталога
        /// </summary>
        public int FileSize
        {
            get
            {
                return fileSize;
            }
            set
            {
                if (value > GlobalConstants.MAX_FILE_SIZE)
                {
                    fileSize = GlobalConstants.MAX_FILE_SIZE;
                }
                else if (value < 0)
                {
                    fileSize = 0;
                }
                else
                {
                    fileSize = value;
                }
            }
        }
        /// <summary>
        /// Создает каталожную запись с актуальными временными параметрами
        /// </summary>
        /// <param name="attributes">атрибуты файла</param>
        /// <param name="fileSize">размер файла</param>
        /// <param name="firstBlockNumber">номер первого кластера этого файла в FAT</param>
        /// <param name="name">имя файла</param>
        /// <param name="extension">расширение файла</param>
        public CatalogEntry(Attributes attributes, int fileSize, int firstBlockNumber, string name, string extension)
        {
            Name = name;
            Extension = extension;
            Attributes = attributes;
            FirstBlockNumber = firstBlockNumber;
            FileSize = fileSize;

            DateOfCreation.SetCurrentDate();
            LastAccessDate.SetCurrentDate();
            LastDateRecorded.SetCurrentDate();
            LastTimeRecorded.SetCurrentTime();
            TimeOfCreation.SetCurrentTime();
        }
    }
    /// <summary>
    /// Атрибуты
    /// </summary>
    public class Attributes
    {
        /// <summary>
        /// Только для чтения
        /// </summary>
        public bool ReadOnly { get; set; }
        /// <summary>
        /// Только для чтения
        /// </summary>
        public bool Hidden { get; set; }
        /// <summary>
        /// Системный
        /// </summary>
        public bool System { get; set; }
        /// <summary>
        /// Метка тома
        /// </summary>
        public bool PartMark { get; set; }
        /// <summary>
        /// Подкаталог
        /// </summary>
        public bool Subdirectory { get; set; }
        /// <summary>
        /// Архивный
        /// </summary>
        public bool Archival { get; set; }
        /// <summary>
        /// Устанавливает все флаги в 0
        /// </summary>
        public Attributes()
        {
            ReadOnly = false;
            Hidden = false;
            System = false;
            PartMark = false;
            Subdirectory = false;
            Archival = false;
        }
        /// <summary>
        /// Устанавливает флаги так, как вы прикажете
        /// </summary>
        /// <param name="readOnly">Только для чтения</param>
        /// <param name="hidden">Только для чтения</param>
        /// <param name="system">Системный</param>
        /// <param name="partMark">Метка тома</param>
        /// <param name="subDirectory">Подкаталог</param>
        /// <param name="archival">Архивный</param>
        public Attributes(bool readOnly, bool hidden, bool system, bool partMark, bool subDirectory, bool archival)
        {
            ReadOnly = readOnly;
            Hidden = hidden;
            System = system;
            PartMark = partMark;
            Subdirectory = subDirectory;
            Archival = archival;
        }
    }
    /// <summary>
    /// Дата создания 2 байта
    /// </summary>
    public class Date
    {
        /// <summary>
        /// День месяца
        /// </summary>
        private int dayOfMounth;
        /// <summary>
        /// Возвращает или устанавливает день месяца
        /// </summary>
        public int DayOfMounth
        {
            get
            {
                return dayOfMounth;
            }
            set
            {
                if (value > 31)
                {
                    dayOfMounth = 31;
                }
                else if (value < 1)
                {
                    dayOfMounth = 1;
                }
                else
                {
                    dayOfMounth = value;
                }
            }
        }
        /// <summary>
        /// Месяц года
        /// </summary>
        private int mounthOfYear;
        /// <summary>
        /// Возвращает или устанавливает месяц года
        /// </summary>
        public int MounthOfYear
        {
            get
            {
                return mounthOfYear;
            }
            set
            {
                if (value > 12)
                {
                    mounthOfYear = 12;
                }
                else if (value < 1)
                {
                    mounthOfYear = 1;
                }
                else
                {
                    mounthOfYear = value;
                }
            }
        }
        /// <summary>
        /// Год
        /// </summary>
        private int year;
        /// <summary>
        /// Возвращает или устанавливает год
        /// </summary>
        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                if (value > 9999)
                {
                    year = DateTime.Now.Year;
                }
                else if (value < 1)
                {
                    year = DateTime.Now.Year;
                }
                else
                {
                    year = value;
                }
            }
        }
        /// <summary>
        /// Устанавливает текущий день
        /// </summary>
        public void SetCurrentDay()
        {
            DayOfMounth = DateTime.Now.Day;
        }
        /// <summary>
        /// Устанавливает текущий месяц
        /// </summary>
        public void SetCurrentMounth()
        {
            MounthOfYear = DateTime.Now.Month;
        }
        /// <summary>
        /// Устанавливает текущий год
        /// </summary>
        public void SetCurrentYear()
        {
            Year = DateTime.Now.Year;
        }
        /// <summary>
        /// Устанавливает текущую дату
        /// </summary>
        public void SetCurrentDate()
        {
            SetCurrentDay();
            SetCurrentMounth();
            SetCurrentYear();
        }
        /// <summary>
        /// Устанавливает текущие день месяца, месяц года и год
        /// </summary>
        public Date()
        {
            DayOfMounth = DateTime.Now.Day;
            MounthOfYear = DateTime.Now.Month;
            Year = DateTime.Now.Year;
        }
        /// <summary>
        /// Устанавливает указанные день месяца, месяц года и год
        /// </summary>
        /// <param name="day">день</param>
        /// <param name="mounth">месяц</param>
        /// <param name="year">год</param>
        public Date(int day, int mounth, int year)
        {
            DayOfMounth = day;
            MounthOfYear = mounth;
            Year = year;
        }
    }
    /// <summary>
    /// Время (2 байта)
    /// </summary>
    public class Time
    {
        private int seconds;
        public int Seconds
        {
            get
            {
                return seconds;
            }
            set
            {
                if (value > 59)
                {
                    seconds = 59;
                }
                else if (value < 0)
                {
                    seconds = 0;
                }
                else
                {
                    seconds = value;
                }
            }
        }
        /// <summary>
        /// Минуты
        /// </summary>
        private int minutes;
        /// <summary>
        /// Возвращает или устанавливает минуты
        /// </summary>
        public int Minutes
        {
            get
            {
                return minutes;
            }
            set
            {
                if (value > 59)
                {
                    minutes = 59;
                }
                else if (value < 0)
                {
                    minutes = 0;
                }
                else
                {
                    minutes = value;
                }
            }
        }
        /// <summary>
        /// Часы
        /// </summary>
        private int hours;
        /// <summary>
        /// Возвращает или устанавливает часы
        /// </summary>
        public int Hours
        {
            get
            {
                return hours;
            }
            set
            {
                if (value > 23)
                {
                    hours = 23;
                }
                else if (value < 0)
                {
                    hours = 0;
                }
                else
                {
                    hours = value;
                }
            }
        }
        /// <summary>
        /// Устанавливет текущие секунды
        /// </summary>
        public void SetCurrentSeconds()
        {
            Hours = DateTime.Now.Second;
        }
        /// <summary>
        /// Устанавливает текущие минуты
        /// </summary>
        public void SetCurrentMinutes()
        {
            Minutes = DateTime.Now.Minute;
        }
        /// <summary>
        /// Устанавливает текущие часы
        /// </summary>
        public void SetCurrentHours()
        {
            Hours = DateTime.Now.Hour;
        }
        /// <summary>
        /// Устанавливает текущее время
        /// </summary>
        public void SetCurrentTime()
        {
            SetCurrentHours();
            SetCurrentMinutes();
            SetCurrentSeconds();
        }
        /// <summary>
        /// Создает объект Time и устанавливает текущее время системы
        /// </summary>
        public Time()
        {
            SetCurrentTime();
        }
        /// <summary>
        /// Создает объект Time и устанавливает указанные атрибуты времени
        /// </summary>
        /// <param name="seconds">секунды</param>
        /// <param name="minutes">минуты</param>
        /// <param name="hours">часы</param>
        public Time(int seconds, int minutes, int hours)
        {
            Seconds = seconds;
            Minutes = minutes;
            Hours = hours;
        }
    }
}
