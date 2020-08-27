﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CV19Console
{
    class Program
    {
        private const string DATA_URL = @"https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_confirmed_global.csv";

        //Метод котоырй возвращает поток, а не весь файл, для того, что бы мы могли прервать получение не нужных данных.

        private static async Task<Stream> GetDataStream()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(DATA_URL, HttpCompletionOption.ResponseHeadersRead);

            return await response.Content.ReadAsStreamAsync();

        }

        //Теперь читаем текстовые данные

        private static  IEnumerable<string> GetDataLines()
        {
             using var data_stream =  GetDataStream().Result;
            using var data_reader = new StreamReader(data_stream);
           while(!data_reader.EndOfStream)
            {
                var line =  data_reader.ReadLine();
                if (string.IsNullOrWhiteSpace(line)) continue;
                yield return line;
            }

        }

        /// <summary>
        /// Получаение даты из файла
        /// </summary>
        /// <returns></returns>
        private static DateTime[] GetDates() => GetDataLines().First().Split(',').Skip(4).Select(s => DateTime.Parse(s, CultureInfo.InvariantCulture)).ToArray();


        static void Main(string[] args)
        {
            var dates = GetDates(); //Получаем даты из файла.

            Console.WriteLine(string.Join("\r\n",dates));


            Console.ReadLine();
        }
    }
}
